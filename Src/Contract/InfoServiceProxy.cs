using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;
using SolarWinds.InformationService.Contract2.Bindings;
using SolarWinds.Logging;

namespace SolarWinds.InformationService.Contract2
{
    public class InfoServiceProxy : IStreamInformationService,  IDisposable
    {
        private readonly static Log _log = new Log();
        private static readonly TimeSpan longRunningQueryTime = TimeSpan.FromSeconds(15);

        private ChannelFactory<IStreamInformationServiceChannel> _channelFactory;
        private IStreamInformationServiceChannel _infoService;
        private TimeSpan _operationTimeout = TimeSpan.FromMinutes(60);

        private InfoServiceActivityMonitor _activityMonitor = null;

        public TimeSpan OperationTimeout
        {
            get { return _operationTimeout; }

            set { _operationTimeout = value; }
        }

        public IChannel Channel
        {
            get { return _infoService; }
        }

        public IClientChannel ClientChannel
        {
            get
            {
                return _infoService;
            }
        }

        public ChannelFactory<IStreamInformationServiceChannel> ChannelFactory
        {
            get { return _channelFactory; }
        }

        #region Constructors

        public InfoServiceProxy(string endpointConfiguration)
        {
            if (endpointConfiguration == null)
                throw new ArgumentNullException("endpointConfiguration");

            _channelFactory = CreateChannelFactory(endpointConfiguration);

            FixBinding();
        }

        public InfoServiceProxy(string endpointConfiguration, ServiceCredentials credentials)
            : this(endpointConfiguration)
        {
            if (credentials == null)
                throw new ArgumentNullException("credentials");

            credentials.ApplyTo(_channelFactory);
        }

        public InfoServiceProxy(string endpointConfiguration, string remoteAddress)
        {
            if (endpointConfiguration == null)
                throw new ArgumentNullException("endpointConfiguration");

            if (remoteAddress == null)
                throw new ArgumentNullException("remoteAddress");

            _channelFactory = CreateChannelFactory(endpointConfiguration, new EndpointAddress(remoteAddress));

            FixBinding();
        }

        public InfoServiceProxy(string endpointConfiguration, string remoteAddress, ServiceCredentials credentials)
            : this(endpointConfiguration, remoteAddress)
        {
            if (credentials == null)
                throw new ArgumentNullException("credentials");

            credentials.ApplyTo(_channelFactory);
        }

        public InfoServiceProxy(Uri address)
        {
            if (address == null)
                throw new ArgumentNullException("address");

            NetTcpBinding binding = new NetTcpBinding(SecurityMode.Transport);
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;

            Initialize(new EndpointAddress(address), binding, new WindowsCredential());
        }

        public InfoServiceProxy(Uri address, Binding binding, ServiceCredentials credentials)
        {
            if (address == null)
                throw new ArgumentNullException("address");

            Initialize(new EndpointAddress(address), binding, credentials);
        }

        public InfoServiceProxy(EndpointAddress address, Binding binding, ServiceCredentials credentials)
        {
            Initialize(address, binding, credentials);
        }

        #endregion

        private void FixBinding()
        {
            BindingElementCollection elements = _channelFactory.Endpoint.Binding.CreateBindingElements();
            SslStreamSecurityBindingElement element = elements.Find<SslStreamSecurityBindingElement>();
            if (element != null)
            {
                element.IdentityVerifier = new SWIdentityVerifier();

                CustomBinding newbinding = new CustomBinding(elements);

                // Transfer timeout settings from the old binding to the new
                Binding binding = _channelFactory.Endpoint.Binding;
                newbinding.CloseTimeout = binding.CloseTimeout;
                newbinding.OpenTimeout = binding.OpenTimeout;
                newbinding.ReceiveTimeout = binding.ReceiveTimeout;
                newbinding.SendTimeout = binding.SendTimeout;

                _channelFactory.Endpoint.Binding = newbinding;
            }

            CorrectChannelFactory();
        }

        private void Initialize(EndpointAddress address, Binding binding, ServiceCredentials credentials)
        {
            if (address == null)
                throw new ArgumentNullException("address");

            if (credentials == null)
                throw new ArgumentNullException("credentials");

            if (binding == null)
                throw new ArgumentNullException("binding");


            BindingElementCollection elements = binding.CreateBindingElements();
            SslStreamSecurityBindingElement element = elements.Find<SslStreamSecurityBindingElement>();
            if (element != null)
            {
                element.IdentityVerifier = new SWIdentityVerifier();

                CustomBinding newbinding = new CustomBinding(elements);

                // Transfer timeout settings from the old binding to the new
                newbinding.CloseTimeout = binding.CloseTimeout;
                newbinding.OpenTimeout = binding.OpenTimeout;
                newbinding.ReceiveTimeout = binding.ReceiveTimeout;
                newbinding.SendTimeout = binding.SendTimeout;
                binding = newbinding;
            }

            _channelFactory = CreateChannelFactory(binding, address);
            credentials.ApplyTo(_channelFactory);

            CorrectChannelFactory();
        }

