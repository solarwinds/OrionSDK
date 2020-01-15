using System;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.InformationServiceClient;
using SwqlStudio.Metadata;
using SwqlStudio.Properties;
using SwqlStudio.Subscriptions;
using SwqlStudio.Utils;

namespace SwqlStudio
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        UseSynchronizationContext = false)]
    internal partial class MainForm : Form, IApplicationService
    {
        private static readonly SolarWinds.Logging.Log log = new SolarWinds.Logging.Log();
        private ServerList serverList;
        private readonly BindingList<ConnectionInfo> connectionsDataSource = new BindingList<ConnectionInfo>();
        private ConnectionsManager connectionsManager;
        private QueryTab lastActiveTab;

        public PropertyBag QueryParameters
        {
            get { return this.filesDock.QueryParameters; }
            set { this.filesDock.QueryParameters = value; }
        }

        public SubscriptionManager SubscriptionManager { get; } = new SubscriptionManager();

        public ConnectionInfo SelectedConnection
        {
            get { return this.connectionsCombobox.SelectedItem as ConnectionInfo; }
            set { this.connectionsCombobox.SelectedItem = value; }
        }

        public MainForm()
        {
            InitializeComponent();

            InitializeDockPanel();
            SetEntityGroupingMode((EntityGroupingMode) Enum.Parse(typeof(EntityGroupingMode),
                Settings.Default.EntityGroupingMode));

            startTimer.Enabled = true;

            SubscriptionManager = new SubscriptionManager();
            AssignConnectionsDataSource();
            this.modifiedEditors1.Parent = this;
        }

        private void InitializeDockPanel()
        {
            this.serverList = new ServerList();
            this.serverList.ConnectionAdded += ServerListOnConnectionAdded;
            this.serverList.ConnectionRemoved += ServerListOnConnectionRemoved;
            this.connectionsManager = new ConnectionsManager(this, this.serverList);
            var tabsFactory = new TabsFactory(this.filesDock, this, this.serverList, this.connectionsManager);
            this.filesDock.SetAplicationService(tabsFactory);
            this.filesDock.ActiveContentChanged += FilesDock_ActiveContentChanged;

        }

        private void AssignConnectionsDataSource()
        {
            var connectionsDropDown = this.connectionsCombobox.ComboBox;
            connectionsDropDown.DisplayMember = "Title";
            connectionsDropDown.DataSource = this.connectionsDataSource;
        }

        private void FilesDock_ActiveContentChanged(object sender, EventArgs e)
        {
            this.RefreshSelectedConnections();

            IConnectionTab activeConnectionTab = this.filesDock.ActiveConnectionTab;
            if (activeConnectionTab != null)
            {
                this.SelectedConnection = activeConnectionTab.ConnectionInfo;
            }


            var activeTab = filesDock.ActiveQueryTab;
            if (lastActiveTab != null && activeTab != lastActiveTab)
            {
                lastActiveTab.HideFindReplaceDialog();
            }

            lastActiveTab = activeTab;
        }

        public void RefreshSelectedConnections()
        {
            IConnectionTab activeConnectionTab = this.filesDock.ActiveConnectionTab;
            this.connectionsCombobox.Enabled =
                activeConnectionTab == null || activeConnectionTab.AllowsChangeConnection;
        }

        private void ServerListOnConnectionAdded(object sender, ConnectionsEventArgs e)
        {
            ConnectionInfo addedConnection = e.Connection;
            this.connectionsDataSource.Add(addedConnection);
            this.serverList.TryGetProvider(addedConnection, out IMetadataProvider provider);
            this.filesDock.AddServer(provider, addedConnection);
            this.SelectedConnection = addedConnection;

            if (this.connectionsDataSource.Count == 1)
                this.filesDock.ReplaceConnection(null, addedConnection);
        }

        private void ServerListOnConnectionRemoved(object sender, ConnectionsEventArgs e)
        {
            this.connectionsDataSource.Remove(e.Connection);

            if (connectionsDataSource.Any())
                this.SelectedConnection = connectionsDataSource.First();

            this.filesDock.CloseServer(e.Connection, this.SelectedConnection);
        }

        private void startTimer_Tick(object sender, EventArgs e)
        {
            startTimer.Enabled = false;
            this.filesDock.AddNewQueryTab();
        }

        #region Code related to File menu

        private void menuFileNew_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionInfo.DoWithExceptionTranslation(() => connectionsManager.CreateConnection());
            }
            catch (Exception ex)
            {
                log.Error("Failed to connect", ex);
                var msg = $"Unable to connect to Information Service.\n{ex.Message}";
                MessageBox.Show(msg, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                this.filesDock.OpenFiles(openFileDialog.FileNames);
        }

        private void menuFileClose_Click(object sender, EventArgs e)
        {
            this.filesDock.CloseActiveContent();
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            var editor = this.filesDock.ActiveQueryTab;
            if (editor != null)
                this.modifiedEditors1.DoSave(editor);
        }

        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            var editor = this.filesDock.ActiveQueryTab;
            if (editor != null)
                this.modifiedEditors1.DoSaveAs(editor);
        }

        private void menuNotificationListenerActive_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (SubscriptionManager.IsListening())
                {
                    SubscriptionManager.CloseListeningService();
                    menuNotificationListenerActive.Checked = false;
                }
                else
                {
                    Action x = () => menuNotificationListenerActive.Checked = true;
                    SubscriptionManager.StartListening(() => this.BeginInvoke(x));
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Code related to Edit menu

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.filesDock.ActiveQueryTab?.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.filesDock.ActiveQueryTab?.Redo();
        }

        private void menuEditCut_Click(object sender, EventArgs e)
        {
            this.filesDock.ActiveQueryTab?.Cut();
        }

        private void menuEditCopy_Click(object sender, EventArgs e)
        {
            this.filesDock.ActiveQueryTab?.CopySelectionToClipboard();
        }

        private void menuEditPaste_Click(object sender, EventArgs e)
        {
            this.filesDock.ActiveQueryTab?.Paste();
        }

        #endregion

        #region Other stuff

        private void TextEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool canceled = !this.modifiedEditors1.SaveModifiedEditors(this.filesDock.QueryTabs);

            if (canceled)
            {
                e.Cancel = true;
                return;
            }

            CloseEditorConnections();
        }

        private void CloseEditorConnections()
        {
            foreach (var editor in this.filesDock.QueryTabs)
            {
                if (editor.Tag is ConnectionInfo info)
                {
                    info.Dispose();
                }
            }
        }

        /// <summary>We handle DragEnter and DragDrop so users can drop files on the editor.</summary>
        private void TextEditorForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void TextEditorForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] list = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (list != null)
                this.filesDock.OpenFiles(list);
        }

        #endregion

        private void menuQueryExecute_Click(object sender, EventArgs e)
        {
            this.filesDock.ActiveQueryTab?.RunQuery();
        }

        private void parametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.filesDock.ShowParametersToolbox();
        }

        private void enumEntitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionInfo connection = this.SelectedConnection;
            if (connection == null)
                return; // should we try to connect?

            string errorMsg;

            try
            {
                EntityClassGraph entityClassGraph = new EntityClassGraph(connection.Connection);

                EntityClassGraphForm form = new EntityClassGraphForm(entityClassGraph);
                form.Show(this);
                return;
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                log.Error("Failed to connect", ex);
                errorMsg = ex.Detail.Message;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }

            if (errorMsg != null)
            {
                errorMsg = string.Format("Unable to connect to generate entity graph. {0}", errorMsg);
                MessageBox.Show(this, errorMsg, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void playbackToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            filesDock.ActiveQueryTab?.RunPlayback();
        }

        private void aboutSWQLStudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog(this);
        }

        private void byNamespaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEntityGroupingMode(EntityGroupingMode.ByNamespace);
        }

        private void noGroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEntityGroupingMode(EntityGroupingMode.Flat);
        }

        private void SetEntityGroupingMode(EntityGroupingMode mode)
        {
            byNamespaceToolStripMenuItem.Checked = mode == EntityGroupingMode.ByNamespace;
            noGroupingToolStripMenuItem.Checked = mode == EntityGroupingMode.Flat;
            byBaseTypeToolStripMenuItem.Checked = mode == EntityGroupingMode.ByBaseType;
            byHierarchyToolStripMenuItem.Checked = mode == EntityGroupingMode.ByHierarchy;

            Settings.Default.EntityGroupingMode = mode.ToString();
            Settings.Default.Save();

            this.filesDock.SetEntityGroupingMode(mode);
        }

        private void byBaseTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEntityGroupingMode(EntityGroupingMode.ByBaseType);
        }

        private void byHierarchyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetEntityGroupingMode(EntityGroupingMode.ByHierarchy);
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            menuNotificationListenerActive.Visible =
                separatorAboveNotificationListenerActive.Visible =
                    !Settings.Default.UseActiveSubscriber;

            menuNotificationListenerActive.CheckState = SubscriptionManager.IsListening()
                ? CheckState.Checked
                : CheckState.Unchecked;
        }

        private void menuFileTabPage_Click(object sender, EventArgs e)
        {
            this.filesDock.CreateTabFromPrevious();
        }

        private void enableAutocompleteToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.AutocompleteEnabled = enableAutocompleteToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void preferencesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            enableAutocompleteToolStripMenuItem.Checked = Settings.Default.AutocompleteEnabled;
            promptToSaveOnCloseToolStripMenuItem.Checked = Settings.Default.PromptToSaveOnClose;
            showObsoleteToolStripMenuItem.Checked = Settings.Default.ShowObsolete;
        }

        private void searchInTreeHotKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.filesDock.FocusSearch();
        }

        private void discoverQueryParametersToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            this.filesDock.AllowSetParameters(this.discoverQueryParametersMenuItem.Checked);
        }

        private void connectionsCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IConnectionTab activeConnectionTab = this.filesDock.ActiveConnectionTab;
            if (activeConnectionTab != null && this.SelectedConnection != null)
            {
                activeConnectionTab.ConnectionInfo = this.SelectedConnection;
            }
        }

        private void disconnectToolButton_Click(object sender, EventArgs e)
        {
            this.SelectedConnection?.Close();
        }

        private void refreshToolButton_Click(object sender, EventArgs e)
        {
            var connection = this.SelectedConnection;
            if (connection != null)
                this.filesDock.RefreshServer(connection);
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            copyQueryAsToolStripMenuItem.Enabled = filesDock.ActiveQueryTab != null;
        }

        private void curlCmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyQueryAs(CommandLineGenerator.GetQueryForCurlCmd);
        }

        private void curlBashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyQueryAs(CommandLineGenerator.GetQueryForCurlBash);
        }

        private void getSwisDataPowerShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyQueryAs(CommandLineGenerator.GetQueryForPowerShellGetSwisData);
        }

        private void CopyQueryAs(Func<string, ConnectionInfo, PropertyBag, string> formatter)
        {
            var connection = filesDock.ActiveConnectionTab?.ConnectionInfo;
            if (connection == null)
                return;

            var query = filesDock.ActiveQueryTab.QueryText;
            var parameters = filesDock.QueryParameters;
            string command = formatter(query, connection, parameters);
            Clipboard.SetText(command);
        }

        private void promptToSaveOnCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.PromptToSaveOnClose = !Settings.Default.PromptToSaveOnClose;
            Settings.Default.Save();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filesDock.ActiveQueryTab?.FindDialog();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filesDock.ActiveQueryTab?.ReplaceDialog();
        }

        private void showObsoleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.ShowObsolete = !Settings.Default.ShowObsolete;
            Settings.Default.Save();
            filesDock.RefreshObjectExplorerFilters();
        }
    }
}
