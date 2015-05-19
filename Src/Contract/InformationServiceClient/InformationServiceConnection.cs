using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using SolarWinds.InformationService.Contract2;
using System.Data;
using System.ServiceModel;

namespace SolarWinds.InformationService.InformationServiceClient
{
    /// <summary>
    /// Represents a connection to a SolarWinds Information Service
    /// </summary>
    public sealed class InformationServiceConnection : DbConnection
    {
        private string endpointName;
        private string remoteAddress;
        private InfoServiceProxy proxy;
        private ServiceCredentials credentials;
        private bool bProxyOwner = true;
        private IInformationService service;
        private bool open = false;

        public InformationServiceConnection()
            : this(string.Empty)
        {
        }

        public InformationServiceConnection(string endpointName)
        {
            if (endpointName == null)
                throw new ArgumentNullException("endpointName");

            Initialize(endpointName, null, null);
        }

        //This is required by NCM. NCM provide it's own proxy object
        public InformationServiceConnection(InfoServiceProxy proxy) : this(proxy, false)
        {
        }

        public InformationServiceConnection(InfoServiceProxy proxy, bool takeOwnership)
        {
            this.service = proxy;
            bProxyOwner = takeOwnership;
            if (bProxyOwner)
            {
                this.proxy = proxy;
            }
        }

        public InformationServiceConnection(IInformationService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            this.service = service;
            bProxyOwner = false;
        }

        public InformationServiceConnection(string endpointName, string remoteAddress)
        {
            if (endpointName == null)
                throw new ArgumentNullException("endpointName");
            if (remoteAddress == null)
                throw new ArgumentNullException("remoteAddress");

            Initialize(endpointName, remoteAddress, null);
        }

        public InformationServiceConnection(string endpointName, string remoteAddress, ServiceCredentials credentials)
        {
            if (endpointName == null)
                throw new ArgumentNullException("endpointName");
            if (remoteAddress == null)
                throw new ArgumentNullException("remoteAddress");
            if (credentials == null)
                throw new ArgumentNullException("credentials");

            Initialize(endpointName, remoteAddress, credentials);
        }

        public InformationServiceConnection(string endpointName, ServiceCredentials credentials)
        {
            if (endpointName == null)
                throw new ArgumentNullException("endpointName");
            if (credentials == null)
                throw new ArgumentNullException("credentials");

            Initialize(endpointName, null, credentials);
        }

        protected override DbTransaction BeginDbTransaction(System.Data.IsolationLevel isolationLevel)
        {
            throw new NotSupportedException();
        }

        public override void ChangeDatabase(string databaseName)
        {
            throw new NotSupportedException();
        }

        public override void Close()
        {
            if (!bProxyOwner)
                return;
            if (proxy != null)
            {
                try
                {
                    this.proxy.Dispose();
                }
                catch (TimeoutException)
                {
                    this.proxy.Abort();
                }
                catch (CommunicationException)
                {
                    this.proxy.Abort();
                }
            }
            this.proxy = null;
            this.service = null;
            this.open = false;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Close();
            }
            base.Dispose(disposing);
        }

        public override string ConnectionString
        {
            get
            {
                return this.endpointName;
            }
            set
            {
                Initialize(value, this.remoteAddress, this.credentials);
            }
        }

        public ServiceCredentials Credentials
        {
            get
            {
                return this.credentials;
            }
            set
            {
                Initialize(this.endpointName, this.remoteAddress, value);
            }
        }

        public new InformationServiceCommand CreateCommand()
        {
            return new InformationServiceCommand(this);
        }

        protected override DbCommand CreateDbCommand()
        {
            return CreateCommand();
        }

        public override string DataSource
        {
            get
            {
                return string.Empty;
            }
        }

        public override string Database
        {
            get
            {
                return string.Empty;
            }
        }

        public override void Open()
        {
            if (this.proxy == null && this.service != null)
                return; // Must be in-process. Nothing to do for Open().

            if (this.proxy == null && !this.open)
                    CreateProxy();

            if ((this.proxy.Channel != null) && (this.proxy.Channel.State != System.ServiceModel.CommunicationState.Created))
                throw new InvalidOperationException("Cannot open an opened or previously closed connection");

            this.proxy.Open();

            if (this.proxy.Channel.State != System.ServiceModel.CommunicationState.Opened)
                throw new InvalidOperationException("Could not open the connection");

            this.open = true;
        }

        public override string ServerVersion
        {
            get
            {
                return "1.0";
            }
        }

        public override System.Data.ConnectionState State
        {
            get
            {
                if ((this.proxy != null) && (this.proxy.Channel != null) && (this.proxy.Channel.State == System.ServiceModel.CommunicationState.Opened))
                    return ConnectionState.Open;
                else
                    return ConnectionState.Closed;
            }
        }

        private void Initialize(string endpointName, string remoteAddress, ServiceCredentials credentials)
        {
            if ((this.proxy != null) && (this.bProxyOwner != true))
                throw new InvalidOperationException("The Proxy Connection is not owned by InformationServiceConnection object");
            
            if ((this.proxy != null) && (this.proxy.Channel.State != CommunicationState.Created))
                throw new InvalidOperationException("Cannot change the endpoint for an existing connection");

            if (this.proxy != null)
                Close();

            this.endpointName = endpointName;
            this.remoteAddress = remoteAddress;
            this.credentials = credentials;

            CreateProxy();
        }

        private void CreateProxy()
        {
            if (endpointName.Length != 0)
            {
                if (remoteAddress != null)
                {
                    if (credentials != null)
                        this.proxy = new InfoServiceProxy(endpointName, remoteAddress, credentials);
                    else
                        this.proxy = new InfoServiceProxy(endpointName, remoteAddress);
                }
                else
                {
                    if (credentials != null)
                        this.proxy = new InfoServiceProxy(endpointName, credentials);
                    else
                        this.proxy = new InfoServiceProxy(endpointName);
                }

                this.service = this.proxy;
            }
        }

        internal IInformationService Service
        {
            get
            {
                return this.service;
            }
        }
    }
}
