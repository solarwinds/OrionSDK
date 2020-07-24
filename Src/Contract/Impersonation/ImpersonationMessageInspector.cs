using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace SolarWinds.InformationService.Contract2.Impersonation
{
    class ImpersonationMessageInspector : IClientMessageInspector, IDispatchMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            ImpersonationContext impersonationContext = ImpersonationContext.GetCurrentContext();
            if (impersonationContext != null)
            {
                var impersonationHeader = new ImpersonationHeader { TargetUsername = impersonationContext.TargetUsername };
                MessageHeader header = MessageHeader.CreateHeader(Constants.HeaderName, Constants.Namespace, impersonationHeader);
                request.Headers.Add(header);
            }
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            // Don't actually need to do anything on the server side. This header is dealt with by the IAuthorizationPolicy.
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }
}
