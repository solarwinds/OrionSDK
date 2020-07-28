using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;
using SolarWinds.InformationService.Contract2;

namespace SolarWinds.InformationService.InformationServiceClient
{
    /// <summary>
    /// Represents a SWQL statement to execute against a SolarWinds Information Service.
    /// </summary>
    public sealed class InformationServiceCommand : DbCommand
    {
        private string statement;
        private InformationServiceConnection connection;
        private bool designTimeVisible = true;
        private CommandType commandType = CommandType.Text;

        internal InformationServiceCommand(InformationServiceConnection connection)
            : this(string.Empty, connection)
        {

        }

        public InformationServiceCommand(string statement)
        {
            if (statement == null)
                throw new ArgumentNullException("statement");

            this.statement = statement;
        }

        public InformationServiceCommand(string statement, InformationServiceConnection connection)
            : this(statement)
        {
            this.connection = connection;
        }

        public override void Cancel()
        {
            // Does nothing
        }

        public override string CommandText
        {
            get
            {
                return (this.statement ?? string.Empty);
            }
            set
            {
                this.statement = value;
            }
        }

        public override int CommandTimeout { get; set; } = 30;

        public override System.Data.CommandType CommandType
        {
            get
            {
                return this.commandType;
            }
            set
            {
                if (value != CommandType.Text)
                    throw new NotSupportedException("InformationServiceCommand only support commands of type Text");
                this.commandType = value;
            }
        }

        protected override DbParameter CreateDbParameter()
        {
            return new InformationServiceParameter();
        }

        protected override DbConnection DbConnection
        {
            get
            {
                return this.connection;
            }
            set
            {
                this.connection = (InformationServiceConnection)value;
            }
        }

        protected override DbParameterCollection DbParameterCollection
        {
            get { return Parameters; }
        }

        public new InformationServiceParameterCollection Parameters { get; } = new InformationServiceParameterCollection();

        protected override DbTransaction DbTransaction
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotSupportedException("Transactions are not supported");
            }
        }

        public override bool DesignTimeVisible
        {
            get
            {
                return this.designTimeVisible;
            }
            set
            {
                this.designTimeVisible = value;
                TypeDescriptor.Refresh(this);
            }
        }

        protected override DbDataReader ExecuteDbDataReader(System.Data.CommandBehavior behavior)
        {
            return this.ExecuteReader(behavior);
        }

        public override int ExecuteNonQuery()
        {
            throw new NotSupportedException();
        }

        public override object ExecuteScalar()
        {
            throw new NotSupportedException();
        }

        public override void Prepare()
        {
        }

        public override UpdateRowSource UpdatedRowSource
        {
            get
            {
                return UpdateRowSource.None;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public string ApplicationTag { get; set; }

        /// <summary>
        /// Specify expected DateTime.Kind for DateTime values. Default behavior is DataSetDateTime.Unspecified 
        /// and we return raw pure DateTime based on query you used.
        /// </summary>
        public DataSetDateTime DateTimeMode { get; set; } = DataSetDateTime.Unspecified;

        public new InformationServiceDataReader ExecuteReader()
        {
            return ExecuteReader(CommandBehavior.Default);
        }

        public new InformationServiceDataReader ExecuteReader(CommandBehavior behavior)
        {
            //TODO: Check if the statement contains a RETURN clause
            string query = statement + " RETURN XML RAW";

            var bag = new PropertyBag();
            foreach (InformationServiceParameter parameter in Parameters)
                bag.Add(parameter.ParameterName, parameter.Value);

            QueryXmlRequest queryRequest = new QueryXmlRequest(query, bag);

            Message message = null;

            using (new SwisSettingsContext { DataProviderTimeout = TimeSpan.FromSeconds(CommandTimeout), ApplicationTag = ApplicationTag, AppendErrors = true })
            {
                message = this.connection.Service.Query(queryRequest);
            }

            if (message != null)
            {
                if (message.IsFault)
                    CreateFaultException(message);

                return new InformationServiceDataReader(this, message.GetReaderAtBodyContents(), this.DateTimeMode);
            }
            return null;
        }

        //TODO: Need to refactor with the code already present in InformationServiceQuery
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
