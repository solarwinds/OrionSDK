using System;
using System.Net;
using System.ServiceModel;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    internal class JavaHttpInfoService : InfoServiceBase
    {
        public JavaHttpInfoService(string username, string password)
        {
            _endpointConfigName = "JavaHttpBinding_InformationServicev2";
            _endpoint = Settings.Default.JavaEndpointPath;

            _binding = new WSHttpBinding("javaBinding");
            _protocolName = "https";
            _credentials = new UsernameCredentials(username, password);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = CertificateValidatorWithCache.ValidateRemoteCertificate;
        }

        public override string ServiceType
        {
            get { return "Java over HTTP"; }
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
