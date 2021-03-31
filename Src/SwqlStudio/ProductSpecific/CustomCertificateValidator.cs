using System;
using System.IdentityModel.Selectors;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Logging;
using SwqlStudio.Properties;

namespace SwqlStudio.ProductSpecific
{
    public class CustomCertificateValidator : X509CertificateValidator
    {
        private static readonly ILogger<CustomCertificateValidator> log = Program.LoggerFactory.CreateLogger<CustomCertificateValidator>();

        public override void Validate(X509Certificate2 certificate)
        {
            log.LogInformation("Allowing certificate {certificate}", certificate);
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
            string subjectName = Settings.Default.CertificateSubjectName;

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
                var subjectName = Settings.Default.CertificateSubjectName;
                var certs = x509Store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, false);
                return certs;
            }
        }
    }
}
