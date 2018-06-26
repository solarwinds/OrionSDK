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

        internal IEnumerable<SubscriberCallback> Callbacks => this.callbacks;
        public bool Empty => !this.callbacks.Any();

        private readonly List<SubscriberCallback> callbacks = new List<SubscriberCallback>();

        public SubscriptionCallbacks(string uri, NotificationDeliveryServiceProxy proxy, string activeSubscriberAddress)
        {
            this.Uri = uri;
            this.Id = uri.Substring(uri.LastIndexOf("=") + 1);
            this.proxy = proxy;
            this.activeSubscriberAddress = activeSubscriberAddress;
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

        internal void CloseProxy()
        {
            if (this.proxy != null)
            {
                this.proxy.Disconnect(this.activeSubscriberAddress);
                this.proxy.Close();
            }
        }
    }
}