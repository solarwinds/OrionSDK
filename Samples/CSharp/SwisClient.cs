using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSRestClient
{
    public class SwisClient : ISwisClient
    {
        private readonly string _hostname;
        private readonly string _username;
        private readonly string _password;

        public SwisClient(string hostname, string username, string password)
        {
            _hostname = hostname ?? throw new ArgumentNullException(nameof(hostname));
            _username = username ?? throw new ArgumentNullException(nameof(username));
            _password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public Task<JToken> QueryAsync(string query, object parameters = null)
        {
            return SwisCallAsync(client =>
            {
                var request = new JObject();
                request["query"] = query;
                if (parameters != null)
                    request["parameters"] = JObject.FromObject(parameters);

                HttpContent content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
                return client.PostAsync("Query", content);
            });
        }

        public Task<JToken> InvokeAsync(string entity, string verb, params object[] args)
        {
            return SwisCallAsync(client => client.PostAsync(string.Format("Invoke/{0}/{1}", entity, verb), MakeHttpContent(args)));
        }

        public async Task<string> CreateAsync(string entity, object properties)
        {
            var result = await SwisCallAsync(client => client.PostAsync(string.Format("Create/{0}", entity), MakeHttpContent(properties)));
            return (string)((JValue)result).Value;
        }

        public async Task<JObject> ReadAsync(string uri)
        {
            // Normally HttpClient will combine the BaseAddress with the url fragment for you. However, in this 
            // case the url fragment is a swis uri, which looks like an absolute uri to HttpClient.
            return (JObject)await SwisCallAsync(client => client.GetAsync(client.BaseAddress + uri));
        }

        public Task UpdateAsync(string uri, object properties)
        {
            return SwisCallAsync(client => client.PostAsync(client.BaseAddress + uri, MakeHttpContent(properties)));
        }

        public Task UpdateAsync(IEnumerable<string> uris, object properties)
        {
            return SwisCallAsync(client => client.PostAsync("BulkUpdate", MakeHttpContent(new { uris, properties })));
        }

        public Task DeleteAsync(string uri)
        {
            return SwisCallAsync(client => client.DeleteAsync(client.BaseAddress + uri));
        }

        public Task DeleteAsync(IEnumerable<string> uris)
        {
            return SwisCallAsync(client => client.PostAsync("BulkDelete", MakeHttpContent(new { uris })));
        }

        private static HttpContent MakeHttpContent(object value)
        {
            var request = JToken.FromObject(value);
            return new StringContent(request.ToString(), Encoding.UTF8, "application/json");
        }

        private async Task<JToken> SwisCallAsync(Func<HttpClient, Task<HttpResponseMessage>> doRequest)
        {
            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(_username, _password),
                PreAuthenticate = true,
                ServerCertificateCustomValidationCallback = ValidateServerCertificate
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(string.Format("https://{0}:17774/SolarWinds/InformationService/v3/Json/", _hostname));
                HttpResponseMessage response = await doRequest(client);
                var result = JToken.Load(new JsonTextReader(new StreamReader(await response.Content.ReadAsStreamAsync())));
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(string.Format("Server returned error: {0} {1}{2}{3}", (int)response.StatusCode,
                        response.ReasonPhrase, Environment.NewLine, result));
                }

                return result;
            }
        }

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
