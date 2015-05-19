using System;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    public interface IApplicationService
    {
        void AddTextToEditor(string text, ConnectionInfo info);
        void OpenActivityMonitor(string title, ConnectionInfo connectionInfo);
        void OpenInvokeTab(string title, ConnectionInfo connectionInfo, Verb verb);

        SubscriberInfo GetSubscriberInfo();
        SubscriberInfo GetHttpSubscriberInfo();

        event EventHandler<IndicationEventArgs> IndicationReceived;

    }

    public class SubscriberInfo
    {
        public bool OpenedSuccessfully { get; set; }
        public string EndpointAddress { get; set; }
        public string ErrorMessage { get; set; }

        public string DataFormat { get; set; }
        public string Binding { get; set; }

        public string CredentialType { get; set; }
    }
}
