using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.Contract2.PubSub;
using SwqlStudio.ProductSpecific;
using SwqlStudio.Properties;
using SwqlStudio.Subscriptions;

namespace SwqlStudio
{
    internal class OrionInfoServiceCertificate : InfoServiceBase
    {
        public OrionInfoServiceCertificate()
        {
            _endpoint = Settings.Default.OrionV3EndpointPathCertificate;
            _endpointConfigName = "OrionCertificateTcpBinding";
            _binding = new NetTcpBinding("Certificate");
            _credentials = new MyCertificateCredential(Settings.Default.CertificateSubjectName,
                StoreLocation.LocalMachine, StoreName.My);

            // call here before the service is connected, because otherwise the message cant be delivered to the UI.
            CustomCertificateValidator.ValidateCertPresent();
        }

        private class MyCertificateCredential : CertificateCredential
        {
            public MyCertificateCredential(string subjectName, StoreLocation storeLocation, StoreName storeName) : base(subjectName, storeLocation, storeName)
            {
            }

            public override void ApplyTo(ChannelFactory channelFactory)
            {
                base.ApplyTo(channelFactory);
                channelFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
                channelFactory.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = new CustomCertificateValidator();
            }
        }

        public override string ServiceType => "Orion Certificate";

        public override bool SupportsActiveSubscriber => Settings.Default.UseActiveSubscriber;

        public override NotificationDeliveryServiceProxy CreateNotificationDeliveryServiceProxy(string server, INotificationSubscriber notificationSubscriber)
        {
            var endpointAddress = new EndpointAddress(string.Format("net.tcp://{0}:17777/SolarWinds/InformationService/v3/Orion/IndicationDelivery/certificate", server));
            var context = new InstanceContext(notificationSubscriber);

            var proxy = new NotificationDeliveryServiceProxy(context, (NetTcpBinding)_binding, endpointAddress);
            _credentials.ApplyTo(proxy.ChannelFactory);

            return proxy;
        }
    }
}
