using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace SwqlStudio
{
    public class LogHeaderMessageInspector : IClientMessageInspector
    {
        [ThreadStatic] private static string log;

        public static string LastReplyLog { get { return log; } }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            int logHeader = reply.Headers.FindHeader("log", "http://schemas.solarwinds.com/2007/08/informationservice");
            if (logHeader >= 0)
                log = reply.Headers.GetHeader<string>(logHeader);
            else
                log = string.Empty;
        }
    }
}
