using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace SolarWinds.InformationService.Contract2.PubSub
{
    [Obsolete("Subscriptions can be managed using regular queries and CRUD operations on System.Subscription.")]
    [ServiceContract(Name = "PersistentNotificationService", Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
    public interface IPersistentNotificationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="subscriberEndpoint"></param>
        /// <param name="description">Optional parameter: can be null or an empty string.</param>
        /// <param name="tags">Optional parameter: can be null or an empty array of strings.</param>
        /// <returns></returns>
        [OperationContract]
        string Subscribe(string query, string subscriberEndpoint, string description, string[] tags);

        [OperationContract]
        void Unsubscribe(string subscriptionId);


        [OperationContract]
        List<Subscription> GetSubscriptions();


        /// <param name="description">Description to search for</param>
        /// <param name="exactMatch">If FALSE, then the description value must be contained in the subscription's description.</param>
        [OperationContract]
        List<Subscription> GetSubscriptionsByDescription(string description, bool exactMatch);


        [OperationContract]
        List<Subscription> GetSubscriptionsByTag(string tag);

    }
}