        private void CorrectChannelFactory()
        {
            // ???: how can I detect that channel binding is securited            

            _activityMonitor = new InfoServiceActivityMonitor();
            _channelFactory.Endpoint.Behaviors.Add(_activityMonitor);
        }

        #region IInfoService Members

        public virtual XmlElement Invoke(string entity, string verb, params XmlElement[] parameters)
        {
            var stopwatch = new Stopwatch();
            try
            {
                if (_infoService == null)
                {
                    Open();
                }
                stopwatch.Start();
                return _infoService.Invoke(entity, verb, parameters);
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                _log.Error("Error executing invoke: " + ex.Detail.Message + Environment.NewLine + entity + "." + verb);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                if (stopwatch.Elapsed > longRunningQueryTime)
                {
                    _log.WarnFormat("Support! -- LONG RUNNING INVOKE: {0} ms: {1}:{2}", stopwatch.Elapsed.TotalMilliseconds, verb, entity);
                }
            }
        }

        public virtual Message Query(QueryXmlRequest query)
        {
            _log.DebugFormat("Query: {0}", query.query);
            if (_log.IsDebugEnabled && query.parameters.Count > 0)
            {
                _log.Debug("Parameters: ");
                foreach (var parameter in query.parameters)
                    _log.DebugFormat("\t{0}={1}", parameter.Key, parameter.Value);
            }
            var stopwatch = new Stopwatch();
            try
            {
                if (_infoService == null)
                {
                    Open();
                }
                stopwatch.Start();
                return _infoService.Query(query);
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                _log.Error("Error executing query: " + ex.Detail.Message + Environment.NewLine + query.query);
                throw;
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error executing query: {0} {1} {2}", ex, Environment.NewLine, query.query);
                foreach (var parameter in query.parameters)
                    _log.ErrorFormat("\t{0}={1}", parameter.Key, parameter.Value);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                if (stopwatch.Elapsed > longRunningQueryTime)
                {
                    _log.WarnFormat("Support! -- LONG RUNNING QUERY: {0} ms: {1}", stopwatch.Elapsed.TotalMilliseconds, query.query);
                }
            }
        }

        public virtual string Create(string entityType, PropertyBag properties)
        {
            var stopwatch = new Stopwatch();
            try
            {
                if (_infoService == null)
                {
                    Open();
                }
                stopwatch.Start();
                return _infoService.Create(entityType, properties);
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                _log.Error("Error executing create operation: " + ex.Detail.Message + Environment.NewLine + entityType + Environment.NewLine + properties);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                if (stopwatch.Elapsed > longRunningQueryTime)
                {
                    _log.WarnFormat("Support! -- LONG RUNNING CREATE: {0} ms: {1}", stopwatch.Elapsed.TotalMilliseconds, entityType);
                }
            }
        }

        public virtual PropertyBag Read(string uri)
        {
            var stopwatch = new Stopwatch();
            try
            {
                if (_infoService == null)
                {
                    Open();
                }
                stopwatch.Start();
                return _infoService.Read(uri);
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                _log.Error("Error executing read operation: " + ex.Detail.Message + Environment.NewLine + uri);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                if (stopwatch.Elapsed > longRunningQueryTime)
                {
                    _log.WarnFormat("Support! -- LONG RUNNING READ: {0} ms: {1}", stopwatch.Elapsed.TotalMilliseconds, uri);
                }
            }
        }

        public virtual void Update(string uri, PropertyBag propertiesToUpdate)
        {
            var stopwatch = new Stopwatch();
            try
            {
                if (_infoService == null)
                {
                    Open();
                }
                stopwatch.Start();
                _infoService.Update(uri, propertiesToUpdate);
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                _log.Error("Error executing update operation: " + ex.Detail.Message + Environment.NewLine + uri + Environment.NewLine + propertiesToUpdate);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                if (stopwatch.Elapsed > longRunningQueryTime)
                {
                    _log.WarnFormat("Support! -- LONG RUNNING UPDATE: {0} ms: {1}", stopwatch.Elapsed.TotalMilliseconds, uri);
                }
            }
        }

        public virtual void BulkUpdate(string[] uris, PropertyBag propertiesToUpdate)
        {
            var stopwatch = new Stopwatch();
            try
            {
                if (_infoService == null)
                {
                    Open();
                }
                stopwatch.Start();
                _infoService.BulkUpdate(uris, propertiesToUpdate);
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                _log.Error("Error executing bulk update operation: " + ex.Detail.Message + Environment.NewLine + String.Join(Environment.NewLine, uris) + Environment.NewLine + propertiesToUpdate);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                if (stopwatch.Elapsed > longRunningQueryTime)
                {
                    _log.WarnFormat("Support! -- LONG RUNNING BULK UPDATE: {0} ms", stopwatch.Elapsed.TotalMilliseconds);
                }
            }
        }

        public virtual void Delete(string uri)
        {
            var stopwatch = new Stopwatch();
            try
            {
                if (_infoService == null)
                {
                    Open();
                }
                stopwatch.Start();
                _infoService.Delete(uri);
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                _log.Error("Error executing delete operation: " + ex.Detail.Message + Environment.NewLine + uri);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                if (stopwatch.Elapsed > longRunningQueryTime)
                {
                    _log.WarnFormat("Support! -- LONG RUNNING DELETE: {0} ms: {1}", stopwatch.Elapsed.TotalMilliseconds, uri);
                }
            }
        }

