using System.IdentityModel.Selectors;
using System.Security.Cryptography.X509Certificates;

namespace SwqlStudio
{
    public class CustomCertificateValidator : X509CertificateValidator
    {
        private static readonly SolarWinds.Logging.Log log = new SolarWinds.Logging.Log();

        public CustomCertificateValidator()
        {
            using (log.Block())
            {

            }
        }

        public override void Validate(X509Certificate2 certificate)
        {
            log.InfoFormat("Allowing certificate {0}", certificate);
        }
    }
}
