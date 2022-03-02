using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace SolarWinds.InformationService.Contract2
{
    [DataContract(Namespace = "http://schema.solarwinds.com/2007/08/IS")]
    public class UsernameCredentials : ServiceCredentials
    {
        private readonly string _username;
        private readonly string _password;

        public UsernameCredentials(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public override CredentialType CredentialType
        {
            get { return CredentialType.Username; }
        }

        public override void ApplyTo(ChannelFactory channelFactory)
        {
            channelFactory.Endpoint.Address = new EndpointAddress(channelFactory.Endpoint.Address.Uri);

            channelFactory.Credentials.UserName.UserName = _username;
            channelFactory.Credentials.UserName.Password = _password;
            channelFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;

            channelFactory.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = new AllTrustingCertificateValidator();

        }
    }
}
