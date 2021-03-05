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
            get { return filesDock.QueryParameters; }
            set { filesDock.QueryParameters = value; }
        }

        public SubscriptionManager SubscriptionManager { get; } = new SubscriptionManager();

        public ConnectionInfo SelectedConnection
        {
            get { return connectionsCombobox.SelectedItem as ConnectionInfo; }
            set { connectionsCombobox.SelectedItem = value; }
        }

        public MainForm()
        {
            DpiHelper.FixFont(this);
            InitializeComponent();

            InitializeDockPanel();
            SetEntityGroupingMode((EntityGroupingMode)Enum.Parse(typeof(EntityGroupingMode),
                Settings.Default.EntityGroupingMode));

            startTimer.Enabled = true;

            SubscriptionManager = new SubscriptionManager();
            AssignConnectionsDataSource();
            modifiedEditors1.Parent = this;
        }

        private void InitializeDockPanel()
        {
            serverList = new ServerList();
            serverList.ConnectionAdded += ServerListOnConnectionAdded;
            serverList.ConnectionRemoved += ServerListOnConnectionRemoved;
            connectionsManager = new ConnectionsManager(this, serverList);
            var tabsFactory = new TabsFactory(filesDock, this, serverList, connectionsManager);
            filesDock.SetAplicationService(tabsFactory);
            filesDock.ActiveContentChanged += FilesDock_ActiveContentChanged;

        }

        private void AssignConnectionsDataSource()
        {
            var connectionsDropDown = connectionsCombobox.ComboBox;
            connectionsDropDown.DisplayMember = "Title";
            connectionsDropDown.DataSource = connectionsDataSource;
        }

        private void FilesDock_ActiveContentChanged(object sender, EventArgs e)
        {
            RefreshSelectedConnections();

            IConnectionTab activeConnectionTab = filesDock.ActiveConnectionTab;
            if (activeConnectionTab != null)
            {
                SelectedConnection = activeConnectionTab.ConnectionInfo;
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
            IConnectionTab activeConnectionTab = filesDock.ActiveConnectionTab;
            connectionsCombobox.Enabled =
                activeConnectionTab == null || activeConnectionTab.AllowsChangeConnection;
        }

        private void ServerListOnConnectionAdded(object sender, ConnectionsEventArgs e)
        {
            ConnectionInfo addedConnection = e.Connection;
            connectionsDataSource.Add(addedConnection);
            serverList.TryGetProvider(addedConnection, out IMetadataProvider provider);
            filesDock.AddServer(provider, addedConnection);
            SelectedConnection = addedConnection;

            if (connectionsDataSource.Count == 1)
                filesDock.ReplaceConnection(null, addedConnection);
        }

        private void ServerListOnConnectionRemoved(object sender, ConnectionsEventArgs e)
        {
            connectionsDataSource.Remove(e.Connection);

            if (connectionsDataSource.Any())
                SelectedConnection = connectionsDataSource.First();

            filesDock.CloseServer(e.Connection, SelectedConnection);
        }

        private void startTimer_Tick(object sender, EventArgs e)
        {
            startTimer.Enabled = false;
            filesDock.AddNewQueryTab();
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
                filesDock.OpenFiles(openFileDialog.FileNames);
        }

        private void menuFileClose_Click(object sender, EventArgs e)
        {
            filesDock.CloseActiveContent();
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            var editor = filesDock.ActiveQueryTab;
            if (editor != null)
                modifiedEditors1.DoSave(editor);
        }

        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            var editor = filesDock.ActiveQueryTab;
            if (editor != null)
                modifiedEditors1.DoSaveAs(editor);
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
                    SubscriptionManager.StartListening(() => BeginInvoke(x));
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
            filesDock.ActiveQueryTab?.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filesDock.ActiveQueryTab?.Redo();
        }

        private void menuEditCut_Click(object sender, EventArgs e)
        {
            filesDock.ActiveQueryTab?.Cut();
        }

        private void menuEditCopy_Click(object sender, EventArgs e)
        {
            filesDock.ActiveQueryTab?.CopySelectionToClipboard();
        }

        private void menuEditPaste_Click(object sender, EventArgs e)
        {
            filesDock.ActiveQueryTab?.Paste();
        }

        #endregion

        #region Other stuff

        private void TextEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool canceled = !modifiedEditors1.SaveModifiedEditors(filesDock.QueryTabs);

            if (canceled)
            {
                e.Cancel = true;
                return;
            }

            CloseEditorConnections();
        }

        private void CloseEditorConnections()
        {
            foreach (var editor in filesDock.QueryTabs)
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
                filesDock.OpenFiles(list);
        }

        #endregion

        private void menuQueryExecute_Click(object sender, EventArgs e)
        {
            filesDock.ActiveQueryTab?.RunQuery();
        }

        private void parametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filesDock.ShowParametersToolbox();
        }

        private void enumEntitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionInfo connection = SelectedConnection;
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

            filesDock.SetEntityGroupingMode(mode);
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
            filesDock.CreateTabFromPrevious();
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
            filesDock.FocusSearch();
        }

        private void discoverQueryParametersToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            filesDock.AllowSetParameters(discoverQueryParametersMenuItem.Checked);
        }

        private void connectionsCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IConnectionTab activeConnectionTab = filesDock.ActiveConnectionTab;
            if (activeConnectionTab != null && SelectedConnection != null)
            {
                activeConnectionTab.ConnectionInfo = SelectedConnection;
            }
        }

        private void disconnectToolButton_Click(object sender, EventArgs e)
        {
            SelectedConnection?.Close();
        }

        private void refreshToolButton_Click(object sender, EventArgs e)
        {
            var connection = SelectedConnection;
            if (connection != null)
                filesDock.RefreshServer(connection);
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
