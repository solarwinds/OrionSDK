using System.IdentityModel.Selectors;
using System.Security.Cryptography.X509Certificates;

namespace SolarWinds.InformationService.Contract2
{
    class AllTrustingCertificateValidator : X509CertificateValidator
    {
        public override void Validate(X509Certificate2 certificate)
        {
            // looks good to me
        }
    }
}
