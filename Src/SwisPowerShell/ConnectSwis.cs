using System;
using System.Diagnostics;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using SolarWinds.InformationService.Contract2;

namespace SwisPowerShell
{
    [Cmdlet(VerbsCommunications.Connect, "Swis", DefaultParameterSetName = "Credential")]
    public class ConnectSwis : Cmdlet
    {
        [Parameter(ParameterSetName = "UserName", Mandatory = false, Position = 0, HelpMessage = "UserName for connecting to Orion.")]
        public string UserName { get; set; }

        [Parameter(ParameterSetName = "UserName", Mandatory = false, Position = 1, HelpMessage = "Password for connecting to Orion.")]
        public string Password { get; set; }

        [Parameter(ParameterSetName = "Credential", Mandatory = true, Position = 0, HelpMessage = "Credentials for connecting to Orion.")]
        public PSCredential Credential { get; set; }

        [Parameter(ParameterSetName = "Trusted", Mandatory = true, Position = 0, HelpMessage = "Use the current Windows identity to connect to Orion.")]
        public SwitchParameter Trusted { get; set; }

        [Parameter(ParameterSetName = "Certificate", Mandatory = true, Position = 0, HelpMessage = "Use the CN=SolarWinds-Orion certificate to connect to Orion.")]
        public SwitchParameter Certificate { get; set; }

        [Parameter(ParameterSetName = "Certificate", Mandatory = false, Position = 0, HelpMessage = "Use Streamed endpoint. Streamed transfer is available only for Certificate.")]
        public SwitchParameter Streamed { get; set; }

        [Parameter(HelpMessage = "Connect to the SWISv2 endpoints (default is SWISv3).")]
        public SwitchParameter V2 { get; set; }

        [Parameter(Position = 2, HelpMessage = "Hostname or IP address of the Orion server.")]
        public string Hostname { get; set; }

        [Parameter(ParameterSetName = "UserName", Mandatory = false, HelpMessage = "Url for a SOAP 1.2 SWIS endpoint.")]
        public Uri Soap12 { get; set; }

        [Parameter(ParameterSetName = "UserName", Mandatory = false, HelpMessage = "Ignore SSL/TLS errors with certificate validation when connecting to a SOAP endpoint.")]
        public SwitchParameter IgnoreSslErrors { get; set; }

        [Parameter(ParameterSetName = "UserName", Mandatory = false, HelpMessage = "Trust an SSL/TLS X509 certificate with a specific, known thumbprint.")]
        public string TrustX509Thumbprint { get; set; }

        private bool IsUserNamePresent
        {
            get
            {
                return !string.IsNullOrEmpty(UserName);
            }
        }

        private class EndpointAddresses
        {
            public string activeDirectory;
            public string certificate;
            public string usernamePassword;
        }

        private class V2EndpointAddresses : EndpointAddresses
        {
            public V2EndpointAddresses()
            {
                activeDirectory = "net.tcp://{0}:17777/SolarWinds/InformationService/Orion/ad";
                certificate = "net.tcp://{0}:17777/SolarWinds/InformationService/Orion/certificate";
                usernamePassword = "net.tcp://{0}:17777/SolarWinds/InformationService/Orion/ssl";
            }
        }

        private class V3EndpointAddresses : EndpointAddresses
        {
            public string streamedCertificate = "net.tcp://{0}:17777/SolarWinds/InformationService/v3/Orion/Streamed/Certificate";
            public V3EndpointAddresses()
            {
                activeDirectory = "net.tcp://{0}:17777/SolarWinds/InformationService/v3/Orion/ad";
                certificate = "net.tcp://{0}:17777/SolarWinds/InformationService/v3/Orion/certificate";
                usernamePassword = "net.tcp://{0}:17777/SolarWinds/InformationService/v3/Orion/ssl";
            }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            InfoServiceProxy infoServiceProxy;

            if (Soap12 != null)
            {
                infoServiceProxy = ConnectSoap12(Soap12, UserName, Password);

                if (IgnoreSslErrors)
                {
                    ServicePointManager.ServerCertificateValidationCallback += AllTrustingServerCertificateValidationCallback;
                }
                else if (!string.IsNullOrEmpty(TrustX509Thumbprint))
                {
                    string[] arr = TrustX509Thumbprint.Split('-', ':', ' ');
                    var trustedThumbprint = new byte[arr.Length];
                    for (int i = 0; i < arr.Length; i++)
                        trustedThumbprint[i] = Convert.ToByte(arr[i], 16);

                    ServicePointManager.ServerCertificateValidationCallback += delegate (object sender, X509Certificate certificate, X509Chain chain,
                                                                                       SslPolicyErrors errors)
                        {
                            if (errors == SslPolicyErrors.None)
                                return true;

                            if (certificate.GetCertHash().SequenceEqual(trustedThumbprint))
                                return true;

                            return false;
                        };
                }

            }
            else
                infoServiceProxy = ConnectNetTcp();

            WriteObject(infoServiceProxy);
        }

