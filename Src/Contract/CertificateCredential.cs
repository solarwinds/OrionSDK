using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace SolarWinds.InformationService.Contract2
{
    [DataContract(Name="Certificate", Namespace = "http://schema.solarwinds.com/2007/08/IS")]
    public class CertificateCredential : ServiceCredentials
    {
        [DataMember(Name="Subject", Order=1, IsRequired = true)]
        private string _subject;

        [DataMember(Name = "StoreLocation", Order = 1, IsRequired = true)]
        private StoreLocation _storeLocation;

        [DataMember(Name = "StoreName", Order = 1, IsRequired = true)]
        private StoreName _storeName;

        public override CredentialType CredentialType
        {
            get { return CredentialType.Certificate; }
        }

        public string Subject
        {
            get { return _subject; }
        }

        public StoreLocation StoreLocation
        {
            get { return _storeLocation; }
        }

        public StoreName StoreName
        {
            get { return _storeName; }
        }

        public CertificateCredential(string subjectName, StoreLocation storeLocation, StoreName storeName)
        {
            _subject = subjectName;
            _storeLocation = storeLocation;
            _storeName = storeName;
        }
        
        public override void ApplyTo(ChannelFactory channelFactory)
        {
            channelFactory.Credentials.ClientCertificate.SetCertificate(_storeLocation, _storeName, X509FindType.FindBySubjectName, _subject);
            channelFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust;
            channelFactory.Credentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.Offline;

            channelFactory.Endpoint.Address = new EndpointAddress(channelFactory.Endpoint.Address.Uri, EndpointIdentity.CreateDnsIdentity(_subject));
        }
    }
}