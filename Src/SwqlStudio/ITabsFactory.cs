using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal interface ITabsFactory
    {
        void AddTextToEditor(string text, ConnectionInfo info);

        void OpenActivityMonitor(ConnectionInfo connectionInfo);

        void OpenInvokeTab(ConnectionInfo connectionInfo, Verb verb);

        void OpenCrudTab(CrudOperation operation, ConnectionInfo connectionInfo, Entity entity);
    }
}