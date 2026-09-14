using System;
using System.Management.Automation;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Threading;
using SolarWinds.InformationService.Contract2;

namespace SwisPowerShell
{
    [Cmdlet(VerbsCommunications.Connect, "SwisOAuth")]
    [OutputType(typeof(InfoServiceProxy))]
    public class ConnectSwisOAuth : PSCmdlet
    {
        private const string HttpsEndpoint = "https://{0}:17774/SolarWinds/InformationService/v3/OAuth";

        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Hostname or IP address of the Orion server.")]
        public string Hostname { get; set; }

        [Parameter(HelpMessage = "Trust all SSL/TLS certificates (useful for self-signed certs in dev environments).")]
        public SwitchParameter TrustAllCertificates { get; set; }

        private CancellationTokenSource _cts;

        protected override void StopProcessing()
        {
            try { _cts?.Cancel(); }
            catch (ObjectDisposedException) { }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            RemoteCertificateValidationCallback certCallback = TrustAllCertificates.IsPresent
                ? (sender, cert, chain, errors) => true
                : (RemoteCertificateValidationCallback)ValidateCertificate;

            var tokenManager = new OAuthTokenManager(Hostname, certCallback, "swi_powershell_sdk");

            _cts = new CancellationTokenSource();
            try
            {
                tokenManager.AcquireTokenAsync(_cts.Token).GetAwaiter().GetResult();
            }
            catch (OperationCanceledException)
            {
                WriteWarning("OAuth authentication was cancelled.");
                return;
            }
            finally
            {
                _cts.Dispose();
                _cts = null;
            }

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

            var uri = new Uri(string.Format(HttpsEndpoint, Hostname));

            var proxy = new OAuthInfoServiceProxy(uri, binding, tokenManager);

            // On .NET Core, WCF uses HttpClient internally and ignores ServicePointManager.
            // SslCertificateAuthentication is the correct hook for HTTPS transport cert validation.
            if (TrustAllCertificates.IsPresent)
            {
                proxy.ChannelFactory.Credentials.ServiceCertificate.SslCertificateAuthentication =
                    new System.ServiceModel.Security.X509ServiceCertificateAuthentication
                    {
                        CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None
                    };
            }

            WriteObject(proxy);
        }

        private static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return errors == SslPolicyErrors.None;
        }
    }
}
