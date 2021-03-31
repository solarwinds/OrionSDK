using System;
using System.Globalization;
using System.ServiceModel.Channels;
using Microsoft.Extensions.Logging;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.Contract2.PubSub;
using SwqlStudio.Properties;
using SwqlStudio.Subscriptions;

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
            if (serverAddress.Contains(":"))
            {
                var parts = serverAddress.Split(':');
                return Uri(parts[0], parts[1]);
            }

            return Uri(serverAddress, Port.ToString(CultureInfo.InvariantCulture));
        }

        private Uri Uri(string serverAddress, string port)
        {
            return new Uri(string.Format("{0}://{1}:{2}/" + _endpoint, _protocolName, serverAddress, port));
        }

        public virtual InfoServiceProxy CreateProxy(string server)
        {
            ILogger<InfoServiceProxy> logger = Program.LoggerFactory.CreateLogger<InfoServiceProxy>();
            return new InfoServiceProxy(logger, Uri(server), Binding, Credentials);
        }

        public virtual bool SupportsActiveSubscriber { get { return false; } }

        public virtual NotificationDeliveryServiceProxy CreateNotificationDeliveryServiceProxy(string server, INotificationSubscriber notificationSubscriber)
        {
            throw new NotSupportedException();
        }
    }
}
