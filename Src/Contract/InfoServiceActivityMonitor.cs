using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace SolarWinds.InformationService.Contract2
{
    internal class InfoServiceActivityMonitor : IEndpointBehavior, IClientMessageInspector
    {
        public bool RequestSent
        {
            get;
            private set;
        }

        public void Reset()
        {
            RequestSent = false;
        }

        #region IEndpointBehavior Members

        void IEndpointBehavior.AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        void IEndpointBehavior.ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(this);
        }

        void IEndpointBehavior.ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            throw new NotImplementedException();
        }

        void IEndpointBehavior.Validate(ServiceEndpoint endpoint)
        {
        }

        #endregion

        #region IClientMessageInspector Members

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            RequestSent = true;

            return null;
        }

        #endregion
    }
}
