using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SolarWinds.InformationService.Contract2
{
    public class OAuthTokenManager
    {
        private static readonly string[] Scopes = { "swis" };

        private readonly string _clientId;
        private readonly string _server;
        private readonly RemoteCertificateValidationCallback _certValidator;
        private readonly SemaphoreSlim _refreshLock = new SemaphoreSlim(1, 1);
        private string _accessToken;
        private string _refreshToken;
        private DateTime _accessTokenExpiry = DateTime.MinValue;

        public string Server => _server;
        public string LastAccountUsername { get; private set; } = string.Empty;

        private string AuthorizeUrl => $"https://{_server}/oauth/authorize";
        private string TokenUrl => $"https://{_server}/oauth/token";

        public OAuthTokenManager(string server, RemoteCertificateValidationCallback certValidator = null, string clientId = "swql_studio")
        {
            if (string.IsNullOrWhiteSpace(server))
                throw new ArgumentNullException(nameof(server));

            // Validate that _server is a plain host[:port] — no path, query, userinfo, or
            // fragment components that could escape into the constructed HTTPS URL opened by Process.Start.
            if (!Uri.TryCreate("https://" + server + "/", UriKind.Absolute, out var probe)
                || !string.IsNullOrEmpty(probe.Query)
                || !string.IsNullOrEmpty(probe.UserInfo)
                || !string.IsNullOrEmpty(probe.Fragment)
                || probe.PathAndQuery != "/")
            {
                throw new ArgumentException("Server must be a plain hostname or host:port value.", nameof(server));
            }

            _server = server;
            _certValidator = certValidator;
            _clientId = clientId;
        }

        public async Task AcquireTokenAsync(CancellationToken cancellationToken = default)
        {
            string codeVerifier = GenerateCodeVerifier();
            string codeChallenge = GenerateCodeChallenge(codeVerifier);
            string state = GenerateRandomBase64Url(16);

            // Bind the listener first so the port is held before building the redirect URI.
            // Building the auth URL before Start() would open a TOCTOU window where another
            // process could claim the port between port selection and listener binding.
            using (var listener = new HttpListener())
            {
                int port = FindFreePort();
                string redirectUri = $"http://localhost:{port}/";
                listener.Prefixes.Add(redirectUri);
                listener.Start();

                string authUrl = AuthorizeUrl
                    + "?response_type=code"
                    + "&client_id=" + Uri.EscapeDataString(_clientId)
                    + "&redirect_uri=" + Uri.EscapeDataString(redirectUri)
                    + "&scope=" + Uri.EscapeDataString(string.Join(" ", Scopes))
                    + "&state=" + Uri.EscapeDataString(state)
                    + "&code_challenge=" + Uri.EscapeDataString(codeChallenge)
                    + "&code_challenge_method=S256";

                Process.Start(new ProcessStartInfo(authUrl) { UseShellExecute = true });

                string code = null;
                string error = null;
                string errorDescription = null;

                using (cancellationToken.Register(() => listener.Stop()))
                {
                    while (code == null && error == null)
                    {
                        HttpListenerContext context;
                        try
                        {
                            context = await listener.GetContextAsync().ConfigureAwait(false);
                        }
                        catch (HttpListenerException) when (cancellationToken.IsCancellationRequested)
                        {
                            throw new OperationCanceledException(cancellationToken);
                        }

                        var query = context.Request.QueryString;

                        bool isCallback = query["code"] != null || query["error"] != null || query["state"] != null;
                        if (isCallback)
                        {
                            error = query["error"];
                            errorDescription = query["error_description"];

                            if (error == null)
                            {
                                if (!string.Equals(query["state"], state, StringComparison.Ordinal))
                                    throw new InvalidOperationException("OAuth state mismatch.");

                                code = query["code"];
                                if (string.IsNullOrEmpty(code))
                                    throw new InvalidOperationException("OAuth authorization response did not contain a code.");
                            }

                            byte[] responsePage = OAuthHtmlRenderer.RenderCallbackPage(error, errorDescription, _clientId);
                            context.Response.ContentType = "text/html; charset=utf-8";
                            context.Response.ContentLength64 = responsePage.Length;
                            await context.Response.OutputStream.WriteAsync(responsePage, 0, responsePage.Length).ConfigureAwait(false);
                            context.Response.Close();
                        }
                        else
                        {
                            context.Response.StatusCode = 404;
                            context.Response.Close();
                        }
                    }
                }

                if (error != null)
                    throw new InvalidOperationException($"OAuth authorization failed: {error} — {errorDescription}");

                await ExchangeCodeForTokensAsync(code, codeVerifier, redirectUri, cancellationToken).ConfigureAwait(false);
            }
        }

        public string GetCurrentToken()
        {
            if (_accessToken == null)
                throw new InvalidOperationException("OAuth authentication has not been completed. Please reconnect.");

            if (DateTime.UtcNow < _accessTokenExpiry)
                return _accessToken;

            if (_refreshToken == null)
                throw new OAuthSessionExpiredException();

            // Serialize concurrent refreshes so only one thread hits the token endpoint.
            // Uses Task.Run to avoid blocking a captured SynchronizationContext (e.g. the
            // WinForms UI thread) when called from the WCF message inspector.
            if (!_refreshLock.Wait(TimeSpan.FromSeconds(30)))
                throw new InvalidOperationException("OAuth token refresh timed out waiting for the lock.");
            try
            {
                // Re-check expiry under the lock — another thread may have already refreshed.
                if (DateTime.UtcNow < _accessTokenExpiry)
                    return _accessToken;

                RefreshAccessTokenSync();
                return _accessToken;
            }
            catch (OAuthSessionExpiredException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("OAuth token refresh failed: " + ex.Message, ex);
            }
            finally
            {
                _refreshLock.Release();
            }
        }

        public Task SignOutAsync()
        {
            _accessToken = null;
            _refreshToken = null;
            _accessTokenExpiry = DateTime.MinValue;
            LastAccountUsername = string.Empty;
            return Task.CompletedTask;
        }

        private async Task ExchangeCodeForTokensAsync(string code, string codeVerifier, string redirectUri, CancellationToken cancellationToken)
        {
            var parameters = new Dictionary<string, string>
            {
                ["grant_type"] = "authorization_code",
                ["client_id"] = _clientId,
                ["code"] = code,
                ["redirect_uri"] = redirectUri,
                ["code_verifier"] = codeVerifier,
            };

            var response = await PostFormAsync(parameters, cancellationToken).ConfigureAwait(false);
            ApplyTokenResponse(response);
        }

        private void RefreshAccessTokenSync()
        {
            var parameters = new Dictionary<string, string>
            {
                ["grant_type"] = "refresh_token",
                ["client_id"] = _clientId,
                ["refresh_token"] = _refreshToken,
            };

            // Task.Run escapes any captured SynchronizationContext so the async
            // continuations inside PostFormAsync are never scheduled back onto a
            // single-threaded context (e.g. the WinForms message loop), preventing
            // the GetResult() call from deadlocking.
            var response = Task.Run(() => PostFormAsync(parameters, CancellationToken.None)).GetAwaiter().GetResult();
            ApplyTokenResponse(response);
        }

        private async Task<TokenResponse> PostFormAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken)
        {
            var handler = new HttpClientHandler();
            if (_certValidator != null)
            {
                handler.ServerCertificateCustomValidationCallback =
                    (msg, cert, chain, errors) => _certValidator(msg, cert, chain, errors);
            }

            using (var client = new HttpClient(handler, disposeHandler: true) { Timeout = TimeSpan.FromSeconds(30) })
            using (var content = new FormUrlEncodedContent(parameters))
            {
                var httpResponse = await client.PostAsync(TokenUrl, content, cancellationToken).ConfigureAwait(false);
                byte[] body = await httpResponse.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

                if (!httpResponse.IsSuccessStatusCode)
                    throw new InvalidOperationException($"Token request failed ({(int)httpResponse.StatusCode}): {Encoding.UTF8.GetString(body)}");

                var serializer = new DataContractJsonSerializer(typeof(TokenResponse));
                using (var stream = new System.IO.MemoryStream(body))
                    return (TokenResponse)serializer.ReadObject(stream);
            }
        }

        internal void ApplyTokenResponse(TokenResponse response)
        {
            // Subtract 30 s as a refresh-before-expiry buffer.
            // If ExpiresIn is 0 or very small, use a 60-second window so a single
            // refresh doesn't immediately re-expire and cause a storm.
            int effectiveExpiry = response.ExpiresIn > 30 ? response.ExpiresIn - 30 : 60;

            string jwt = response.IdToken ?? response.AccessToken;
            string username = OAuthJwtParser.ExtractUsername(jwt) ?? string.Empty;

            _accessToken = response.AccessToken;
            // Only overwrite the refresh token when the server returns a new one.
            // Some servers (non-rotating) omit it in the refresh response intending
            // the original to remain valid — nulling it would break the next refresh.
            if (!string.IsNullOrEmpty(response.RefreshToken))
                _refreshToken = response.RefreshToken;
            _accessTokenExpiry = DateTime.UtcNow.AddSeconds(effectiveExpiry);
            LastAccountUsername = username;
        }

        private static string GenerateCodeVerifier() => GenerateRandomBase64Url(32);

        private static string GenerateCodeChallenge(string codeVerifier)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(Encoding.ASCII.GetBytes(codeVerifier));
                return Base64UrlEncode(hash);
            }
        }

        private static string GenerateRandomBase64Url(int byteLength)
        {
            var bytes = new byte[byteLength];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(bytes);
            return Base64UrlEncode(bytes);
        }

        private static string Base64UrlEncode(byte[] bytes)
        {
            return Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
        }

        private static int FindFreePort()
        {
            var tcpListener = new TcpListener(IPAddress.Loopback, 0);
            tcpListener.Start();
            int port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
            tcpListener.Stop();
            return port;
        }

        [DataContract]
        internal class TokenResponse
        {
            [DataMember(Name = "access_token")]
            public string AccessToken { get; set; }

            [DataMember(Name = "refresh_token")]
            public string RefreshToken { get; set; }

            [DataMember(Name = "expires_in")]
            public int ExpiresIn { get; set; }

            [DataMember(Name = "id_token")]
            public string IdToken { get; set; }
        }
    }
}
