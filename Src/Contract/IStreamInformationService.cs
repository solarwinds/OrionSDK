using System.IO;
using System.ServiceModel;
using System.Xml;
using SolarWinds.InformationService.Contract2.Internationalization;

namespace SolarWinds.InformationService.Contract2
{
    [ServiceContract(Name = "InformationService", Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
    [I18nHeader]
    [SwisSettings]
    [SwisProtocolVersion]
    public interface IStreamInformationService : IInformationService
    {
        [OperationContract(Name = "StreamedInvoke",
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/Streamed/Invoke",
            ReplyAction = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/Streamed/InvokeResponse")]
        [FaultContract(typeof(InfoServiceFaultContract), Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/InvokeInfoServiceFaultContractFault",
            Name = "InformationServiceFaultContract")]
        VerbInvokeResponse StreamedInvoke(VerbInvokeArguments parameter);
    }

    public interface IStreamInformationServiceChannel : IStreamInformationService, IClientChannel
    {
    }

    [MessageContract(WrapperName = "VerbInvokeArguments", WrapperNamespace = "http://schemas.solarwinds.com/2007/08/informationservice", IsWrapped = true)]
    public class VerbInvokeArguments
    {
        [MessageHeader(Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
        public string Entity { get; set; }

        [MessageHeader(Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
        public string Verb { get; set; }

        [MessageHeader(Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
        public XmlElement[] Parameters { get; set; }

        [MessageBodyMember(Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
        public Stream Content { get; set; }
    }

    [MessageContract(WrapperName = "VerbInvokeResponse", WrapperNamespace = "http://schemas.solarwinds.com/2007/08/informationservice", IsWrapped = true)]
    public class VerbInvokeResponse
    {
        [MessageHeader(Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
        public XmlElement Response { get; set; }

        [MessageBodyMember(Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
        public Stream Content { get; set; }
    }
}
