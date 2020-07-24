using System.ServiceModel;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.Contract2.PubSub;
using SwqlStudio.Properties;
using SwqlStudio.Subscriptions;

namespace SwqlStudio
{
    class OrionInfoService : InfoServiceBase
    {
        private readonly bool _isSwisV3;

        public OrionInfoService(string username, string password, bool isSwisV3 = false)
        {
            _isSwisV3 = isSwisV3;
            _endpoint = isSwisV3 ? Settings.Default.OrionV3EndpointPath : Settings.Default.OrionEndpointPath;
            _endpointConfigName = "OrionTcpBinding_InformationServicev2";
            _binding = new NetTcpBinding("TransportMessage");
            _credentials = new UsernameCredentials(username, password);
        }

        public override string ServiceType => string.Format("Orion (v{0})", _isSwisV3 ? 3 : 2);

        public override bool SupportsActiveSubscriber
        {
            get { return Settings.Default.UseActiveSubscriber && _isSwisV3; }
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
