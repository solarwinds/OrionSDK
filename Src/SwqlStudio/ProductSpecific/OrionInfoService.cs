using System.ServiceModel;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.Contract2.PubSub;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    class OrionInfoService : InfoServiceBase
    {
        private readonly bool _v3;

        public OrionInfoService(string username, string password, bool v3 = false)
        {
            _v3 = v3;
            _endpoint = v3 ? Settings.Default.OrionV3EndpointPath : Settings.Default.OrionEndpointPath;
            _endpointConfigName = "OrionTcpBinding_InformationServicev2";
            _binding = new NetTcpBinding("TransportMessage");
            _credentials = new UsernameCredentials(username, password);
        }

        public override string ServiceType
        {
            get { return "Orion"; }
        }

        public override bool SupportsActiveSubscriber
        {
            get { return _v3; }
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
