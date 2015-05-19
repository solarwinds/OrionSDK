using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    class OrionInfoServiceCertificate : InfoServiceBase
    {
        public OrionInfoServiceCertificate(bool v3 = false)
        {
            _endpoint = v3 ? Settings.Default.OrionV3EndpointPathCertificate : Settings.Default.OrionEndpointPathCertificate;
            _endpointConfigName = "OrionCertificateTcpBinding";
            _binding = new NetTcpBinding("Certificate");
            _credentials = new MyCertificateCredential(Settings.Default.CertificateSubjectName, StoreLocation.LocalMachine, StoreName.My);
        }

        private class MyCertificateCredential : CertificateCredential
        {
            public MyCertificateCredential(string subjectName, StoreLocation storeLocation, StoreName storeName) : base(subjectName, storeLocation, storeName)
            {
            }

            public override void ApplyTo(ChannelFactory channelFactory)
            {
                base.ApplyTo(channelFactory);
                channelFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
                channelFactory.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = new CustomCertificateValidator();
            }
        }

        public override string ServiceType
        {
            get { return "Orion Certificate"; }
        }
    }
}
