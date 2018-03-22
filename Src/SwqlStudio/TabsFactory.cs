using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Windows.Forms;
using SolarWinds.InformationService.Contract2;
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
        private int queryTabsCounter = 0;

        internal TabsFactory(QueriesDockPanel dockPanel, IApplicationService applicationService,
            ServerList serverList, ConnectionsManager connectionsManager)
        {
            this.dockPanel = dockPanel;
            this.applicationService = applicationService;
            this.serverList = serverList;
            this.connectionsManager = connectionsManager;
        }

        public void AddTextToEditor(string text, ConnectionInfo info)
        {
            if (info == null)
                info = this.applicationService.SelectedConnection;
            
            if (info == null)
                return;

            string title = CreateQueryTitile();
            CreateQueryTab(title, info);
            this.dockPanel.ActiveQueryTab.QueryText = text;
        }

        private string CreateQueryTitile()
        {
            queryTabsCounter++;
            return "Query" + queryTabsCounter;
        }

        public void OpenActivityMonitor(ConnectionInfo info)
        {
            var activityMonitorTab = new ActivityMonitorTab
            {
                ConnectionInfo = info,
                Dock = DockStyle.Fill,
                SubscriptionManager = this.applicationService.SubscriptionManager
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
                this.dockPanel.RemoveTab(crudTab.Parent as DockContent);
            };

            string title = entity.FullName + " - " + operation;
            AddNewTab(crudTab, title);
        }

        internal void AddNewQueryTab()
        {
            string msg = null;

            try
            {
                ConnectionInfo info = this.connectionsManager.ResolveConnection();
                if (info== null)
                    return;

                string title = CreateQueryTitile();
                this.CreateQueryTab(title, info);
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                log.Error("Failed to connect", ex);
                msg = ex.Detail.Message;
            }
            catch (SecurityNegotiationException ex)
            {
                log.Error("Failed to connect", ex);
                msg = ex.Message;
            }
            catch (FaultException ex)
            {
                log.Error("Failed to connect", ex);
                msg = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
            }
            catch (MessageSecurityException ex)
            {
                log.Error("Failed to connect", ex);
                if (ex.InnerException != null && ex.InnerException is FaultException)
                {
                    msg = (ex.InnerException as FaultException).Message;
                }
                else
                {
                    msg = ex.Message;
                }
            }
            catch (Exception ex)
            {
                log.Error("Failed to connect", ex);
                msg = ex.Message;
            }

            if (msg != null)
            {
                msg = string.Format("Unable to connect to Information Service. {0}", msg);
                MessageBox.Show(msg, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void OpenFiles(string[] files)
        {
            var connectionInfo = this.connectionsManager.ResolveConnection();
            if (connectionInfo == null)
                return;

            this.dockPanel.ColoseInitialDocument();
            connectionInfo.Connect();
            
            // Open file(s)
            foreach (string fn in files)
            {
                QueryTab queryTab = null;
                try
                {
                    queryTab = this.CreateQueryTab(string.Empty, connectionInfo);
                    queryTab.QueryText = File.ReadAllText(fn);
                    queryTab.FileName = fn;
                    // Modified flag is set during loading because the document 
                    // "changes" (from nothing to something). So, clear it again.
                    queryTab.MarkSaved();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().Name);
                    if (queryTab != null)
                        this.dockPanel.RemoveTab(queryTab.Parent as DockContent);
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

        internal void CreateTabFromPrevious()
        {
            var tab = this.dockPanel.ActiveConnectionTab;
            if (tab != null)
            {
                var connection = this.connectionsManager.ResolveConnection();
                if (connection == null)
                    return;

                var swql = this.dockPanel.ActiveQueryTab.QueryText;
                this.AddTextToEditor(swql, connection);
            }
            else
            {
                AddNewQueryTab();
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
            dockContent.Show(this.dockPanel, DockState.Document);
        }
    }
}