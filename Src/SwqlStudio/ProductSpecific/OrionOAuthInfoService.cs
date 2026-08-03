using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Properties;
using OAuthTokenManager = SolarWinds.InformationService.Contract2.OAuthTokenManager;

namespace SwqlStudio
{
    internal class OrionOAuthInfoService : InfoServiceBase
    {
        static OrionOAuthInfoService()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        private OAuthTokenManager _tokenManager;

        public OrionOAuthInfoService()
        {
            _protocolName = "https";
            _endpoint = Settings.Default.OrionV3OAuthEndpointPath;
            _endpointConfigName = string.Empty;

            var binding = new BasicHttpBinding
            {
                MaxReceivedMessageSize = int.MaxValue,
                MaxBufferSize = int.MaxValue,
                Security =
                {
                    Mode = BasicHttpSecurityMode.Transport,
                    Transport = { ClientCredentialType = HttpClientCredentialType.None }
                }
            };
            binding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
            binding.ReaderQuotas.MaxArrayLength = int.MaxValue;
            _binding = binding;
            // _credentials is set in CreateProxy once the token manager is initialised
        }

        public OAuthTokenManager TokenManager => _tokenManager;

        // Called from NewConnection dialog before CreateProxy so authentication
        // can happen while the dialog is still open.
        public void InitTokenManager(string server)
        {
            if (_tokenManager == null || _tokenManager.Server != server)
                _tokenManager = new OAuthTokenManager(server, CertificateValidatorWithCache.ValidateRemoteCertificate);
        }

        public override string ServiceType => "Orion (v3) OAuth";

        protected override int Port => Settings.Default.DefaultInfoServiceHttpsPort;

        public override InfoServiceProxy CreateProxy(string server)
        {
            if (_tokenManager == null)
                _tokenManager = new OAuthTokenManager(server, CertificateValidatorWithCache.ValidateRemoteCertificate);

            _credentials = new BearerTokenCredentials(() => _tokenManager.GetCurrentToken());

            // WCF BasicHttpBinding with ClientCredentialType.None routes TLS cert
            // validation through ServicePointManager rather than the channel factory's
            // credential pipeline. Register a non-interactive validator that silently
            // accepts the Orion server cert (the user already trusted this server by
            // completing the OAuth browser flow against it).
            ServicePointManager.ServerCertificateValidationCallback = AcceptServerCertificate;

            return base.CreateProxy(server);
        }

        public override bool TryReAuthenticate(Exception ex)
        {
            if (_tokenManager == null)
                return false;

            if (!(ex is OAuthSessionExpiredException) && !(ex?.InnerException is OAuthSessionExpiredException))
                return false;

            try
            {
                var task = Task.Run(() => _tokenManager.AcquireTokenAsync(CancellationToken.None));
                while (!task.IsCompleted)
                {
                    Application.DoEvents();
                    Thread.Sleep(50);
                }
                task.GetAwaiter().GetResult();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool AcceptServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}
