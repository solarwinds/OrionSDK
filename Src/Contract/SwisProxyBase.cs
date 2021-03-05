using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SolarWinds.InformationService.Contract2.Bindings;
using SolarWinds.Logging;

namespace SolarWinds.InformationService.Contract2
{
    public abstract class SwisProxyBase<T> : IDisposable where T : IClientChannel
    {
        private readonly static Log _log = new Log();

        private ChannelFactory<T> _channelFactory;
        private T _infoService;

        public T InfoService
        {
            get
            {
                return _infoService;
            }
        }

        public IChannel Channel
        {
            get
            {
                return _infoService;
            }
        }

        public IClientChannel ClientChannel
        {
            get
            {
                return _infoService;
            }
        }

        public TimeSpan OperationTimeout { get; set; } = TimeSpan.FromMinutes(60);

        public SwisProxyBase(string endpointConfiguration)
        {
            if (endpointConfiguration == null)
                throw new ArgumentNullException(nameof(endpointConfiguration));

            _channelFactory = CreateChannelFactory(endpointConfiguration);

            FixBinding();
        }

        public SwisProxyBase(string endpointConfiguration, ServiceCredentials credentials)
            : this(endpointConfiguration)
        {
            if (credentials == null)
                throw new ArgumentNullException(nameof(credentials));

            credentials.ApplyTo(_channelFactory);
        }

        public SwisProxyBase(string endpointConfiguration, string remoteAddress)
        {
            if (endpointConfiguration == null)
                throw new ArgumentNullException(nameof(endpointConfiguration));

            if (remoteAddress == null)
                throw new ArgumentNullException(nameof(remoteAddress));

            _channelFactory = CreateChannelFactory(endpointConfiguration, new EndpointAddress(remoteAddress));

            FixBinding();
        }

        public SwisProxyBase(string endpointConfiguration, string remoteAddress, ServiceCredentials credentials)
            : this(endpointConfiguration, remoteAddress)
        {
            if (credentials == null)
                throw new ArgumentNullException(nameof(credentials));

            credentials.ApplyTo(_channelFactory);
        }

        public SwisProxyBase(Uri address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            NetTcpBinding binding = new NetTcpBinding(SecurityMode.Transport);
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;

            Initialize(new EndpointAddress(address), binding, new WindowsCredential());
        }

        public SwisProxyBase(Uri address, Binding binding, ServiceCredentials credentials)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            Initialize(new EndpointAddress(address), binding, credentials);
        }

        public SwisProxyBase(EndpointAddress address, Binding binding, ServiceCredentials credentials)
        {
            Initialize(address, binding, credentials);
        }


        private void FixBinding()
        {
            BindingElementCollection elements = _channelFactory.Endpoint.Binding.CreateBindingElements();
            SslStreamSecurityBindingElement element = elements.Find<SslStreamSecurityBindingElement>();
            if (element != null)
            {
                CustomBinding newbinding = new CustomBinding(elements);

                // Transfer timeout settings from the old binding to the new
                Binding binding = _channelFactory.Endpoint.Binding;
                newbinding.CloseTimeout = binding.CloseTimeout;
                newbinding.OpenTimeout = binding.OpenTimeout;
                newbinding.ReceiveTimeout = binding.ReceiveTimeout;
                newbinding.SendTimeout = binding.SendTimeout;

                _channelFactory.Endpoint.Binding = newbinding;
            }
        }

        private void Initialize(EndpointAddress address, Binding binding, ServiceCredentials credentials)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            if (credentials == null)
                throw new ArgumentNullException(nameof(credentials));

            if (binding == null)
                throw new ArgumentNullException(nameof(binding));


            BindingElementCollection elements = binding.CreateBindingElements();
            SslStreamSecurityBindingElement element = elements.Find<SslStreamSecurityBindingElement>();
            if (element != null)
            {
                //element.IdentityVerifier = new SWIdentityVerifier();

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
        }

        public void Open()
        {
            try
            {
                if (_infoService == null)
                {
                    _infoService = _channelFactory.CreateChannel();

                    _infoService.OperationTimeout = OperationTimeout;
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

            _infoService.Abort();
            _channelFactory.Abort();
        }

        public void Close()
        {
            if (_infoService == null)
                return;

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

            _infoService = default(T);
        }

        private static ChannelFactory<T> CreateChannelFactory(Binding binding, EndpointAddress address)
        {
            if (_log.IsDebugEnabled)
                _log.DebugFormat("Creating channel factory for Information Service @ {0}", address.Uri);

            ChannelFactory<T> factory = new ChannelFactory<T>(binding, address);
            return factory;
        }

        private static ChannelFactory<T> CreateChannelFactory(string endpointConfiguration)
        {
            if (_log.IsDebugEnabled)
                _log.DebugFormat("Creating channel factory for Information Service using endpoint configuration '{0}'", endpointConfiguration);

            ChannelFactory<T> factory = new ChannelFactory<T>(endpointConfiguration);
            return factory;
        }

        private static ChannelFactory<T> CreateChannelFactory(string endpointConfiguration, EndpointAddress remoteAddress)
        {
            if (_log.IsDebugEnabled)
                _log.DebugFormat("Creating channel factory for Information Service using endpoint configuration '{0}' and remote address '{1}'", endpointConfiguration, remoteAddress.ToString());

            ChannelFactory<T> factory = new ChannelFactory<T>(endpointConfiguration, remoteAddress);
            return factory;
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

        ~SwisProxyBase()
        {
            Dispose(false);
        }

        #endregion
    }
}
