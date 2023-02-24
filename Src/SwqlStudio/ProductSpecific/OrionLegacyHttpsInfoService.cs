using System.Net;

namespace SwqlStudio
{
    internal class OrionLegacyHttpsInfoService : OrionHttpsInfoService
    {
        static OrionLegacyHttpsInfoService()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = CertificateValidatorWithCache.ValidateRemoteCertificate;
        }

        public OrionLegacyHttpsInfoService(string username, string password) : base(username, password)
        {
        }

        public override string ServiceType => "Orion over HTTPS legacy pre-2023";

        protected override int Port => 17778;
    }
}
