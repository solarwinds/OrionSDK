using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace SolarWinds.InformationService.Contract2
{
    class SwisProtocolVersionMessageInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var header = MessageHeader.CreateHeader(Constants.ProtocolVersion, Constants.Namespace, Constants.SupportedProtocolVersion);
            request.Headers.Add(header);

            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {

        }
    }
}
