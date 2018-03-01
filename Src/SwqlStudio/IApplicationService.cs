using SolarWinds.InformationService.Contract2;
using SwqlStudio.Metadata;
using SwqlStudio.Subscriptions;

namespace SwqlStudio
{
    public interface IApplicationService
    {
        PropertyBag QueryParameters { get; }

        SubscriptionManager SubscriptionManager{ get; }

        void AddTextToEditor(string text, ConnectionInfo info);

        void OpenActivityMonitor(string title, ConnectionInfo connectionInfo);

        void OpenInvokeTab(string title, ConnectionInfo connectionInfo, Verb verb);

        void OpenCrudTab(CrudOperation operation, ConnectionInfo connectionInfo, Entity entity);
    }
}
