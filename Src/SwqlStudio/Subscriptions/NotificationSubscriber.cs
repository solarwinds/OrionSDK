using System;
using System.ServiceModel;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.Contract2.PubSub;

namespace SwqlStudio.Subscriptions
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        UseSynchronizationContext = false)]
    class NotificationSubscriber : INotificationSubscriber
    {
        public event Action<string, string, PropertyBag, PropertyBag> IndicationReceived;

        public NotificationSubscriber()
        {
        }

        public void OnIndication(string subscriptionId, string indicationType, PropertyBag indicationProperties,
                                 PropertyBag sourceInstanceProperties)
        {
            Action<string, string, PropertyBag, PropertyBag> listeners = IndicationReceived;
            if (listeners != null)
            {
                listeners(subscriptionId, indicationType, indicationProperties, sourceInstanceProperties);
            }
        }
    }
}
