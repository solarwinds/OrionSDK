using System;
using System.ServiceModel.Channels;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.Contract2.PubSub;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    internal abstract class InfoServiceBase
    {
        protected ServiceCredentials _credentials;
        protected Binding _binding;
        protected string _endpoint;
        protected string _endpointConfigName;
        protected string _protocolName = "net.tcp";

        public abstract string ServiceType { get; }

        public ServiceCredentials Credentials
        {
            get { return _credentials; }
        }

        public Binding Binding
        {
            get { return _binding; }
        }

        public string Endpoint
        {
            get { return _endpoint; }
        }

        public string EndpointConfigurationName
        {
            get { return _endpointConfigName; }
        }

        protected virtual int Port
        {
            get { return Settings.Default.DefaultInfoServicePort; }
        }

        public virtual Uri Uri(string serverAddress)
        {
            Uri uri = new Uri(String.Format("{0}://{1}:{2}/" + _endpoint, _protocolName, serverAddress, Port));
            return uri;
        }

        public virtual InfoServiceProxy CreateProxy(string server)
        {
            return new InfoServiceProxy(Uri(server), Binding, Credentials);
        }

        public virtual bool SupportsActiveSubscriber { get { return false; } }

        public virtual NotificationDeliveryServiceProxy CreateNotificationDeliveryServiceProxy(string server, INotificationSubscriber notificationSubscriber)
        {
            throw new NotSupportedException();
        }
    }
}