        private bool AllTrustingServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            Debug.WriteLine("Accepting certificate with thumbprint " + BitConverter.ToString(certificate.GetCertHash()));
            // Looks good to me!
            return true;
        }

        private static InfoServiceProxy ConnectSoap12(Uri address, string username, string password)
        {
            var binding = new WSHttpBinding(SecurityMode.Transport);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
            binding.ReaderQuotas.MaxDepth = 32;
            binding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
            binding.ReaderQuotas.MaxArrayLength = int.MaxValue;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.AllowCookies = true;
            binding.ReaderQuotas.MaxBytesPerRead = 4096;
            binding.ReaderQuotas.MaxNameTableCharCount = 16384;
            binding.UseDefaultWebProxy = true;

            var credentials = new UsernameCredentials(username, password);

            return new InfoServiceProxy(address, binding, credentials);
        }

        private InfoServiceProxy ConnectNetTcp()
        {
            InfoServiceProxy infoServiceProxy;
            EndpointAddresses addresses = V2.IsPresent ? (EndpointAddresses)new V2EndpointAddresses() : new V3EndpointAddresses();

            if (Trusted.IsPresent)
            {
                var binding = new NetTcpBinding { MaxReceivedMessageSize = int.MaxValue, MaxBufferSize = int.MaxValue };
                binding.Security.Mode = SecurityMode.Transport;
                binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;

                var uri = new Uri(string.Format(addresses.activeDirectory, Hostname ?? "localhost"));

                infoServiceProxy = new InfoServiceProxy(uri, binding, new WindowsCredential());
            }
            else if (Certificate.IsPresent)
            {
                var binding = new NetTcpBinding(SecurityMode.Transport) { MaxReceivedMessageSize = int.MaxValue, MaxBufferSize = int.MaxValue };
                binding.Security.Mode = SecurityMode.Transport;
                binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
                binding.ReaderQuotas.MaxArrayLength = int.MaxValue;
                binding.ReaderQuotas.MaxStringContentLength = int.MaxValue;

                if (Streamed.IsPresent)
                {
                    binding.TransferMode = TransferMode.Streamed;
                    binding.PortSharingEnabled = true;
                    binding.ReceiveTimeout = new TimeSpan(15, 0, 0);
                    binding.SendTimeout = new TimeSpan(15, 0, 0);
                }

                var address = (Streamed && !V2.IsPresent)
                                  ? ((V3EndpointAddresses)addresses).streamedCertificate
                                  : addresses.certificate;

                var uri = new Uri(string.Format(address, Hostname ?? "localhost"));

                ServiceCredentials credentials = new MyCertificateCredential("SolarWinds-Orion", StoreLocation.LocalMachine, StoreName.My);

                infoServiceProxy = new InfoServiceProxy(uri, binding, credentials);
            }
            else
            {
                var binding = new NetTcpBinding { MaxReceivedMessageSize = int.MaxValue, MaxBufferSize = int.MaxValue };
                binding.Security.Mode = SecurityMode.TransportWithMessageCredential;
                binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

                var uri = new Uri(string.Format(addresses.usernamePassword, Hostname ?? "localhost"));

                string username = string.Empty;
                string password = string.Empty;

                if (IsUserNamePresent)
                {
                    SecureString securePassword = StringToSecureString(Password);
                    Credential = new PSCredential(UserName, securePassword);
                }

                // the credential dialog adds a slash at the beginning, need to strip
                username = Credential.UserName.TrimStart('\\');
                password = SecureStringToString(Credential.Password);

                var credentials = new UsernameCredentials(username, password);

                infoServiceProxy = new InfoServiceProxy(uri, binding, credentials);
            }
            return infoServiceProxy;
        }

        private static string SecureStringToString(SecureString input)
        {
            IntPtr ptr = SecureStringToBSTR(input);
            return PtrToStringBSTR(ptr);
        }

        private static SecureString StringToSecureString(string input)
        {
            char[] passwordChars = (input ?? string.Empty).ToCharArray();

            SecureString securePassword = new SecureString();

            foreach (char c in passwordChars)
            {
                securePassword.AppendChar(c);
            }

            return securePassword;
        }

        private static IntPtr SecureStringToBSTR(SecureString ss)
        {
            return Marshal.SecureStringToBSTR(ss);
        }

        private static string PtrToStringBSTR(IntPtr ptr)
        {
            string s = Marshal.PtrToStringBSTR(ptr);
            Marshal.ZeroFreeBSTR(ptr);
            return s;
        }

        private class MyCertificateCredential : CertificateCredential
        {
            public MyCertificateCredential(string subjectName, StoreLocation storeLocation, StoreName storeName)
                : base(subjectName, storeLocation, storeName)
            {
            }

            public override void ApplyTo(ChannelFactory channelFactory)
            {
                base.ApplyTo(channelFactory);
                if (channelFactory.Credentials != null)
                {
                    channelFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
                    channelFactory.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = new CustomCertificateValidator();
                }
            }
        }

        private class CustomCertificateValidator : X509CertificateValidator
        {
            public override void Validate(X509Certificate2 certificate)
            {
            }
        }
    }
}
