#if !NETSTANDARD2_0
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace SolarWinds.InformationService.Contract2.Internationalization
{
    class I18nMessageInspector : IClientMessageInspector, IDispatchMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var i18nHeader = new I18nHeader {Culture = Thread.CurrentThread.CurrentUICulture.Name};
            MessageHeader header = MessageHeader.CreateHeader(Constants.HeaderName, Constants.Namespace, i18nHeader);
            request.Headers.Add(header);
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
#endif
