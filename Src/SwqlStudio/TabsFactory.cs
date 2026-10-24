using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SwqlStudio.Metadata;
using SwqlStudio.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace SwqlStudio
{
    internal class TabsFactory : ITabsFactory
    {
        private static readonly SolarWinds.Logging.Log log = new SolarWinds.Logging.Log();

        private readonly ServerList serverList;
        private readonly QueriesDockPanel dockPanel;
        private readonly IApplicationService applicationService;
        private readonly ConnectionsManager connectionsManager;
        private readonly Func<QueryTab, bool> confirmCloseQueryTab;
        private int queryTabsCounter = 0;

        internal TabsFactory(QueriesDockPanel dockPanel, IApplicationService applicationService,
            ServerList serverList, ConnectionsManager connectionsManager,
            Func<QueryTab, bool> confirmCloseQueryTab)
        {
            this.dockPanel = dockPanel;
            this.applicationService = applicationService;
            this.serverList = serverList;
            this.connectionsManager = connectionsManager;
            this.confirmCloseQueryTab = confirmCloseQueryTab;
        }

        public void OpenQueryTab()
        {
            OpenQueryTab(null, null);
        }

        public void OpenQueryTab(string text, ConnectionInfo info)
        {
            try
            {
                var connection = info ?? ConnectionInfo.DoWithExceptionTranslation(() => connectionsManager.ResolveConnection());
                if (connection != null)
                {
                    var queryTab = string.IsNullOrWhiteSpace(text)
                        ? null
                        : dockPanel.QueryTabs.FirstOrDefault(tab =>
                            string.IsNullOrWhiteSpace(tab.QueryText) &&
                            !tab.Modified &&
                            string.IsNullOrEmpty(tab.FileName));

                    if (queryTab == null)
                    {
                        string title = CreateQueryTitle();
                        queryTab = CreateQueryTab(title, connection);
                    }
                    else
                    {
                        queryTab.ConnectionInfo = connection;
                    }

                    queryTab.QueryText = text;
                    (queryTab.Parent as DockContent)?.Activate();
                }
            }
            catch (Exception ex)
            {
                log.Error("Failed to connect", ex);
                var msg = $"Unable to connect to Information Service.\n{ex.Message}";
                MessageBox.Show(msg, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string CreateQueryTitle()
        {
            queryTabsCounter++;
            return "Query" + queryTabsCounter;
        }

        public void OpenActivityMonitor(ConnectionInfo info)
        {
            var activityMonitorTab = new ActivityMonitorTab(applicationService)
            {
                ConnectionInfo = info,
                Dock = DockStyle.Fill,
                SubscriptionManager = applicationService.SubscriptionManager
            };

            string title = info.Title + " Activity";
            AddNewTab(activityMonitorTab, title);
            activityMonitorTab.Start();
        }

        public void OpenInvokeTab(ConnectionInfo info, Verb verb)
        {
            var invokeVerbTab = new InvokeVerbTab
            {
                ConnectionInfo = info,
                Dock = DockStyle.Fill,
                Verb = verb
            };

            string title = $"Invoke {verb.EntityName}.{verb.Name}";
            AddNewTab(invokeVerbTab, title);
        }

        /// <inheritdoc />
        public void OpenCrudTab(CrudOperation operation, ConnectionInfo info, Entity entity)
        {
            var crudTab = new CrudTab(operation)
            {
                ConnectionInfo = info,
                Dock = DockStyle.Fill,
                Entity = entity
            };

            crudTab.CloseItself += (s, e) =>
            {
                dockPanel.RemoveTab(crudTab.Parent as DockContent);
            };

            string title = entity.FullName + " - " + operation;
            AddNewTab(crudTab, title);
        }

        public void OpenFiles(string[] files)
        {
            var connectionInfo = connectionsManager.ResolveConnection();
            if (connectionInfo == null)
                return;

            dockPanel.ColoseInitialDocument();
            connectionInfo.Connect();

            // Open file(s)
            foreach (string fn in files)
            {
                QueryTab queryTab = null;
                try
                {
                    queryTab = CreateQueryTab(string.Empty, connectionInfo);
                    queryTab.QueryText = File.ReadAllText(fn);
                    queryTab.FileName = fn;
                    // Modified flag is set during loading because the document
                    // "changes" (from nothing to something). So, clear it again.
                    queryTab.MarkSaved();
                    RecentFiles.Add(fn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().Name);
                    if (queryTab != null)
                        dockPanel.RemoveTab(queryTab.Parent as DockContent);
                    return;
                }

                // ICSharpCode.TextEditor doesn't have any built-in code folding
                // strategies, so I've included a simple one. Apparently, the
                // foldings are not updated automatically, so in this demo the user
                // cannot add or remove folding regions after loading the file.
                //--				editor.Document.FoldingManager.FoldingStrategy = new RegionFoldingStrategy();
                //--				editor.Document.FoldingManager.UpdateFoldings(null, null);
            }
        }

        private QueryTab CreateQueryTab(string title, ConnectionInfo info)
        {
            var queryTab = new QueryTab(applicationService, serverList, info, applicationService.SubscriptionManager)
            {
                Dock = DockStyle.Fill
            };

            AddNewTab(queryTab, title);
            return queryTab;
        }

        private void AddNewTab(Control childControl, string title)
        {
            var dockContent = new DockContent();
            dockContent.Icon = Resources.TextFile_16x;
            dockContent.Controls.Add(childControl);
            dockContent.Text = title;
            if (childControl is QueryTab queryTab)
            {
                // MainForm prompts for all tabs itself when the application is closing.
                dockContent.FormClosing += (sender, e) =>
                    e.Cancel = e.CloseReason != CloseReason.MdiFormClosing && !confirmCloseQueryTab(queryTab);
            }
            dockContent.Show(dockPanel, DockState.Document);
        }
    }
}
