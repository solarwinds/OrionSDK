using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Windows.Forms;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    internal class OrionHttpsInfoService : InfoServiceBase
    {
        static OrionHttpsInfoService()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = CertificateValidatorWithCache.ValidateRemoteCertificate;
        }

        private static bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
        {
            return (DialogResult.Yes ==
                    MessageBox.Show("Server certificate has problem " + sslpolicyerrors + ". Connect anyway?",
                                    "SSL Certificate Issue", MessageBoxButtons.YesNo));
        }

        public OrionHttpsInfoService(string username, string password, bool v3 = false)
        {
            _protocolName = "https";
            _endpoint = v3 ? Settings.Default.OrionV3HttpsEndpointPath : Settings.Default.OrionHttpsEndpointPath;
            _endpointConfigName = "OrionHttpBinding_InformationServicev2";
            _binding = new BasicHttpBinding("SWIS.Over.HTTP");
            _credentials = new UsernameCredentials(username, password);
        }

        public override string ServiceType
        {
            get { return "Orion over HTTPS"; }
        }

        protected override int Port
        {
            get { return Settings.Default.DefaultInfoServiceHttpsPort; }
        }
    }
}
