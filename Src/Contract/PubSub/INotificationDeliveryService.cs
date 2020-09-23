using System.ServiceModel;

namespace SolarWinds.InformationService.Contract2.PubSub
{

    // Important:
    //   This file has a copy that needs to be kept in sync:
    //   //depot/Dev/Main/Platform/InformationService/Src/InformationService/Core/ChangeBroker/PubSub/INotificationDeliveryService.cs


    [ServiceContract(Name = "INotificationDeliveryService",
        Namespace = "http://schemas.solarwinds.com/2007/08/informationservice",
        CallbackContract = typeof(INotificationSubscriber),
        SessionMode = SessionMode.Required)]
    public interface INotificationDeliveryService
    {
        [OperationContract(Name = "ReceiveIndications")]
        void ReceiveIndications(string address);

        [OperationContract(Name = "Disconnect", IsOneWay = true)]
        void Disconnect(string address);
    }
}
