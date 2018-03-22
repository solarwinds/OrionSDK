using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal interface ITabsFactory
    {
        void OpenQueryTab();

        void OpenQueryTab(string text, ConnectionInfo info);

        void OpenActivityMonitor(ConnectionInfo connectionInfo);

        void OpenInvokeTab(ConnectionInfo connectionInfo, Verb verb);

        void OpenCrudTab(CrudOperation operation, ConnectionInfo connectionInfo, Entity entity);

        void OpenFiles(string[] files);
    }
}