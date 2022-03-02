using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace SolarWinds.InformationService.Contract2.Internationalization
{
    internal class I18nMessageInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var i18nHeader = new I18nHeader { Culture = Thread.CurrentThread.CurrentUICulture.Name };
            MessageHeader header = MessageHeader.CreateHeader(Constants.HeaderName, Constants.Namespace, i18nHeader);
            request.Headers.Add(header);
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
}
