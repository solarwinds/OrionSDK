
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
        private String _domain;
        private String _username;
        private SecureString _password;
        private TokenImpersonationLevel _tokenImpersonationLevel = TokenImpersonationLevel.Impersonation;

        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public SecureString Password
        {
            get { return _password; }
        }
        
        public TokenImpersonationLevel ImpersonationLevel
        {
            get { return _tokenImpersonationLevel; }
            set { _tokenImpersonationLevel = value; }
        }

        public WindowsCredential():this(String.Empty, String.Empty, String.Empty)
        {

        }
        
        public WindowsCredential(string username, string password)
        {
            SetUsername(username);
            _password = SecurePassword(password);
        }

        public WindowsCredential(string domain, string username, string password)
        {
            _domain = domain;
            _username = username;
            _password = SecurePassword(password);
        }

        public WindowsCredential(String username, SecureString password)
        {
            SetUsername(username);
            _password = password;
        }

        public WindowsCredential(String domain, String username, SecureString password)
        {
            _domain = domain;
            _username = username;
            _password = password;
        }

        private void SetUsername(string username)
        {
            int index = username.IndexOf('\\');
            if(index < 0 || index == (username.Length - 1))
            {
                _username = username;
            }
            else if(index > 0)
            {
                _domain = username.Substring(0, index);
                _username = username.Substring(index + 1);
            }
        }

        public override CredentialType CredentialType
        {
            get { return CredentialType.Windows; }
        }

        private static SecureString SecurePassword(String password)
        {
            SecureString pass = new SecureString();
            foreach(char c in password)
            {
                pass.AppendChar(c);
            }

            return pass;
        }
        
        public override void ApplyTo(ChannelFactory channelFactory)
        {
            if (!String.IsNullOrEmpty(Domain))
            {
                channelFactory.Credentials.Windows.ClientCredential.Domain = Domain;
                string host = channelFactory.Endpoint.Address.Uri.Host;
                if (String.IsNullOrEmpty(host) || host.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                    host = Environment.MachineName;

                //channelFactory.Endpoint.Address = new EndpointAddress(channelFactory.Endpoint.Address.Uri,
                //                                                      EndpointIdentity.CreateSpnIdentity("HOST/" + host));
            }

            if (!String.IsNullOrEmpty(Username))
            {
                channelFactory.Credentials.Windows.ClientCredential.UserName = Username;
            }

            if (_password.Length > 0)
                channelFactory.Credentials.Windows.ClientCredential.Password = GetPassword();

            channelFactory.Credentials.Windows.AllowedImpersonationLevel = _tokenImpersonationLevel;
            channelFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;

            //X509ChainPolicy chainPolicy = new X509ChainPolicy();
            //chainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority | X509VerificationFlags.IgnoreNotTimeValid;
            //channelFactory.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = X509CertificateValidator.CreateChainTrustValidator(true, chainPolicy);
        }

        public string GetPassword()
        {
            IntPtr bstr = IntPtr.Zero;
            string insecureString;

            try
            {
                bstr = Marshal.SecureStringToBSTR(_password);
                insecureString = Marshal.PtrToStringBSTR(bstr);
            }
            catch
            {
                insecureString = String.Empty;
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
            if(_password != null)
            {
                _password.Dispose();
                _password = null;
            }

            base.Dispose(disposing);
        }
    }
}