        public virtual void BulkDelete(string[] uris)
        {
            var stopwatch = new Stopwatch();
            try
            {
                if (_infoService == null)
                {
                    Open();
                }
                stopwatch.Start();
                _infoService.BulkDelete(uris);
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                _log.Error("Error executing bulk delete operation: " + ex.Detail.Message + Environment.NewLine + String.Join(Environment.NewLine, uris));
                throw;
            }
            finally
            {
                stopwatch.Stop();
                if (stopwatch.Elapsed > longRunningQueryTime)
                {
                    _log.WarnFormat("Support! -- LONG RUNNING BULK DELETE: {0} ms", stopwatch.Elapsed.TotalMilliseconds);
                }
            }
        }

        #endregion

        #region IStreamedInfoService Members

        public VerbInvokeResponse StreamedInvoke(VerbInvokeArguments parameter)
        {
            var stopwatch = new Stopwatch();
            try
            {
                if (_infoService == null)
                {
                    Open();
                }
                stopwatch.Start();
                return _infoService.StreamedInvoke(parameter);
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                _log.Error("Error executing invoke: " + ex.Detail.Message + Environment.NewLine + parameter.Entity + "." + parameter.Verb);
                throw;
            }
            finally
            {
                stopwatch.Stop();
                if (stopwatch.Elapsed > longRunningQueryTime)
                {
                    _log.WarnFormat("Support! -- LONG RUNNING INVOKE: {0} ms: {1}:{2}", stopwatch.Elapsed.TotalMilliseconds, parameter.Verb, parameter.Entity);
                }
            }
        }

        #endregion

        public void Open()
        {
            try
            {
                if (_infoService == null)
                {
                    if (_activityMonitor != null)
                        _activityMonitor.Reset();

                    _infoService = _channelFactory.CreateChannel();

                    _infoService.OperationTimeout = _operationTimeout;
                    _infoService.Open();
                }
            }
            catch (Exception ex)
            {
                _log.Error("An error occured opening a connection to the orion communication service.", ex);
                throw;
            }
        }

        public void Abort()
        {
            if (_infoService == null)
                return;

            ValidateUsedConnection();

            _infoService.Abort();
            _channelFactory.Abort();
        }

        public void Close()
        {
            if (_infoService == null)
                return;

            ValidateUsedConnection();

            try
            {
                _infoService.Close();
            }
            catch (TimeoutException exception)
            {
                _infoService.Abort();
                _log.Error("Error closing exception.", exception);
            }
            catch (CommunicationException exception)
            {
                _infoService.Abort();
                _log.Error("Error closing exception.", exception);
            }

            _infoService = null;
        }

        #region Create Channel Factory

        private static ChannelFactory<IStreamInformationServiceChannel> CreateChannelFactory(Binding binding, EndpointAddress address)
        {
            if (_log.IsDebugEnabled)
                _log.DebugFormat("Creating channel factory for Information Service @ {0}", address.Uri);

            return new ChannelFactory<IStreamInformationServiceChannel>(binding, address);
        }

        private static ChannelFactory<IStreamInformationServiceChannel> CreateChannelFactory(string endpointConfiguration)
        {
            if (_log.IsDebugEnabled)
                _log.DebugFormat("Creating channel factory for Information Service using endpoint configuration '{0}'", endpointConfiguration);

            return new ChannelFactory<IStreamInformationServiceChannel>(endpointConfiguration);
        }

        private static ChannelFactory<IStreamInformationServiceChannel> CreateChannelFactory(string endpointConfiguration, EndpointAddress remoteAddress)
        {
            if (_log.IsDebugEnabled)
                _log.DebugFormat("Creating channel factory for Information Service using endpoint configuration '{0}' and remote address '{1}'", endpointConfiguration, remoteAddress.ToString());

            return new ChannelFactory<IStreamInformationServiceChannel>(endpointConfiguration, remoteAddress);
        }

        #endregion

        private void ValidateUsedConnection()
        {
            if (_infoService == null)
                return;

            if (_activityMonitor == null || _activityMonitor.RequestSent)
                return;

            _log.Info("Non-used connection was opened. Information for developers. No impact on product functionality. See verbose log for more details.");
            _log.VerboseFormat("StackTrace: {0}", Environment.StackTrace);

            try
            {
                //
                // kick of simple query because of 
                // https://connect.microsoft.com/VisualStudio/feedback/details/499859/wcf-pending-secure-conversions-are-not-cleaned-up-in-specific-scenario
                //                    
                using (_infoService.Query(new QueryXmlRequest("SELECT TOP 1 1 as Test FROM Metadata.Entity")))
                {

                }
            }
            catch { }
        }

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Close();

                try
                {
                    _channelFactory.Close();
                }
                catch (TimeoutException)
                {
                    _channelFactory.Abort();
                }
                catch (CommunicationException)
                {
                    _channelFactory.Abort();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~InfoServiceProxy()
        {
            Dispose(false);
        }

        #endregion
    }
}
