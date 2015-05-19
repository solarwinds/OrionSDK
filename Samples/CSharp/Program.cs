using System;
using System.Diagnostics;
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
    class Program
    {
        private const string hostname = "localhost";
        private const string username = "admin";
        private const string password = "";

        static void Main(string[] args)
        {
            try
            {
                const string query = @"SELECT TOP 1 AlertDefID, ActiveObject, ObjectType 
FROM Orion.AlertStatus
WHERE Acknowledged=0
ORDER BY TriggerTimeStamp DESC";

                JToken queryResult = Query(query).Result;
                Console.WriteLine(queryResult);

                var alert = queryResult["results"][0];

                JToken invokeResult = Invoke("Orion.AlertStatus", "Acknowledge", new object[]
                {
                    new[]
                    {
                        new
                        {
                            DefinitionId = alert["AlertDefID"],
                            ObjectType = alert["ObjectType"],
                            ObjectId = alert["ActiveObject"]
                        }
                    }
                }).Result;
                Console.WriteLine(invokeResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();                
            }
        }

        private static Task<JToken> Query(string query, object parameters = null)
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

        private static Task<JToken> Invoke(string entity, string verb, params object[] args)
        {
            return SwisCallAsync(client =>
            {
                var request = JToken.FromObject(args);
                HttpContent content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
                return client.PostAsync(string.Format("Invoke/{0}/{1}", entity, verb), content);
            });
        }

        private static async Task<JToken> SwisCallAsync(Func<HttpClient, Task<HttpResponseMessage>> doRequest)
        {
            var handler = new WebRequestHandler
            {
                Credentials = new NetworkCredential(username, password),
                PreAuthenticate = true,
                ServerCertificateValidationCallback = ValidateServerCertificate
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(string.Format("https://{0}:17778/SolarWinds/InformationService/v3/Json/", hostname));
                HttpResponseMessage response = await doRequest(client);
                response.EnsureSuccessStatusCode();
                return JToken.Load(new JsonTextReader(new StreamReader(await response.Content.ReadAsStreamAsync())));
            }
        }

        private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
