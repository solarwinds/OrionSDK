
using System;
using System.IdentityModel.Selectors;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Security;

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
            // TODO - this is missing from .net standard, but it may not be possible to do Windows auth safely without it
            //channelFactory.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = X509CertificateValidator.CreateChainTrustValidator(true, chainPolicy);
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
    }
}
