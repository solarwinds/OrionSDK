using System.Collections.Generic;
using System.Linq;

namespace SwqlStudio.Subscriptions
{
    internal class SubscriptionCallbacks
    {
        private readonly string activeSubscriberAddress;
        internal string Uri { get; }
        internal string Id { get; set; }

        private readonly NotificationDeliveryServiceProxy proxy;
        private readonly object itemsLock = new object();

        internal IEnumerable<SubscriberCallback> Callbacks
        {
            get
            {
                lock (itemsLock)
                {
                    return new List<SubscriberCallback>(callbacks);
                }
            }
        }

        public bool Empty
        {
            get
            {
                lock (itemsLock)
                {
                    return !callbacks.Any();
                }
            }
        }

        private readonly List<SubscriberCallback> callbacks = new List<SubscriberCallback>();

        public SubscriptionCallbacks(string uri, NotificationDeliveryServiceProxy proxy, string activeSubscriberAddress)
        {
            Uri = uri;
            Id = uri.Substring(uri.LastIndexOf("=") + 1);
            this.proxy = proxy;
            this.activeSubscriberAddress = activeSubscriberAddress;
        }

        internal void Add(SubscriberCallback callback)
        {
            lock (itemsLock)
            {
                if (!callbacks.Contains(callback))
                    callbacks.Add(callback);
            }
        }

        internal void Remove(SubscriberCallback callback)
        {
            lock (itemsLock)
            {
                callbacks.Remove(callback);
            }
        }

        internal void CloseProxy()
        {
            lock (itemsLock)
            {
                if (proxy != null)
                {
                    proxy.Disconnect(activeSubscriberAddress);
                    proxy.Close();
                }
            }
        }
    }
}
