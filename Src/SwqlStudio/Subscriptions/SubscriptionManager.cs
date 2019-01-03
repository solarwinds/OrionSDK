using System;
using System.Collections.Concurrent;
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
        private readonly ConcurrentDictionary<ConnectionInfo, SubscriptionInfo> proxies = new ConcurrentDictionary<ConnectionInfo, SubscriptionInfo>();
        
        private readonly SubscriptionServiceHost _subscriptionListener;
        private readonly string _activeSubscriberAddress;

        public SubscriptionManager()
        {
            _subscriptionListener = new SubscriptionServiceHost(this);

            _activeSubscriberAddress = $"active://{Utility.GetFqdn()}/SolarWinds/SwqlStudio/{Process.GetCurrentProcess().Id}";
        }

        public void Unsubscribe(ConnectionInfo connectionInfo, string subscriptionUri, SubscriberCallback callback)
        {
            try
            {
                SubscriptionInfo subscriptionInfo;
                if (proxies.TryGetValue(connectionInfo, out subscriptionInfo))
                {
                    subscriptionInfo.Remove(subscriptionUri, callback);
                }
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                log.Debug($"Unable to unsubscribe {subscriptionUri}.  Must have been deleted already", ex);
            }
            catch (CommunicationException ex)
            {
                // also in case connection already disposed
                log.Debug("Unable to unsubscribe due to communication error.", ex);
            }
        }

        public string CreateSubscription(ConnectionInfo connectionInfo, string subscriptionQuery, SubscriberCallback callback)
        {
            if (!connectionInfo.CanCreateSubscription)
                throw new InvalidOperationException("This connection doesn't support subscriptions");

            SubscriptionInfo subInfo;
            if (!proxies.TryGetValue(connectionInfo, out subInfo))
            {
                subInfo = new SubscriptionInfo(connectionInfo);
                proxies[connectionInfo] = subInfo;
                connectionInfo.ConnectionClosing += ServerConnectionClosing;
            }

            return subInfo.Register(subscriptionQuery, callback, Subscribe);
        }

        private void ServerConnectionClosing(object sender, EventArgs e)
        {
            ConnectionInfo connectionInfo = (ConnectionInfo) sender;
            SubscriptionInfo subscriptionInfo;
            proxies.TryRemove(connectionInfo, out subscriptionInfo);
        }

        public void OnIndication(string subscriptionId, string indicationType, PropertyBag indicationProperties,
            PropertyBag sourceInstanceProperties)
        {
            var targetSubscribers = this.proxies.Values
                .Where(p => p.HasSubScription(subscriptionId))
                .SelectMany(p => p.CallBacks(subscriptionId))
                .ToList();

            foreach (var callback in targetSubscribers)
            {
                callback(new IndicationEventArgs
                {
                    SubscriptionID = subscriptionId
                    ,IndicationType = indicationType
                    ,IndicationProperties = indicationProperties
                    ,SourceInstanceProperties = sourceInstanceProperties
                });
            }
        }

        private SubscriptionCallbacks Subscribe(ConnectionInfo connectioninfo, string query)
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

            var subscriptionUri = ConnectionInfo.DoWithExceptionTranslation(() => connectioninfo.Proxy.Create("System.Subscription", propertyBag));
            var listener = CreateListener(connectioninfo);
            return new SubscriptionCallbacks(subscriptionUri, listener, _activeSubscriberAddress);
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
