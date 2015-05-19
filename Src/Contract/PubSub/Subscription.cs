using System;
using System.Runtime.Serialization;

namespace SolarWinds.InformationService.Contract2.PubSub
{
    [Obsolete("Subscriptions can be managed using regular queries and CRUD operations on System.Subscription.")]
    [Serializable]
    [DataContract(Name = "Subscription", Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
    public class Subscription
    {
        [DataMember(Name = "Id", Order = 1, IsRequired = true)]
        public Guid Id { get; set; }
        [DataMember(Name = "EndpointAddress", Order = 2, IsRequired = true)]
        public string EndpointAddress { get; set; }
        [DataMember(Name = "Query", Order = 3, IsRequired = true)]
        public string Query { get; set; }
        [DataMember(Name = "LastSuccessfulDelivery", Order = 4, IsRequired = true)]
        public DateTime? LastSuccessfulDelivery { get; set; }
        [DataMember(Name = "FailedDeliveryAttempts", Order = 5, IsRequired = true)]
        public int FailedDeliveryAttempts { get; set; }
        [DataMember(Name = "Description", Order = 6, IsRequired = true)]
        public string Description { get; set; }
    }
}
