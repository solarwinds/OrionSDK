// Important:
//   This file has a copy that needs to be kept in sync:
//   //depot/Dev/Main/Platform/InformationService/Src/InformationService/Core/ChangeBroker/PubSub/IIndicationReporter.cs

using System.ServiceModel;

namespace SolarWinds.InformationService.Contract2.PubSub
{
    [ServiceContract(Name = "IndicationReporter", Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
    public interface IIndicationReporter
    {
        [OperationContract(IsOneWay = true)]
        void ReportIndication(string indicationType, PropertyBag indicationProperties, PropertyBag sourceInstanceProperties);
    }
}
