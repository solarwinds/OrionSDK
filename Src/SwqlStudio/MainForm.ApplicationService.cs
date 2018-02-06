using System.Windows.Forms;
using SwqlStudio.Metadata;
using SwqlStudio.Subscriptions;

namespace SwqlStudio
{
    partial class MainForm : IApplicationService
    {
        public SubscriptionManager SubscriptionManager { get; } = new SubscriptionManager();

        public void AddTextToEditor(string text, ConnectionInfo info)
        {
            if (info == null)
                info = ActiveConnectionInfo;

            IMetadataProvider metadataProvider;
            _metadataProviders.TryGetValue(info, out metadataProvider);

            CreateQueryTab(info.Title, info, metadataProvider);
            ActiveQueryTab.QueryText = text;
        }

        public void OpenActivityMonitor(string title, ConnectionInfo info)
        {
            var tab = new TabPage(title) { BorderStyle = BorderStyle.None, Padding = new Padding(0) };
            var activityMonitorTab = new ActivityMonitorTab { ConnectionInfo = info, Dock = DockStyle.Fill, ApplicationService = this };
            tab.Controls.Add(activityMonitorTab);
            fileTabs.Controls.Add(tab);
            fileTabs.SelectedTab = tab;
            activityMonitorTab.Start();
        }

        public void OpenInvokeTab(string title, ConnectionInfo info, Verb verb)
        {
            var tab = new TabPage(title) { BorderStyle = BorderStyle.None, Padding = new Padding(0) };
            var invokeVerbTab = new InvokeVerbTab { ConnectionInfo = info, Dock = DockStyle.Fill, ApplicationService = this, Verb = verb };
            tab.Controls.Add(invokeVerbTab);
            fileTabs.Controls.Add(tab);
            fileTabs.SelectedTab = tab;
        }

        /// <inheritdoc />
        public void OpenCrudTab(CrudOperation operation, ConnectionInfo info, Entity entity)
        {
            var tab = new TabPage(entity.FullName + " - " + operation) { BorderStyle = BorderStyle.None, Padding = new Padding(0) };
            var crudTab = new CrudTab(operation)
            {
                ConnectionInfo = info,
                Dock = DockStyle.Fill,
                ApplicationService = this,
                Entity = entity
            };

            crudTab.CloseItself += (s, e) =>
            {
                fileTabs.TabPages.Remove(tab);
                tab.Dispose();
            };

            tab.Controls.Add(crudTab);
            fileTabs.Controls.Add(tab);
            fileTabs.SelectedTab = tab;
        }
    }
}
