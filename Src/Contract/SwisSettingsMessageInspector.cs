using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace SolarWinds.InformationService.Contract2
{
    internal class SwisSettingsMessageInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            if (SwisSettingsContext.Current != null)
            {
                var settingHeader = new SwisSettings
                {
                    DataProviderTimeout = SwisSettingsContext.Current.DataProviderTimeout,
                    ApplicationTag = SwisSettingsContext.Current.ApplicationTag,
                    AppendErrors = SwisSettingsContext.Current.AppendErrors
                };
                var header = MessageHeader.CreateHeader(Constants.SwisSettingsHeaderName, Constants.Namespace, settingHeader);
                request.Headers.Add(header);
            }

            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {

        }
    }
}
