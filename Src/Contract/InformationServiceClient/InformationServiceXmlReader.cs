using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;
using SolarWinds.InformationService.Contract2;
using System.Runtime.Serialization;

namespace SolarWinds.InformationService.InformationServiceClient
{
    public class InformationServiceXmlReader
    {
        private InformationServiceConnection connection;
        private int commandTimeout = 30;

        public InformationServiceXmlReader(InformationServiceConnection connection)
        {
            this.connection = connection;
        }

        public string ApplicationTag { get; set; }

        public XmlDictionaryReader GetXmlData(string statement, PropertyBag parameters)
        {
            QueryXmlRequest queryRequest = new QueryXmlRequest(statement, parameters);

            Message message = null;

            using (new SwisSettingsContext { DataProviderTimeout = TimeSpan.FromSeconds(commandTimeout), ApplicationTag = ApplicationTag })
            {
                message = this.connection.Service.Query(queryRequest);
            }

            if (message != null)
            {
                if (message.IsFault)
                    CreateFaultException(message);

                return message.GetReaderAtBodyContents();
            }
            return null;
        }

        private static void CreateFaultException(Message message)
        {
            //TODO: Get the maxFaultSize from somewhere other than a hardcoded version.
            MessageFault messageFault = MessageFault.CreateFault(message, 0x10000);
            XmlDictionaryReader reader = messageFault.GetReaderAtDetailContents();

            DataContractSerializer serializer = new DataContractSerializer(typeof(InfoServiceFaultContract));
            InfoServiceFaultContract faultContract = (InfoServiceFaultContract)serializer.ReadObject(reader);

            throw new FaultException<InfoServiceFaultContract>(faultContract, messageFault.Reason, messageFault.Code, message.Headers.Action);
        }
    }
}
