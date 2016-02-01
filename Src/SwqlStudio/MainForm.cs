using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Windows.Forms;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.InformationServiceClient;
using SwqlStudio.Metadata;
using SwqlStudio.Properties;
using SwqlStudio.Subscriptions;

namespace SwqlStudio
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        UseSynchronizationContext = false)]
    public partial class MainForm : Form, IApplicationService
    {
        private static readonly SolarWinds.Logging.Log log = new SolarWinds.Logging.Log();

        private readonly ServerList serverList = new ServerList();

        public MainForm()
        {
            InitializeComponent();
            objectExplorer.ApplicationService = this;
            SetEntityGroupingMode((EntityGroupingMode)Enum.Parse(typeof(EntityGroupingMode), Settings.Default.EntityGroupingMode));

            startTimer.Enabled = true;

            SubscriptionManager = new SubscriptionManager();
        }

        private void startTimer_Tick(object sender, EventArgs e)
        {
            startTimer.Enabled = false;
            AddNewQueryTab();
        }


        #region Code related to File menu

        private void menuFileNew_Click(object sender, EventArgs e)
        {
            AddNewQueryTab();
        }

        private void AddNewQueryTab()
        {
            using (NewConnection nc = new NewConnection())
            {
                if (nc.ShowDialog(this) != DialogResult.OK)
                    return;

                string msg = null;

                try
                {
                    ConnectionInfo info;
                    bool alreadyExists = false;
                    alreadyExists = serverList.TryGet(nc.ConnectionInfo.ServerType, nc.ConnectionInfo.Server, nc.ConnectionInfo.UserName, out info);
                    if (!alreadyExists)
                    {
                        info = nc.ConnectionInfo;
                        info.Connect();
                        serverList.Add(info);

                        info.ConnectionClosed += (sender, args) => serverList.Remove(info);
                    }

                    CreateQueryTab(info.Title, info);
                    
                    if (!alreadyExists)
                    {
                        objectExplorer.AddServer(new SwisMetaDataProvider(info), info);
                    }
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
                    MessageBox.Show(this, msg, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private QueryTab CreateQueryTab(string title, ConnectionInfo info)
        {
            var tab = new TabPage(title) { BorderStyle = BorderStyle.None, Padding = new Padding(0) };
            var queryTab = new QueryTab { ConnectionInfo = info, Dock = DockStyle.Fill, ApplicationService = this };
            tab.Controls.Add(queryTab);
            fileTabs.Controls.Add(tab);
            fileTabs.SelectedTab = tab;

            info.ConnectionClosed += (sender, args) =>
            {
                RemoveQueryTab(queryTab);
                Application.DoEvents();
            };

            return queryTab;
        }

        private void CloneActiveTabWithNewQuery(string query)
        {
            QueryTab tab = CreateQueryTab(ActiveConnectionTab.ConnectionInfo.Title, ActiveConnectionTab.ConnectionInfo);
            tab.QueryText = query;
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                // Try to open chosen file
                OpenFiles(openFileDialog.FileNames);
        }

        private void OpenFiles(string[] fns)
        {
            // Close default untitled document if it is still empty
            if (fileTabs.TabPages.Count == 1
                && ActiveQueryTab.QueryText.Trim() == String.Empty)
                RemoveQueryTab(ActiveQueryTab);

            // Open file(s)
            foreach (string fn in fns)
            {
                QueryTab queryTab = null;
                try
                {
                    var connectionInfo = ActiveConnectionInfo.Copy();
                    connectionInfo.Connect();

                    queryTab = CreateQueryTab(Path.GetFileName(fn), connectionInfo);
                    queryTab.QueryText = File.ReadAllText(fn);
                    // Modified flag is set during loading because the document 
                    // "changes" (from nothing to something). So, clear it again.
                    queryTab.IsDirty = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, ex.GetType().Name);
                    if (queryTab != null)
                        RemoveQueryTab(queryTab);
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

        private void menuFileClose_Click(object sender, EventArgs e)
        {
            if (fileTabs.TabPages.Count > 0)
                RemoveQueryTab(fileTabs.SelectedTab.Controls[0]);
        }

        private static void RemoveQueryTab(Control queryTab)
        {
            TabPage tabPage = (TabPage)queryTab.Parent;
            TabControl tabControl = tabPage.Parent as TabControl;
            tabControl.TabPages.Remove(tabPage);

            // Due MDA exception "RaceOnRCWCleanup error when closing a form with WebBrowser control", tab page is destroyed as below
            tabPage.BeginInvoke((MethodInvoker)delegate { tabPage.Dispose(); });
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            SciTextEditorControl editor = ActiveEditor;
            if (editor != null)
                DoSave(editor);
        }

        private bool DoSave(SciTextEditorControl editor)
        {
            if (string.IsNullOrEmpty(editor.FileName))
                return DoSaveAs(editor);
            else
            {
                try
                {
                    editor.SaveFile(editor.FileName);
                    SetModifiedFlag(editor, false);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, ex.GetType().Name);
                    return false;
                }
            }
        }

        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            var editor = ActiveEditor;
            if (editor != null)
                DoSaveAs(editor);
        }

        private bool DoSaveAs(SciTextEditorControl editor)
        {
            saveFileDialog.FileName = editor.FileName;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    editor.SaveFile(saveFileDialog.FileName);
                    editor.Parent.Text = Path.GetFileName(editor.FileName);
                    SetModifiedFlag(editor, false);

                    // The syntax highlighting strategy doesn't change
                    // automatically, so do it manually.
                    //editor.Document.HighlightingStrategy = 
                    //    HighlightingStrategyFactory.CreateHighlightingStrategyForFile(editor.FileName);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, ex.GetType().Name);
                }
            }
            return false;
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

        private void menuEditCut_Click(object sender, EventArgs e)
        {
            if (ActiveEditor == null)
                return;

            ActiveEditor.Cut();
        }

        private void menuEditCopy_Click(object sender, EventArgs e)
        {
            if (ActiveQueryTab == null)
                return;

            ActiveQueryTab.CopySelectionToClipboard();
        }

        private void menuEditPaste_Click(object sender, EventArgs e)
        {
            if (ActiveEditor == null)
                return;

            ActiveEditor.Paste();
        }

        #endregion

        #region Other stuff

        private void TextEditorDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Entity)))
                e.Effect = DragDropEffects.Copy;
        }

        private void TextEditorDragDrop(object sender, DragEventArgs e)
        {
            Entity entity = e.Data.GetData(typeof(Entity)) as Entity;
            if (entity != null)
                objectExplorer.GenerateSelectStatement(entity, (e.KeyState & 8) == 8);
        }

        private void TextEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ask user to save changes
            foreach (var editor in AllEditors)
            {
                if (editor.Modified)
                {
                    var r = MessageBox.Show(this, string.Format("Save changes to {0}?", editor.FileName ?? "new file"),
                        "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (r == DialogResult.Cancel)
                        e.Cancel = true;
                    else if (r == DialogResult.Yes)
                        if (!DoSave(editor))
                            e.Cancel = true;
                }

                ConnectionInfo info = editor.Tag as ConnectionInfo;
                if (info != null)
                {
                    info.Dispose();
                }
            }
        }

        /// <summary>Returns a list of all editor controls</summary>
        private IEnumerable<SciTextEditorControl> AllEditors
        {
            get
            {
                return from t in fileTabs.Controls.Cast<TabPage>()
                       from c in t.Controls.OfType<SciTextEditorControl>()
                       select c;
            }
        }

        private QueryTab ActiveQueryTab
        {
            get
            {
                if (fileTabs.TabPages.Count == 0) return null;
                return fileTabs.SelectedTab.Controls[0] as QueryTab;
            }
        }

        private IConnectionTab ActiveConnectionTab
        {
            get
            {
                if (fileTabs.TabPages.Count == 0) return null;
                return fileTabs.SelectedTab.Controls[0] as IConnectionTab;
            }
        }

        /// <summary>Returns the currently displayed editor, or null if none are open</summary>
        private SciTextEditorControl ActiveEditor
        {
            get
            {
                var tab = ActiveQueryTab;
                if (tab == null) return null;
                return tab.Editor;
            }
        }

        private ConnectionInfo ActiveConnectionInfo
        {
            get
            {
                var tab = ActiveConnectionTab;
                if (tab == null) return null;
                return tab.ConnectionInfo;
            }
        }

        /// <summary>Gets whether the file in the specified editor is modified.</summary>
        /// <remarks>TextEditorControl doesn't maintain its own internal modified 
        /// flag, so we use the '*' shown after the file name to represent the 
        /// modified state.</remarks>
        private static bool IsModified(SciTextEditorControl editor)
        {
            // TextEditorControl doesn't seem to contain its own 'modified' flag, so 
            // instead we'll treat the "*" on the filename as the modified flag.
            return editor.Parent.Text.EndsWith("*");
        }

        private static void SetModifiedFlag(SciTextEditorControl editor, bool flag)
        {
            if (IsModified(editor) != flag)
            {
                var p = editor.Parent;
                if (IsModified(editor))
                    p.Text = p.Text.Substring(0, p.Text.Length - 1);
                else
                    p.Text += "*";
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
                OpenFiles(list);
        }

        #endregion

        private void menuQueryExecute_Click(object sender, EventArgs e)
        {
            if (ActiveQueryTab == null)
                return;

            ActiveQueryTab.RunQuery();
        }

        private void parametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveConnectionInfo == null)
                return;

            var dialog = new QueryParameters(ActiveConnectionInfo.QueryParameters ?? new PropertyBag());
            if (DialogResult.OK == dialog.ShowDialog(this))
                ActiveConnectionInfo.QueryParameters = dialog.Parameters;
        }

        private void enumEntitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionInfo connection = ActiveConnectionInfo;
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
            ActiveQueryTab.RunPlayback();
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

            objectExplorer.EntityGroupingMode = mode;
            objectExplorer.RefreshAllServers();
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
            menuNotificationListenerActive.CheckState = SubscriptionManager.IsListening()
                ? CheckState.Checked
                : CheckState.Unchecked;
        }
    }
}
