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
            lock (itemsLock)
            {
                return subscriptions.Values.Any(s => s.Id == subscriptionId);
            }
        }

        internal string Register(string query, SubscriberCallback callback,
            Func<ConnectionInfo, string, SubscriptionCallbacks> subscribe)
        {
            SubscriptionCallbacks subscription;
            var normalized = query.ToLower();

            lock (itemsLock)
            {
                if (!subscriptions.TryGetValue(normalized, out subscription))
                {
                    subscription = subscribe(connection, query);
                    subscriptions.Add(normalized, subscription);
                }
            }

            subscription.Add(callback);
            return subscription.Uri;
        }

        internal void Remove(string subscriptionUri, SubscriberCallback callback)
        {
            lock (itemsLock)
            {
                var query = subscriptions.Where(kv => kv.Value.Uri == subscriptionUri)
                    .Select(kv => kv.Key)
                    .FirstOrDefault();

                if (String.IsNullOrEmpty(query))
                    return;

                var subscription = subscriptions[query];
                subscription.Remove(callback);

                if (subscription.Empty)
                {
                    subscriptions.Remove(query);
                    Unsubscribe(subscriptionUri);
                    subscription.CloseProxy();
                }
            }
        }

        private void Unsubscribe(string subscriptionUri)
        {
            if (connection.IsConnected)
                connection.Proxy.Delete(subscriptionUri);
        }

        internal IEnumerable<SubscriberCallback> CallBacks(string subscriptionId)
        {
            lock (itemsLock)
            {
                return subscriptions.Values.Where(v => v.Id == subscriptionId)
                    .SelectMany(kv => kv.Callbacks)
                    .ToList();
            }
        }
    }
}
