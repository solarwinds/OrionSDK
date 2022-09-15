using System.ServiceModel;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.Contract2.PubSub;
using SwqlStudio.Properties;
using SwqlStudio.Subscriptions;

namespace SwqlStudio
{
    internal class OrionInfoService : InfoServiceBase
    {
        public OrionInfoService(string username, string password)
        {
            _endpoint = Settings.Default.OrionV3EndpointPath;
            _endpointConfigName = "OrionTcpBinding_InformationServicev2";
            _binding = new NetTcpBinding("TransportMessage");
            _credentials = new UsernameCredentials(username, password);
        }

        public override string ServiceType => "Orion (v3)";

        public override bool SupportsActiveSubscriber
        {
            get { return Settings.Default.UseActiveSubscriber; }
        }

        public override NotificationDeliveryServiceProxy CreateNotificationDeliveryServiceProxy(string server, INotificationSubscriber notificationSubscriber)
        {
            var endpointAddress = new EndpointAddress(string.Format("net.tcp://{0}:17777/SolarWinds/InformationService/v3/Orion/IndicationDelivery", server));
            var context = new InstanceContext(notificationSubscriber);

            var proxy = new NotificationDeliveryServiceProxy(context, (NetTcpBinding)_binding, endpointAddress);
            _credentials.ApplyTo(proxy.ChannelFactory);

            return proxy;
        }
    }
}
