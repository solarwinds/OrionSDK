
using System;
using System.IdentityModel.Selectors;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;

namespace SolarWinds.InformationService.Contract2
{
    [DataContract(Name = "Windows", Namespace = "http://schema.solarwinds.com/2007/08/IS")]
    public class WindowsCredential : ServiceCredentials
    {
        public string Domain { get; set; }

        public string Username { get; set; }

        public SecureString Password { get; private set; }

        public TokenImpersonationLevel ImpersonationLevel { get; set; } = TokenImpersonationLevel.Impersonation;

        public WindowsCredential() : this(string.Empty, string.Empty, string.Empty)
        {

        }

        public WindowsCredential(string username, string password)
        {
            SetUsername(username);
            Password = SecurePassword(password);
        }

        public WindowsCredential(string domain, string username, string password)
        {
            Domain = domain;
            Username = username;
            Password = SecurePassword(password);
        }

        public WindowsCredential(string username, SecureString password)
        {
            SetUsername(username);
            Password = password;
        }

        public WindowsCredential(string domain, string username, SecureString password)
        {
            Domain = domain;
            Username = username;
            Password = password;
        }

        private void SetUsername(string username)
        {
            int index = username.IndexOf('\\');
            if (index < 0 || index == (username.Length - 1))
            {
                Username = username;
            }
            else if (index > 0)
            {
                Domain = username.Substring(0, index);
                Username = username.Substring(index + 1);
            }
        }

        public override CredentialType CredentialType
        {
            get { return CredentialType.Windows; }
        }

        private static SecureString SecurePassword(string password)
        {
            SecureString pass = new SecureString();
            foreach (char c in password)
            {
                pass.AppendChar(c);
            }

            return pass;
        }

        public override void ApplyTo(ChannelFactory channelFactory)
        {
            if (!string.IsNullOrEmpty(Domain))
            {
                channelFactory.Credentials.Windows.ClientCredential.Domain = Domain;
                string host = channelFactory.Endpoint.Address.Uri.Host;
                if (string.IsNullOrEmpty(host) || host.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                    host = Environment.MachineName;

                channelFactory.Endpoint.Address = new EndpointAddress(channelFactory.Endpoint.Address.Uri,
                                                                      new SpnEndpointIdentity("HOST/" + host));
            }

            if (!string.IsNullOrEmpty(Username))
            {
                channelFactory.Credentials.Windows.ClientCredential.UserName = Username;
            }

            if (Password.Length > 0)
                channelFactory.Credentials.Windows.ClientCredential.Password = GetPassword();

            channelFactory.Credentials.Windows.AllowedImpersonationLevel = ImpersonationLevel;
            channelFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;

            X509ChainPolicy chainPolicy = new X509ChainPolicy();
            chainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority | X509VerificationFlags.IgnoreNotTimeValid;

            // Previously, this was calling X509CertificateValidator.CreateChainTrustValidator, but this is not available for .NET Standard and .NET Core.
            // The CreateChainTrustValidator method returned a new ChainTrustValidator.
            // The source for that class has been adapted and included as a private class below.
            // https://github.com/microsoft/referencesource/blob/5697c29004a34d80acdaf5742d7e699022c64ecd/System.IdentityModel/System/IdentityModel/Selectors/X509CertificateValidator.cs#L76 
            channelFactory.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = new ChainTrustValidator(chainPolicy);
        }

        public string GetPassword()
        {
            IntPtr bstr = IntPtr.Zero;
            string insecureString;

            try
            {
                bstr = Marshal.SecureStringToBSTR(Password);
                insecureString = Marshal.PtrToStringBSTR(bstr);
            }
            catch
            {
                insecureString = string.Empty;
            }
            finally
            {
                if (bstr != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(bstr);
                }
            }

            return insecureString;
        }

        protected override void Dispose(bool disposing)
        {
            if (Password != null)
            {
                Password.Dispose();
                Password = null;
            }

            base.Dispose(disposing);
        }

        // Adapted from https://github.com/microsoft/referencesource/blob/5697c29004a34d80acdaf5742d7e699022c64ecd/System.IdentityModel/System/IdentityModel/Selectors/X509CertificateValidator.cs#L188
        // Several simplifications have been made because the constructor parameters are known.
        private class ChainTrustValidator : X509CertificateValidator
        {
            private readonly X509ChainPolicy _chainPolicy;

            public ChainTrustValidator(X509ChainPolicy chainPolicy)
            {
                _chainPolicy = chainPolicy ?? throw new ArgumentNullException(nameof(chainPolicy));
            }

            public override void Validate(X509Certificate2 certificate)
            {
                if (certificate == null)
                {
                    throw new ArgumentNullException(nameof(certificate));
                }

                X509Chain chain = new X509Chain(true)
                {
                    ChainPolicy = _chainPolicy
                };

                if (!chain.Build(certificate))
                {
                    // In the .NET Framework source, this throws a SecurityTokenValidationException instead.
                    throw new InvalidOperationException($"The specific X.509 certificate chain building failed. The certificate that was used ({GetCertificateId(certificate)}) has a trust chain that cannot be verified. Replace the certificate or change the certificateValidationMode. Chain status: {GetChainStatusInformation(chain.ChainStatus)}");
                }
            }

            private static string GetChainStatusInformation(X509ChainStatus[] chainStatus)
            {
                if (chainStatus != null)
                {
                    StringBuilder error = new StringBuilder(128);

                    for (int i = 0; i < chainStatus.Length; ++i)
                    {
                        error.Append(chainStatus[i].StatusInformation);
                        error.Append(" ");
                    }
                    return error.ToString();
                }

                return string.Empty;
            }

            // From https://github.com/microsoft/referencesource/blob/5697c29004a34d80acdaf5742d7e699022c64ecd/System.IdentityModel/System/IdentityModel/SecurityUtils.cs#L152
            private static string GetCertificateId(X509Certificate2 certificate)
            {
                string certificateId = certificate.SubjectName.Name;
                if (string.IsNullOrEmpty(certificateId))
                {
                    certificateId = certificate.Thumbprint;
                }

                return certificateId;
            }
        }
    }
}
