#if !NETSTANDARD2_0

using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace SolarWinds.InformationService.Contract2
{
    class InfoServiceActivityMonitor : IEndpointBehavior, IClientMessageInspector
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
            clientRuntime.MessageInspectors.Add(this);
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
#endif
