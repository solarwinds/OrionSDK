using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace SwqlStudio.Subscriptions
{
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

        internal void Remove(string subscriptionUri, SubscriberCallback callback)
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
                this.subscriptions.TryRemove(query, out subscription);
                this.Unsubscribe(subscriptionUri);
                subscription.CloseProxy();
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
}