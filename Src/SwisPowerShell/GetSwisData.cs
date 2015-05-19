using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Xml;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.InformationServiceClient;

namespace SwisPowerShell
{
    [Cmdlet(VerbsCommon.Get, "SwisData")]
    public class GetSwisData : BaseSwisCmdlet
    {
        private static readonly string[] returnClauses = new[] { "RETURN XML AUTO", "RETURN XML AUTO STRICT", "RETURN XML RAW" };

        private int timeOut = 30;

        [Parameter(Mandatory = true, Position = 1)]
        public string Query { get; set; }

        [Parameter(Position = 2)]
        public Hashtable Parameters { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Query timeout in seconds", Position = 3)]
        public int TimeOut
        {
            get { return timeOut; }
            set { timeOut = value; }
        }

        protected override IDisposable CreateSwisContext()
        {
            return null;
        }

        protected override void InternalProcessRecord()
        {
            if (returnClauses.Any(s => Query.Trim().EndsWith(s, StringComparison.OrdinalIgnoreCase)))
            {
                using (var connection = new InformationServiceConnection((IInformationService)SwisConnection))
                {
                    InformationServiceXmlReader reader = new InformationServiceXmlReader(connection) {ApplicationTag = "SwisPowerShell"};

                    PropertyBag bag = new PropertyBag();
                    if (Parameters != null)
                    {
                        bag = PropertyBagFromHashtable(Parameters);
                    }
                    XmlDictionaryReader xmlReader = reader.GetXmlData(Query, bag);
                    WriteObject(xmlReader.ReadOuterXml());
                }
            }
            else
                ProcessDataReader();
        }

        private void ProcessDataReader()
        {
            CheckConnection();
            using (var connection = new InformationServiceConnection((IInformationService)SwisConnection))
            {
                connection.Open();
                using (var command = new InformationServiceCommand(Query, connection))
                {
                    command.CommandTimeout = timeOut;
                    command.ApplicationTag = "SwisPowerShell";

                    if (Parameters != null)
                    {
                        foreach (var paramName in Parameters.Keys)
                        {
                            command.Parameters.AddWithValue(paramName.ToString(),
                                                            PropertyBagFromDictionary(Parameters[paramName]));
                        }
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        var factory = new DataReaderObjectFactory(reader);
                        var enumerator = factory.GetEnumerator();
                        while (enumerator.MoveNext())
                            WriteObject(enumerator.Current);
                        
                        if (reader.Errors != null)
                        {
                            StringBuilder sbWarningMessages = new StringBuilder();
                            sbWarningMessages.AppendLine("Warning :: Partial results returned");
                            foreach (var errorMessage in reader.Errors)
                            {
                                sbWarningMessages.AppendLine(string.Format("ErrorType : {0}", errorMessage.ErrorType));
                                sbWarningMessages.AppendLine(string.Format("Context : {0}", errorMessage.Context));
                                sbWarningMessages.AppendLine(string.Format("Message : {0}", errorMessage.Message));
                                sbWarningMessages.AppendLine("-------------------------------------------------");
                            }
                            WriteWarning(sbWarningMessages.ToString());
                        }
                    }
                }
            }
        }
    }
}
