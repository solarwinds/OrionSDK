// Important:
//   This file has a copy that needs to be kept in sync:
//   //depot/Dev/Main/Platform/InformationService/Src/InformationService/Core/ChangeBroker/PubSub/INotificationSubscriber.cs

using System.ServiceModel;

namespace SolarWinds.InformationService.Contract2.PubSub
{
    [ServiceContract(Name = "NotificationSubscriber", Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
    public interface INotificationSubscriber
    {
        [OperationContract(IsOneWay = true)]
        void OnIndication(string subscriptionId, string indicationType, PropertyBag indicationProperties, PropertyBag sourceInstanceProperties);
    }
}
