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
            var activityMonitorTab = new ActivityMonitorTab { ConnectionInfo = info, Dock = DockStyle.Fill, ApplicationService = this };
            AddNewTab(activityMonitorTab, title);
            activityMonitorTab.Start();
        }

        public void OpenInvokeTab(string title, ConnectionInfo info, Verb verb)
        {
            var invokeVerbTab = new InvokeVerbTab { ConnectionInfo = info, Dock = DockStyle.Fill, ApplicationService = this, Verb = verb };
            AddNewTab(invokeVerbTab, title);
        }

        /// <inheritdoc />
        public void OpenCrudTab(CrudOperation operation, ConnectionInfo info, Entity entity)
        {
            string title = entity.FullName + " - " + operation;
            var crudTab = new CrudTab(operation)
            {
                ConnectionInfo = info,
                Dock = DockStyle.Fill,
                ApplicationService = this,
                Entity = entity
            };

            crudTab.CloseItself += (s, e) =>
            {
                RemoveTab(crudTab.Parent as TabPage);
            };


            AddNewTab(crudTab, title);
        }

        private void AddNewTab(Control childControl, string title)
        {
            var tab = new TabPage(title) { BorderStyle = BorderStyle.None, Padding = new Padding(0) };
            tab.Controls.Add(childControl);
            fileTabs.Controls.Add(tab);
            fileTabs.SelectedTab = tab;
        }
    }
}
