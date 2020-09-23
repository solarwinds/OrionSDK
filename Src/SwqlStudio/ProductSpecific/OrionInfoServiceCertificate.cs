using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.Contract2.PubSub;
using SwqlStudio.Properties;
using SwqlStudio.Subscriptions;

namespace SwqlStudio
{
    internal class OrionInfoServiceCertificate : InfoServiceBase
    {
        public OrionInfoServiceCertificate(bool v3 = false)
        {
            _endpoint = v3 ? Settings.Default.OrionV3EndpointPathCertificate : Settings.Default.OrionEndpointPathCertificate;
            _endpointConfigName = "OrionCertificateTcpBinding";
            _binding = new NetTcpBinding("Certificate");
            _credentials = new MyCertificateCredential(Settings.Default.CertificateSubjectName, StoreLocation.LocalMachine, StoreName.My);

            ValidateCert();
        }

        private static void ValidateCert()
        {
            var x509Store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            x509Store.Open(OpenFlags.ReadOnly);
            var subjectName = Settings.Default.CertificateSubjectName;
            var certs = x509Store.Certificates.Find(X509FindType.FindBySubjectName, subjectName, false);
            x509Store.Close();
            if (certs.Count == 0)
            {
                throw new ApplicationException($"No certificate with subject name {subjectName} found.");
            }
            if (certs.Count > 1)
            {
                throw new ApplicationException($"More than one certificate with subject name {subjectName} found.");
            }
            var cert = certs[0];
            if (!cert.HasPrivateKey)
            {
                throw new ApplicationException($"Certificate with subject name {subjectName}");
            }
            try
            {
                var _ = cert.PrivateKey;
            }
            catch (Exception e)
            {
                throw new ApplicationException($"Can't read private key for certificate with subject name {subjectName}. Do you need to run SWQL Studio as Administrator?", e);
            }
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
