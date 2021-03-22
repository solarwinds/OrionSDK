using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;
using SolarWinds.Logging;

namespace SolarWinds.InformationService.Contract2
{
    public class InformationServiceQuery : IDisposable
    {
        private static readonly Log log = new Log();

        private readonly InformationServiceContext context;
        private readonly string queryString;
        private readonly PropertyBag parameters;

        private OperationContextScope operationContextScope;

        protected bool disposed = false;

        public InformationServiceQuery(InformationServiceContext context, string queryString, PropertyBag parameters)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (queryString == null)
                throw new ArgumentNullException(nameof(queryString));

            this.context = context;
            this.queryString = queryString;
            this.parameters = parameters ?? new PropertyBag();

            if (context.Proxy != null)
                operationContextScope = new OperationContextScope(context.Proxy.ClientChannel);
        }

        public XmlReader Execute()
        {
            return Execute(true);
        }

        public XmlReader Execute(bool hierarchical)
        {
            string returnClause = hierarchical ? " RETURN XML AUTO" : " RETURN XML RAW";

            QueryXmlRequest request = new QueryXmlRequest(queryString + returnClause, parameters);

            Message response = context.Service.Query(request);

            log.Debug(response);

            if (response.IsFault)
            {
                CreateFaultException(response);
            }

            XmlDictionaryReader reader = response.GetReaderAtBodyContents();

            return reader;
        }

        private static void CreateFaultException(Message response)
        {
            //TODO: Get the maxFaultSize from somewhere other than a hardcoded version.
            MessageFault messageFault = MessageFault.CreateFault(response, 0x10000);
            XmlDictionaryReader reader = messageFault.GetReaderAtDetailContents();

            DataContractSerializer serializer = new DataContractSerializer(typeof(InfoServiceFaultContract));
            InfoServiceFaultContract faultContract = (InfoServiceFaultContract)serializer.ReadObject(reader);

            throw new FaultException<InfoServiceFaultContract>(faultContract, messageFault.Reason, messageFault.Code, response.Headers.Action);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (operationContextScope != null)
                    {
                        operationContextScope.Dispose();
                        operationContextScope = null;
                    }
                }

                disposed = true;
            }
        }
    }
}
