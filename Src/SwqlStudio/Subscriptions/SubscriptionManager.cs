using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.Contract2.PubSub;
using SolarWinds.Logging;

namespace SwqlStudio.Subscriptions
{
    public delegate void SubscriberCallback(IndicationEventArgs args);

    public class SubscriptionManager : INotificationSubscriber
    {
        private readonly static Log log = new Log();
        private readonly ConcurrentDictionary<string, SubscriberCallback> subscriptions = new ConcurrentDictionary<string, SubscriberCallback>();
        private readonly ConcurrentDictionary<ConnectionInfo, SubscriptionInfo> proxies = new ConcurrentDictionary<ConnectionInfo, SubscriptionInfo>();
        
        private readonly SubscriptionServiceHost _subscriptionListener;
        private readonly string _activeSubscriberAddress;

        class SubscriptionInfo
        {
            public List<string > SubscriptionIDs { get; } = new List<string>();

            public NotificationDeliveryServiceProxy Proxy { get; set; }
        }

        public SubscriptionManager()
        {
            _subscriptionListener = new SubscriptionServiceHost(this);

            _activeSubscriberAddress = $"active://{Utility.GetFqdn()}/SolarWinds/SwqlStudio/{Process.GetCurrentProcess().Id}";
        }

        public void Unsubscribe(ConnectionInfo connectionInfo, string subscriptionId)
        {
            try
            {
                if (connectionInfo.IsConnected)
                {
                    connectionInfo.Proxy.Delete(subscriptionId);
                }
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                log.Debug($"Unable to unsubscribe {subscriptionId}.  Must have been deleted already", ex);
            }

            SubscriptionInfo subscriptionInfo;
            if (proxies.TryGetValue(connectionInfo, out subscriptionInfo))
            {
                subscriptionInfo.SubscriptionIDs.Remove(subscriptionId);
            }

            var key = GetSubscriptionKeyFromUri(subscriptionId);
            SubscriberCallback callback;
            subscriptions.TryRemove(key, out callback);
        }

        public string CreateSubscription(ConnectionInfo connectionInfo, string subscriptionQuery, SubscriberCallback callback)
        {
            if (!connectionInfo.CanCreateSubscription)
                throw new InvalidOperationException("This connection doesn't support subscriptions");

            SubscriptionInfo subInfo;
            if (!proxies.TryGetValue(connectionInfo, out subInfo))
            {
                var listener = CreateListener(connectionInfo);

                subInfo = new SubscriptionInfo() { Proxy = listener };
                proxies[connectionInfo] = subInfo;
                connectionInfo.ConnectionClosing += ServerConnectionClosing;
            }

            var subscriptionId = Subscribe(connectionInfo, subscriptionQuery);
            subInfo.SubscriptionIDs.Add(subscriptionId);

            var key = GetSubscriptionKeyFromUri(subscriptionId);
            subscriptions.TryAdd(key, callback);

            return subscriptionId;
        }

        private void ServerConnectionClosing(object sender, EventArgs e)
        {
            ConnectionInfo connectionInfo = (ConnectionInfo) sender;

            SubscriptionInfo subscriptionInfo;
            if (proxies.TryRemove(connectionInfo, out subscriptionInfo))
            {
                foreach (var id in subscriptionInfo.SubscriptionIDs.ToList())
                    Unsubscribe(connectionInfo, id);

                if (subscriptionInfo.Proxy != null)
                {
                    subscriptionInfo.Proxy.Disconnect(_activeSubscriberAddress);
                    subscriptionInfo.Proxy.Close();
                }
            }
        }

        private static string GetSubscriptionKeyFromUri(string subscriptionId)
        {
            var key = subscriptionId.Substring(subscriptionId.LastIndexOf("=") + 1);
            return key;
        }

        public void OnIndication(string subscriptionId, string indicationType, PropertyBag indicationProperties,
            PropertyBag sourceInstanceProperties)
        {
            SubscriberCallback targetSubscriber;

            if (subscriptions.TryGetValue(subscriptionId, out targetSubscriber))
            {
                targetSubscriber(new IndicationEventArgs
                {
                    SubscriptionID = subscriptionId
                    ,IndicationType = indicationType
                    ,IndicationProperties = indicationProperties
                    ,SourceInstanceProperties = sourceInstanceProperties
                });
            }
        }

        private string Subscribe(ConnectionInfo connectioninfo, string query)
        {
            var credentialType = connectioninfo.SupportsActiveSubscriptions ? "None" : _subscriptionListener.GetCredentialTypeForBinding(connectioninfo.Binding);

            PropertyBag propertyBag = new PropertyBag
                {
                    {"Query", query},
                    {"EndpointAddress", connectioninfo.SupportsActiveSubscriptions ? _activeSubscriberAddress : _subscriptionListener.GetAddressForBinding(connectioninfo.Binding)},
                    {"Description", "SWQL Studio"},
                    {"DataFormat", "Xml"},
                    {"CredentialType", credentialType}
                };

            propertyBag["Binding"] = connectioninfo.Binding.Scheme.Equals("http") ? "Soap1_1" : "NetTcp";

            if (credentialType.Equals("Username"))
            {
                propertyBag.Add("Username", "subscriber");
                propertyBag.Add("Password", "subscriber");
            }

            return ConnectionInfo.DoWithExceptionTranslation(() => connectioninfo.Proxy.Create("System.Subscription", propertyBag));
        }

        private NotificationDeliveryServiceProxy CreateListener(ConnectionInfo connectionInfo)
        {
            if (connectionInfo.SupportsActiveSubscriptions)
            {
                var proxy = connectionInfo.CreateActiveListenerProxy(this);
                proxy.Open();
                proxy.InnerChannel.Faulted += (x, y) => ChannelFaulted(connectionInfo);
                proxy.InnerChannel.Closed += (x, y) => ChannelClosed(connectionInfo);
                
                proxy.ReceiveIndications(_activeSubscriberAddress);
                return proxy;
            }
            else
            {
                if(!_subscriptionListener.IsListening())
                    _subscriptionListener.OpenSubscriber();
            }

            return null;
        }

        private void ChannelClosed(ConnectionInfo connectionInfo)
        {
            
        }

        private void ChannelFaulted(ConnectionInfo connectionInfo)
        {
            
        }

        public bool IsListening()
        {
            return _subscriptionListener.IsListening();
        }

        public void CloseListeningService()
        {
            _subscriptionListener.CloseSubscriber();
        }

        public void StartListening(Action callback)
        {
            new Task(() =>
            {
                _subscriptionListener.OpenSubscriber();
                callback();
            }).Start();
        }
    }
}
