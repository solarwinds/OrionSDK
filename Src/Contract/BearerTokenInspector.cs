using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace SolarWinds.InformationService.Contract2
{
    public class BearerTokenInspector : IClientMessageInspector
    {
        private readonly Func<string> _tokenProvider;

        public BearerTokenInspector(Func<string> tokenProvider)
        {
            _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            string token = _tokenProvider();

            HttpRequestMessageProperty property;
            if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out object existing))
            {
                property = (HttpRequestMessageProperty)existing;
            }
            else
            {
                property = new HttpRequestMessageProperty();
                request.Properties[HttpRequestMessageProperty.Name] = property;
            }

            property.Headers[HttpRequestHeader.Authorization] = "Bearer " + token;
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
}
