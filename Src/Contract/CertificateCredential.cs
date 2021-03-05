using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace SolarWinds.InformationService.Contract2
{
    [DataContract(Name = "Certificate", Namespace = "http://schema.solarwinds.com/2007/08/IS")]
    public class CertificateCredential : ServiceCredentials
    {
        public override CredentialType CredentialType
        {
            get { return CredentialType.Certificate; }
        }

        [field: DataMember(Name = "Subject", Order = 1, IsRequired = true)]
        public string Subject { get; }

        [field: DataMember(Name = "StoreLocation", Order = 1, IsRequired = true)]
        public StoreLocation StoreLocation { get; }

        [field: DataMember(Name = "StoreName", Order = 1, IsRequired = true)]
        public StoreName StoreName { get; }

        public CertificateCredential(string subjectName, StoreLocation storeLocation, StoreName storeName)
        {
            Subject = subjectName;
            StoreLocation = storeLocation;
            StoreName = storeName;
        }

        public override void ApplyTo(ChannelFactory channelFactory)
        {
            channelFactory.Credentials.ClientCertificate.SetCertificate(StoreLocation, StoreName, X509FindType.FindBySubjectName, Subject);
            channelFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerOrChainTrust;
            channelFactory.Credentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.Offline;

            channelFactory.Endpoint.Address = new EndpointAddress(channelFactory.Endpoint.Address.Uri, new DnsEndpointIdentity(Subject));
        }
    }
}
