using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using SwqlStudio.Utils;

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

            var ret = AskUserOnUiThread(sslpolicyerrors);

            lock (_certificateAccepted)
            {
                if (thumbprint != null && ret)
                {
                    _certificateAccepted[thumbprint] = true;
                }
            }

            return ret;
        }

        private static bool AskUserOnUiThread(SslPolicyErrors sslPolicyErrors)
        {
            // The certificate callback fires on a background thread; marshal to the UI thread
            // so the dialog has a proper parent and doesn't appear behind other windows.
            var owner = Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null;

            // flash window as the user may be in an external browser and not see the dialog
            if (owner != null)
            {
                Win32.FlashUntilForeground(owner);
                owner.Activate();
            }

            bool Ask() => DialogResult.Yes == MessageBox.Show(owner,
                "Server certificate has problem " + sslPolicyErrors + ". Connect anyway?",
                "SSL Certificate Issue", MessageBoxButtons.YesNo);

            if (owner != null && owner.InvokeRequired)
                return (bool)owner.Invoke((Func<bool>)Ask);

            return Ask();
        }

    }
}
