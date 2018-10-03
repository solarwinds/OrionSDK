using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Windows.Forms;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    class JavaHttpInfoService : InfoServiceBase
    {
        public JavaHttpInfoService(string username, string password)
        {
            _endpointConfigName = "JavaHttpBinding_InformationServicev2";
            _endpoint = Settings.Default.JavaEndpointPath;

            _binding = new WSHttpBinding("javaBinding");
            _protocolName = "https";
            _credentials = new UsernameCredentials(username, password);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = ValidateRemoteCertificate;
        }

        public override string ServiceType
        {
            get { return "Java over HTTP"; }
        }

        private static bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
        {
            return (DialogResult.Yes ==
                    MessageBox.Show("Server certificate has problem " + sslpolicyerrors + ". Connect anyway?",
                                    "SSL Certificate Issue", MessageBoxButtons.YesNo));
        }

        public override Uri Uri(string serverAddress)
        {
            Uri resultUri;
            if (System.Uri.TryCreate(serverAddress, UriKind.Absolute, out resultUri))
                return resultUri;

            return base.Uri(serverAddress);
        }

        protected override int Port
        {
            get { return Settings.Default.DefaultJavaInfoServicePort; }
        }
    }
}
