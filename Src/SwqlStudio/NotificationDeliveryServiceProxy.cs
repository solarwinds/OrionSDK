using System.IdentityModel.Policy;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using SolarWinds.InformationService.Contract2.PubSub;

namespace SwqlStudio
{
    class NotificationDeliveryServiceProxy : DuplexClientBase<INotificationDeliveryService>
    {
        public NotificationDeliveryServiceProxy(string endpointConfig, string address) : base(endpointConfig, address)
        {
            FixBinding();
        }

        public NotificationDeliveryServiceProxy(InstanceContext context, NetTcpBinding binding, EndpointAddress endpointAddress) : base(context, binding, endpointAddress)
        {
            FixBinding();
        }

        private void FixBinding()
        {
            BindingElementCollection elements = this.ChannelFactory.Endpoint.Binding.CreateBindingElements();
            SslStreamSecurityBindingElement element = elements.Find<SslStreamSecurityBindingElement>();
            if (element != null)
            {
                element.IdentityVerifier = new SWIdentityVerifier();

                CustomBinding newbinding = new CustomBinding(elements);

                // Transfer timeout settings from the old binding to the new
                Binding binding = this.ChannelFactory.Endpoint.Binding;
                newbinding.CloseTimeout = binding.CloseTimeout;
                newbinding.OpenTimeout = binding.OpenTimeout;
                newbinding.ReceiveTimeout = binding.ReceiveTimeout;
                newbinding.SendTimeout = binding.SendTimeout;

                this.ChannelFactory.Endpoint.Binding = newbinding;
            }
        }

        public void ReceiveIndications(string address)
        {
            base.Channel.ReceiveIndications(address);
        }

        public void Disconnect(string address)
        {
            base.Channel.Disconnect(address);
        }

        class SWIdentityVerifier : IdentityVerifier
        {
            public override bool CheckAccess(EndpointIdentity identity, AuthorizationContext authContext)
            {
                return true;
            }

            public override bool TryGetIdentity(EndpointAddress reference, out EndpointIdentity identity)
            {
                identity = null;
                return true;
            }
        }

    }
}