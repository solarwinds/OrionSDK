using System;
using System.IdentityModel.Selectors;
using System.Security.Cryptography.X509Certificates;
using SolarWinds.Logging;

namespace SwisPowerShell
{
    public class CustomCertificateValidator : X509CertificateValidator
    {
        private const string subjectName = "SolarWinds-Orion";
        private static readonly Log log = new Log();

        public override void Validate(X509Certificate2 certificate)
        {
            log.InfoFormat("Allowing certificate {0}", certificate);
            X509Certificate2Collection certs = LoadCertificates();
            ValidateCertPresent(certs);
            X509Certificate2 cert = certs[0];
            // dont use the certificate Equals method as stated in the MS Doc.
            bool valid = cert.Thumbprint.Equals(certificate.Thumbprint);

            if (!valid)
            {
                throw new ApplicationException("Certificate didn't match the SWIS service certificate");
            }
        }

        internal static void ValidateCertPresent()
        {
            X509Certificate2Collection certs = LoadCertificates();
            ValidateCertPresent(certs);
        }

        /// <summary>
        /// We ensure the certificate is local SWIS service certificate, we allow this authentication only locally.
        /// </summary>
        private static void ValidateCertPresent(X509Certificate2Collection certs)
        {
            if (certs.Count == 0)
            {
                throw new ApplicationException($"No certificate with subject name {subjectName} found.");
            }
            if (certs.Count > 1)
            {
                throw new ApplicationException($"More than one certificate with subject name {subjectName} found.");
            }

            X509Certificate2 cert = certs[0];
            ValidatePrivateKey(cert, subjectName);
        }

        private static void ValidatePrivateKey(X509Certificate2 cert, string subjectName)
        {
            if (!cert.HasPrivateKey)
            {
                throw new ApplicationException($"Certificate with subject name {subjectName}");
            }

            try
            {
                var _ = cert.PrivateKey;
            }
            catch (Exception e)
            {
                string message = $"Can't read private key for certificate with subject name {subjectName}. Do you need to run SWQL Studio as Administrator?";
                throw new ApplicationException(message, e);
            }
        }

        private static X509Certificate2Collection LoadCertificates()
        {
            using (var x509Store = new X509Store(StoreName.My, StoreLocation.LocalMachine))
            {
                x509Store.Open(OpenFlags.ReadOnly);
                
                var certs = x509Store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, false);
                return certs;
            }
        }
    }
}
