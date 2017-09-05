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

        public InformationServiceQuery(InformationServiceContext context, string queryString)
            : this(context, queryString, null)
        {
        }

        public InformationServiceQuery(InformationServiceContext context, string queryString, PropertyBag parameters)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (queryString == null)
                throw new ArgumentNullException("queryString");

            this.context = context;
            this.queryString = queryString;
            this.parameters = parameters ?? new PropertyBag();

            if (context.Proxy != null)
                this.operationContextScope = new OperationContextScope(context.Proxy.ClientChannel);
        }

        public XmlReader Execute()
        {
            return Execute(true);
        }

        public XmlReader Execute(bool hierarchical)
        {
            string returnClause = hierarchical ? " RETURN XML AUTO" : " RETURN XML RAW";

            QueryXmlRequest request = new QueryXmlRequest(this.queryString + returnClause, parameters);

            Message response = this.context.Service.Query(request);

            log.DebugFormat("{0}", response);

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
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.operationContextScope != null)
                    {
                        this.operationContextScope.Dispose();
                        this.operationContextScope = null;
                    }
                }

                this.disposed = true;
            }
        }
    }
}
