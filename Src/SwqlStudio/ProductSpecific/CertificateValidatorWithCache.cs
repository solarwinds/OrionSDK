using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace SwqlStudio
{
    internal static class CertificateValidatorWithCache
    {
        // cache positive answers for thumbprints (otherwise, each request fires msgbox)
        private static readonly Dictionary<string, bool> _certificateAccepted = new Dictionary<string, bool>();


        public static bool ValidateRemoteCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
        {
            var thumbprint = (certificate as X509Certificate2)?.Thumbprint;
            lock (_certificateAccepted)
            {
                if (thumbprint != null &&
                    _certificateAccepted.TryGetValue(thumbprint, out var accepted) &&
                    accepted)
                {
                    return true;
                }
            }

            var ret = (DialogResult.Yes ==
                MessageBox.Show("Server certificate has problem " + sslpolicyerrors + ". Connect anyway?",
                    "SSL Certificate Issue", MessageBoxButtons.YesNo));

            lock (_certificateAccepted)
            {
                if (thumbprint != null && ret)
                {
                    _certificateAccepted[thumbprint] = true;
                }
            }

            return ret;
        }

    }
}
