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
        private readonly ConcurrentDictionary<ConnectionInfo, SubscriptionInfo> proxies = new ConcurrentDictionary<ConnectionInfo, SubscriptionInfo>();
        
        private readonly SubscriptionServiceHost _subscriptionListener;
        private readonly string _activeSubscriberAddress;

        internal class SubscriptionCallbacks
        {
            internal string Uri { get; }
            internal string Id { get; set; }

            public NotificationDeliveryServiceProxy Proxy { get; }

            internal IEnumerable<SubscriberCallback> Callbacks => this.callbacks;
            public bool Empty => !this.callbacks.Any();

            private readonly List<SubscriberCallback> callbacks = new List<SubscriberCallback>();

            public SubscriptionCallbacks(string uri, NotificationDeliveryServiceProxy proxy)
            {
                this.Uri = uri;
                this.Id = uri.Substring(uri.LastIndexOf("=") + 1);
                this.Proxy = proxy;
            }

            internal void Add(SubscriberCallback callback)
            {
                if (!this.callbacks.Contains(callback))
                    this.callbacks.Add(callback);
            }

            internal void Remove(SubscriberCallback callback)
            {
                this.callbacks.Remove(callback);
            }
        }

        internal class SubscriptionInfo
        {
            private readonly ConnectionInfo connection;

            private readonly ConcurrentDictionary<string, SubscriptionCallbacks> subscriptions =
                new ConcurrentDictionary<string, SubscriptionCallbacks>();

            internal SubscriptionInfo(ConnectionInfo connection)
            {
                this.connection = connection;
            }

            internal bool HasSubScription(string subscriptionId)
            {
                return this.subscriptions.Values.Any(s => s.Id == subscriptionId);
            }

            internal string Register(string query, SubscriberCallback callback,
                Func<ConnectionInfo, string, SubscriptionCallbacks> subscribe)
            {
                SubscriptionCallbacks subscription;
                var normalized = query.ToLower();

                if (!this.subscriptions.TryGetValue(normalized, out subscription))
                {
                    subscription = subscribe(this.connection, query);
                    this.subscriptions.TryAdd(normalized, subscription);
                }

                subscription.Add(callback);
                return subscription.Uri;
            }

            internal void Remove(string subscriptionUri, SubscriberCallback callback, Action<NotificationDeliveryServiceProxy> closeListener)
            {
                var query = this.subscriptions.Where(kv => kv.Value.Uri == subscriptionUri)
                    .Select(kv => kv.Key)
                    .FirstOrDefault();

                if (string.IsNullOrEmpty(query))
                    return;
                
                var subscription = this.subscriptions[query];
                subscription.Remove(callback);

                if (subscription.Empty)
                {
                    this.subscriptions.TryRemove(query, out subscription);
                    this.Unsubscribe(subscriptionUri);
                    closeListener(subscription.Proxy);
                }
            }

            private void Unsubscribe(string subscriptionUri)
            {
                if (this.connection.IsConnected)
                    this.connection.Proxy.Delete(subscriptionUri);
            }

            internal IEnumerable<SubscriberCallback> CallBacks(string subscriptionId)
            {
                return this.subscriptions.Values.Where(v => v.Id == subscriptionId)
                    .SelectMany(kv => kv.Callbacks)
                    .ToList();
            }
        }

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
                    subscriptionInfo.Remove(subscriptionUri, callback, CloseProxy);
                }
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                log.Debug($"Unable to unsubscribe {subscriptionUri}.  Must have been deleted already", ex);
            }
        }

        private void CloseProxy(NotificationDeliveryServiceProxy proxy)
        {
            if (proxy != null)
            {
                proxy.Disconnect(_activeSubscriberAddress);
                proxy.Close();
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
            return new SubscriptionCallbacks(subscriptionUri, listener);
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
