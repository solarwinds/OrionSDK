using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal interface ITabsFactory
    {
        void AddTextToEditor(string text, ConnectionInfo info);

        void OpenActivityMonitor(string title, ConnectionInfo connectionInfo);

        void OpenInvokeTab(string title, ConnectionInfo connectionInfo, Verb verb);

        void OpenCrudTab(CrudOperation operation, ConnectionInfo connectionInfo, Entity entity);
    }
}