using System;
using System.Collections.Generic;
using System.Linq;

namespace SwqlStudio.Subscriptions
{
    internal class SubscriptionInfo
    {
        private readonly ConnectionInfo connection;
        private readonly object itemsLock = new object();

        private readonly Dictionary<string, SubscriptionCallbacks> subscriptions =
            new Dictionary<string, SubscriptionCallbacks>();

        internal SubscriptionInfo(ConnectionInfo connection)
        {
            this.connection = connection;
        }

        internal bool HasSubScription(string subscriptionId)
        {
            lock (this.itemsLock)
            {
                return this.subscriptions.Values.Any(s => s.Id == subscriptionId);
            }
        }

        internal string Register(string query, SubscriberCallback callback,
            Func<ConnectionInfo, string, SubscriptionCallbacks> subscribe)
        {
            SubscriptionCallbacks subscription;
            var normalized = query.ToLower();

            lock (this.itemsLock)
            {
                if (!this.subscriptions.TryGetValue(normalized, out subscription))
                {
                    subscription = subscribe(this.connection, query);
                    this.subscriptions.Add(normalized, subscription);
                }
            }

            subscription.Add(callback);
            return subscription.Uri;
        }

        internal void Remove(string subscriptionUri, SubscriberCallback callback)
        {
            lock (this.itemsLock)
            {
                var query = this.subscriptions.Where(kv => kv.Value.Uri == subscriptionUri)
                    .Select(kv => kv.Key)
                    .FirstOrDefault();

                if (String.IsNullOrEmpty(query))
                    return;

                var subscription = this.subscriptions[query];
                subscription.Remove(callback);

                if (subscription.Empty)
                {
                    this.subscriptions.Remove(query);
                    this.Unsubscribe(subscriptionUri);
                    subscription.CloseProxy();
                }
            }
        }

        private void Unsubscribe(string subscriptionUri)
        {
            if (this.connection.IsConnected)
                this.connection.Proxy.Delete(subscriptionUri);
        }

        internal IEnumerable<SubscriberCallback> CallBacks(string subscriptionId)
        {
            lock (this.itemsLock)
            {
                return this.subscriptions.Values.Where(v => v.Id == subscriptionId)
                    .SelectMany(kv => kv.Callbacks)
                    .ToList();
            }
        }
    }
}