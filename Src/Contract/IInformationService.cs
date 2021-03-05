using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;
using SolarWinds.InformationService.Contract2.Internationalization;

namespace SolarWinds.InformationService.Contract2
{
    [ServiceContract(Name = "InformationService", Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
    [I18nHeader]
    [SwisSettings]
    [SwisProtocolVersion]
    public interface IInformationService
    {
        [OperationContract(
            Name = "Invoke",
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/Invoke",
            ReplyAction = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/InvokeResponse")]
        [FaultContract(
            typeof(InfoServiceFaultContract),
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/InvokeInfoServiceFaultContractFault",
            Name = "InformationServiceFaultContract")]
        XmlElement Invoke(string entity, string verb, params XmlElement[] parameters);

        [OperationContract(
            Name = "QueryXml",
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/QueryXml",
            ReplyAction = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/QueryXmlResponse")]
        Message Query(QueryXmlRequest query);

        [OperationContract(
            Name = "Create",
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/Create",
            ReplyAction = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/CreateResponse")]
        [FaultContract(
            typeof(InfoServiceFaultContract),
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/CreateInfoServiceFaultContractFault",
            Name = "InformationServiceFaultContract")]
        string Create(string entityType, PropertyBag properties);

        [OperationContract(
            Name = "Read",
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/Read",
            ReplyAction = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/ReadResponse")]
        [FaultContract(
            typeof(InfoServiceFaultContract),
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/ReadInfoServiceFaultContractFault",
            Name = "InformationServiceFaultContract")]
        PropertyBag Read(string uri);

        [OperationContract(
            Name = "Update",
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/Update",
            ReplyAction = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/UpdateResponse")]
        [FaultContract(
            typeof(InfoServiceFaultContract),
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/UpdateInfoServiceFaultContractFault",
            Name = "InformationServiceFaultContract")]
        void Update(string uri, PropertyBag propertiesToUpdate);

        [OperationContract(
            Name = "BulkUpdate",
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/BulkUpdate",
            ReplyAction = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/BulkUpdateResponse")]
        [FaultContract(
            typeof(InfoServiceFaultContract),
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/BulkUpdateInfoServiceFaultContractFault",
            Name = "InformationServiceFaultContract")]
        void BulkUpdate(string[] uris, PropertyBag propertiesToUpdate);

        [OperationContract(
            Name = "Delete",
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/Delete",
            ReplyAction = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/DeleteResponse")]
        [FaultContract(
            typeof(InfoServiceFaultContract),
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/DeleteInfoServiceFaultContractFault",
            Name = "InformationServiceFaultContract")]
        void Delete(string uri);

        [OperationContract(
            Name = "BulkDelete",
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/BulkDelete",
            ReplyAction = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/BulkDeleteResponse")]
        [FaultContract(
            typeof(InfoServiceFaultContract),
            Action = "http://schemas.solarwinds.com/2007/08/informationservice/InformationService/BulkDeleteInfoServiceFaultContractFault",
            Name = "InformationServiceFaultContract")]
        void BulkDelete(string[] uris);
    }

    public interface IInformationServiceChannel : IInformationService, IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThrough]
    [MessageContract(WrapperName = "QueryXml", WrapperNamespace = "http://schemas.solarwinds.com/2007/08/informationservice", IsWrapped = true)]
    public partial class QueryXmlRequest
    {
        [MessageBodyMember(Namespace = "http://schemas.solarwinds.com/2007/08/informationservice", Order = 0)]
        public string query;

        [MessageBodyMember(Namespace = "http://schemas.solarwinds.com/2007/08/informationservice", Order = 1)]
        public PropertyBag parameters;

        public QueryXmlRequest()
        {
        }

        public QueryXmlRequest(string query)
        {
            this.query = query;
        }

        public QueryXmlRequest(string query, PropertyBag parameters)
        {
            this.query = query;
            this.parameters = parameters;
        }
    }
}
