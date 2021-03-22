namespace SwqlStudio
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.separatorAboveNotificationListenerActive = new System.Windows.Forms.ToolStripSeparator();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileTabPage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileClose2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNotificationListenerActive = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.searchInTreeHotKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.copyQueryAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curlCmdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curlBashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getSwisDataPowerShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQueryExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.parametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enumEntitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupEntityTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byNamespaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byBaseTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byHierarchyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noGroupingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableAutocompleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discoverQueryParametersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promptToSaveOnCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showObsoleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSWQLStudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.filesDock = new SwqlStudio.QueriesDockPanel();
            this.startTimer = new System.Windows.Forms.Timer(this.components);
            this.mainToolbar = new System.Windows.Forms.ToolStrip();
            this.connectionsCombobox = new System.Windows.Forms.ToolStripComboBox();
            this.executeToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.newConnectionButton = new System.Windows.Forms.ToolStripButton();
            this.disconnectToolButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolButton = new System.Windows.Forms.ToolStripButton();
            this.redoToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.newFileToolButton = new System.Windows.Forms.ToolStripButton();
            this.openFileButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolButton = new System.Windows.Forms.ToolStripButton();
            this.modifiedEditors1 = new SwqlStudio.ModifiedEditors();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu.SuspendLayout();
            this.mainToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // separatorAboveNotificationListenerActive
            // 
            this.separatorAboveNotificationListenerActive.Name = "separatorAboveNotificationListenerActive";
            this.separatorAboveNotificationListenerActive.Size = new System.Drawing.Size(215, 6);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.queryToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(827, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileTabPage,
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.menuFileClose,
            this.menuFileClose2,
            this.separatorAboveNotificationListenerActive,
            this.menuNotificationListenerActive,
            toolStripSeparator1,
            this.menuFileExit,
            this.searchInTreeHotKeyToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // menuFileNew
            // 
            this.menuFileNew.Image = global::SwqlStudio.Properties.Resources.ConnectFilled_16x;
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuFileNew.Size = new System.Drawing.Size(218, 22);
            this.menuFileNew.Text = "&New Connection...";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // menuFileTabPage
            // 
            this.menuFileTabPage.Image = global::SwqlStudio.Properties.Resources.NewFile_16x;
            this.menuFileTabPage.Name = "menuFileTabPage";
            this.menuFileTabPage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.menuFileTabPage.Size = new System.Drawing.Size(218, 22);
            this.menuFileTabPage.Text = "New Query &Tab";
            this.menuFileTabPage.Click += new System.EventHandler(this.menuFileTabPage_Click);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Image = global::SwqlStudio.Properties.Resources.OpenFolder_16x;
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuFileOpen.Size = new System.Drawing.Size(218, 22);
            this.menuFileOpen.Text = "&Open File...";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Image = global::SwqlStudio.Properties.Resources.Save_16x;
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuFileSave.Size = new System.Drawing.Size(218, 22);
            this.menuFileSave.Text = "&Save";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.menuFileSaveAs.Size = new System.Drawing.Size(218, 22);
            this.menuFileSaveAs.Text = "Save &As...";
            this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
            // 
            // menuFileClose
            // 
            this.menuFileClose.Name = "menuFileClose";
            this.menuFileClose.ShortcutKeyDisplayString = "Ctrl+W, Ctrl+F4";
            this.menuFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.menuFileClose.Size = new System.Drawing.Size(218, 22);
            this.menuFileClose.Text = "&Close";
            this.menuFileClose.Click += new System.EventHandler(this.menuFileClose_Click);
            // 
            // menuFileClose2
            // 
            this.menuFileClose2.Name = "menuFileClose2";
            this.menuFileClose2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.menuFileClose2.Size = new System.Drawing.Size(218, 22);
            this.menuFileClose2.Text = "Close";
            this.menuFileClose2.Visible = false;
            this.menuFileClose2.Click += new System.EventHandler(this.menuFileClose_Click);
            // 
            // menuNotificationListenerActive
            // 
            this.menuNotificationListenerActive.Checked = true;
            this.menuNotificationListenerActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuNotificationListenerActive.Name = "menuNotificationListenerActive";
            this.menuNotificationListenerActive.Size = new System.Drawing.Size(218, 22);
            this.menuNotificationListenerActive.Text = "Notification Listener Active";
            this.menuNotificationListenerActive.Click += new System.EventHandler(this.menuNotificationListenerActive_Click);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(218, 22);
            this.menuFileExit.Text = "&Exit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // searchInTreeHotKeyToolStripMenuItem
            // 
            this.searchInTreeHotKeyToolStripMenuItem.Name = "searchInTreeHotKeyToolStripMenuItem";
            this.searchInTreeHotKeyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+\\";
            this.searchInTreeHotKeyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oem5)));
            this.searchInTreeHotKeyToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.searchInTreeHotKeyToolStripMenuItem.Text = "SearchInTreeHotKey";
            this.searchInTreeHotKeyToolStripMenuItem.Visible = false;
            this.searchInTreeHotKeyToolStripMenuItem.Click += new System.EventHandler(this.searchInTreeHotKeyToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator5,
            this.findToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.toolStripSeparator6,
            this.menuEditCut,
            this.menuEditCopy,
            this.menuEditPaste,
            this.copyQueryAsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = global::SwqlStudio.Properties.Resources.Undo_16x;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Image = global::SwqlStudio.Properties.Resources.Redo_16x;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(155, 6);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.findToolStripMenuItem.Text = "&Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(155, 6);
            // 
            // menuEditCut
            // 
            this.menuEditCut.Image = ((System.Drawing.Image)(resources.GetObject("menuEditCut.Image")));
            this.menuEditCut.Name = "menuEditCut";
            this.menuEditCut.ShortcutKeyDisplayString = "Ctrl+X";
            this.menuEditCut.Size = new System.Drawing.Size(158, 22);
            this.menuEditCut.Text = "Cu&t";
            this.menuEditCut.Click += new System.EventHandler(this.menuEditCut_Click);
            // 
            // menuEditCopy
            // 
            this.menuEditCopy.Image = global::SwqlStudio.Properties.Resources.ASX_Copy_blue_16x;
            this.menuEditCopy.Name = "menuEditCopy";
            this.menuEditCopy.ShortcutKeyDisplayString = "Ctrl+C";
            this.menuEditCopy.Size = new System.Drawing.Size(158, 22);
            this.menuEditCopy.Text = "&Copy";
            this.menuEditCopy.Click += new System.EventHandler(this.menuEditCopy_Click);
            // 
            // menuEditPaste
            // 
            this.menuEditPaste.Image = global::SwqlStudio.Properties.Resources.ASX_Paste_blue_16x;
            this.menuEditPaste.Name = "menuEditPaste";
            this.menuEditPaste.ShortcutKeyDisplayString = "Ctrl+V";
            this.menuEditPaste.Size = new System.Drawing.Size(158, 22);
            this.menuEditPaste.Text = "&Paste";
            this.menuEditPaste.Click += new System.EventHandler(this.menuEditPaste_Click);
            // 
            // copyQueryAsToolStripMenuItem
            // 
            this.copyQueryAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.curlCmdToolStripMenuItem,
            this.curlBashToolStripMenuItem,
            this.getSwisDataPowerShellToolStripMenuItem});
            this.copyQueryAsToolStripMenuItem.Name = "copyQueryAsToolStripMenuItem";
            this.copyQueryAsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.copyQueryAsToolStripMenuItem.Text = "Copy &Query As";
            // 
            // curlCmdToolStripMenuItem
            // 
            this.curlCmdToolStripMenuItem.Name = "curlCmdToolStripMenuItem";
            this.curlCmdToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.curlCmdToolStripMenuItem.Text = "Curl (&Cmd)";
            this.curlCmdToolStripMenuItem.Click += new System.EventHandler(this.curlCmdToolStripMenuItem_Click);
            // 
            // curlBashToolStripMenuItem
            // 
            this.curlBashToolStripMenuItem.Name = "curlBashToolStripMenuItem";
            this.curlBashToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.curlBashToolStripMenuItem.Text = "Curl (&Bash)";
            this.curlBashToolStripMenuItem.Click += new System.EventHandler(this.curlBashToolStripMenuItem_Click);
            // 
            // getSwisDataPowerShellToolStripMenuItem
            // 
            this.getSwisDataPowerShellToolStripMenuItem.Name = "getSwisDataPowerShellToolStripMenuItem";
            this.getSwisDataPowerShellToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.getSwisDataPowerShellToolStripMenuItem.Text = "Get-SwisData (&PowerShell)";
            this.getSwisDataPowerShellToolStripMenuItem.Click += new System.EventHandler(this.getSwisDataPowerShellToolStripMenuItem_Click);
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuQueryExecute,
            this.parametersToolStripMenuItem,
            this.enumEntitiesToolStripMenuItem,
            this.playbackToolStripMenuItem});
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.queryToolStripMenuItem.Text = "&Query";
            // 
            // menuQueryExecute
            // 
            this.menuQueryExecute.Image = global::SwqlStudio.Properties.Resources.Run_16x;
            this.menuQueryExecute.Name = "menuQueryExecute";
            this.menuQueryExecute.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.menuQueryExecute.Size = new System.Drawing.Size(210, 22);
            this.menuQueryExecute.Text = "&Execute";
            this.menuQueryExecute.Click += new System.EventHandler(this.menuQueryExecute_Click);
            // 
            // parametersToolStripMenuItem
            // 
            this.parametersToolStripMenuItem.Name = "parametersToolStripMenuItem";
            this.parametersToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.parametersToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.parametersToolStripMenuItem.Text = "Parameters...";
            this.parametersToolStripMenuItem.Click += new System.EventHandler(this.parametersToolStripMenuItem_Click);
            // 
            // enumEntitiesToolStripMenuItem
            // 
            this.enumEntitiesToolStripMenuItem.Name = "enumEntitiesToolStripMenuItem";
            this.enumEntitiesToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.enumEntitiesToolStripMenuItem.Text = "Entity Inheritance Graph...";
            this.enumEntitiesToolStripMenuItem.Click += new System.EventHandler(this.enumEntitiesToolStripMenuItem_Click);
            // 
            // playbackToolStripMenuItem
            // 
            this.playbackToolStripMenuItem.Name = "playbackToolStripMenuItem";
            this.playbackToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.playbackToolStripMenuItem.Text = "Playback";
            this.playbackToolStripMenuItem.Click += new System.EventHandler(this.playbackToolStripMenuItem_Click_1);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupEntityTreeToolStripMenuItem,
            this.enableAutocompleteToolStripMenuItem,
            this.discoverQueryParametersMenuItem,
            this.promptToSaveOnCloseToolStripMenuItem,
            this.showObsoleteToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "&Preferences";
            this.preferencesToolStripMenuItem.DropDownOpening += new System.EventHandler(this.preferencesToolStripMenuItem_DropDownOpening);
            // 
            // groupEntityTreeToolStripMenuItem
            // 
            this.groupEntityTreeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byNamespaceToolStripMenuItem,
            this.byBaseTypeToolStripMenuItem,
            this.byHierarchyToolStripMenuItem,
            this.noGroupingToolStripMenuItem});
            this.groupEntityTreeToolStripMenuItem.Name = "groupEntityTreeToolStripMenuItem";
            this.groupEntityTreeToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.groupEntityTreeToolStripMenuItem.Text = "&Group Entity Tree";
            // 
            // byNamespaceToolStripMenuItem
            // 
            this.byNamespaceToolStripMenuItem.Name = "byNamespaceToolStripMenuItem";
            this.byNamespaceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.byNamespaceToolStripMenuItem.Text = "By &Namespace";
            this.byNamespaceToolStripMenuItem.Click += new System.EventHandler(this.byNamespaceToolStripMenuItem_Click);
            // 
            // byBaseTypeToolStripMenuItem
            // 
            this.byBaseTypeToolStripMenuItem.Name = "byBaseTypeToolStripMenuItem";
            this.byBaseTypeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.byBaseTypeToolStripMenuItem.Text = "By &Base type";
            this.byBaseTypeToolStripMenuItem.Click += new System.EventHandler(this.byBaseTypeToolStripMenuItem_Click);
            // 
            // byHierarchyToolStripMenuItem
            // 
            this.byHierarchyToolStripMenuItem.Name = "byHierarchyToolStripMenuItem";
            this.byHierarchyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.byHierarchyToolStripMenuItem.Text = "By &Hierarchy";
            this.byHierarchyToolStripMenuItem.Click += new System.EventHandler(this.byHierarchyToolStripMenuItem_Click);
            // 
            // noGroupingToolStripMenuItem
            // 
            this.noGroupingToolStripMenuItem.Name = "noGroupingToolStripMenuItem";
            this.noGroupingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.noGroupingToolStripMenuItem.Text = "No &Grouping";
            this.noGroupingToolStripMenuItem.Click += new System.EventHandler(this.noGroupingToolStripMenuItem_Click);
            // 
            // enableAutocompleteToolStripMenuItem
            // 
            this.enableAutocompleteToolStripMenuItem.Checked = true;
            this.enableAutocompleteToolStripMenuItem.CheckOnClick = true;
            this.enableAutocompleteToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableAutocompleteToolStripMenuItem.Name = "enableAutocompleteToolStripMenuItem";
            this.enableAutocompleteToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.enableAutocompleteToolStripMenuItem.Text = "Enable Autocomplete";
            this.enableAutocompleteToolStripMenuItem.CheckedChanged += new System.EventHandler(this.enableAutocompleteToolStripMenuItem_CheckedChanged);
            // 
            // discoverQueryParametersMenuItem
            // 
            this.discoverQueryParametersMenuItem.Checked = true;
            this.discoverQueryParametersMenuItem.CheckOnClick = true;
            this.discoverQueryParametersMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.discoverQueryParametersMenuItem.Name = "discoverQueryParametersMenuItem";
            this.discoverQueryParametersMenuItem.Size = new System.Drawing.Size(214, 22);
            this.discoverQueryParametersMenuItem.Text = "Discover query parameters";
            this.discoverQueryParametersMenuItem.CheckedChanged += new System.EventHandler(this.discoverQueryParametersToolStripMenuItem_CheckedChanged);
            // 
            // promptToSaveOnCloseToolStripMenuItem
            // 
            this.promptToSaveOnCloseToolStripMenuItem.Name = "promptToSaveOnCloseToolStripMenuItem";
            this.promptToSaveOnCloseToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.promptToSaveOnCloseToolStripMenuItem.Text = "Prompt to save on close";
            this.promptToSaveOnCloseToolStripMenuItem.Click += new System.EventHandler(this.promptToSaveOnCloseToolStripMenuItem_Click);
            // 
            // showObsoleteToolStripMenuItem
            // 
            this.showObsoleteToolStripMenuItem.Name = "showObsoleteToolStripMenuItem";
            this.showObsoleteToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.showObsoleteToolStripMenuItem.Text = "Show Obsolete";
            this.showObsoleteToolStripMenuItem.Click += new System.EventHandler(this.showObsoleteToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutSWQLStudioToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutSWQLStudioToolStripMenuItem
            // 
            this.aboutSWQLStudioToolStripMenuItem.Name = "aboutSWQLStudioToolStripMenuItem";
            this.aboutSWQLStudioToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.aboutSWQLStudioToolStripMenuItem.Text = "About SWQL Studio";
            this.aboutSWQLStudioToolStripMenuItem.Click += new System.EventHandler(this.aboutSWQLStudioToolStripMenuItem_Click);
            // 
            // filesDock
            // 
            this.filesDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesDock.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.filesDock.Location = new System.Drawing.Point(0, 24);
            this.filesDock.Name = "filesDock";
            this.filesDock.Padding = new System.Windows.Forms.Padding(6, 6, 31, 6);
            this.filesDock.QueryParameters = ((SolarWinds.InformationService.Contract2.PropertyBag)(resources.GetObject("filesDock.QueryParameters")));
            this.filesDock.ShowAutoHideContentOnHover = false;
            this.filesDock.Size = new System.Drawing.Size(827, 571);
            this.filesDock.TabIndex = 2;
            // 
            // startTimer
            // 
            this.startTimer.Tick += new System.EventHandler(this.startTimer_Tick);
            // 
            // mainToolbar
            // 
            this.mainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionsCombobox,
            this.executeToolButton,
            this.toolStripSeparator4,
            this.newConnectionButton,
            this.disconnectToolButton,
            this.refreshToolButton,
            this.toolStripSeparator2,
            this.undoToolButton,
            this.redoToolButton,
            this.toolStripSeparator3,
            this.newFileToolButton,
            this.openFileButton,
            this.saveToolButton});
            this.mainToolbar.Location = new System.Drawing.Point(0, 24);
            this.mainToolbar.Name = "mainToolbar";
            this.mainToolbar.Size = new System.Drawing.Size(827, 25);
            this.mainToolbar.TabIndex = 5;
            this.mainToolbar.Text = "toolStrip1";
            // 
            // connectionsCombobox
            // 
            this.connectionsCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.connectionsCombobox.DropDownWidth = 300;
            this.connectionsCombobox.Name = "connectionsCombobox";
            this.connectionsCombobox.Size = new System.Drawing.Size(250, 25);
            this.connectionsCombobox.SelectedIndexChanged += new System.EventHandler(this.connectionsCombobox_SelectedIndexChanged);
            // 
            // executeToolButton
            // 
            this.executeToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.executeToolButton.Image = global::SwqlStudio.Properties.Resources.Run_16x;
            this.executeToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.executeToolButton.Name = "executeToolButton";
            this.executeToolButton.Size = new System.Drawing.Size(23, 22);
            this.executeToolButton.ToolTipText = "Execute query (F5)";
            this.executeToolButton.Click += new System.EventHandler(this.menuQueryExecute_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // newConnectionButton
            // 
            this.newConnectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newConnectionButton.Image = global::SwqlStudio.Properties.Resources.ConnectFilled_16x;
            this.newConnectionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newConnectionButton.Name = "newConnectionButton";
            this.newConnectionButton.Size = new System.Drawing.Size(23, 22);
            this.newConnectionButton.ToolTipText = "New Connection... (Ctrl+N)";
            this.newConnectionButton.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // disconnectToolButton
            // 
            this.disconnectToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.disconnectToolButton.Image = global::SwqlStudio.Properties.Resources.Disconnect_16x;
            this.disconnectToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disconnectToolButton.Name = "disconnectToolButton";
            this.disconnectToolButton.Size = new System.Drawing.Size(23, 22);
            this.disconnectToolButton.Text = "Disconnect";
            this.disconnectToolButton.Click += new System.EventHandler(this.disconnectToolButton_Click);
            // 
            // refreshToolButton
            // 
            this.refreshToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolButton.Image = global::SwqlStudio.Properties.Resources.Refresh_16x;
            this.refreshToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolButton.Name = "refreshToolButton";
            this.refreshToolButton.Size = new System.Drawing.Size(23, 22);
            this.refreshToolButton.Text = "Refresh Server Metadata";
            this.refreshToolButton.Click += new System.EventHandler(this.refreshToolButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // undoToolButton
            // 
            this.undoToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoToolButton.Image = global::SwqlStudio.Properties.Resources.Undo_16x;
            this.undoToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoToolButton.Name = "undoToolButton";
            this.undoToolButton.Size = new System.Drawing.Size(23, 22);
            this.undoToolButton.ToolTipText = "Undo (Ctrl+Z)";
            this.undoToolButton.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolButton
            // 
            this.redoToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoToolButton.Image = global::SwqlStudio.Properties.Resources.Redo_16x;
            this.redoToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoToolButton.Name = "redoToolButton";
            this.redoToolButton.Size = new System.Drawing.Size(23, 22);
            this.redoToolButton.ToolTipText = "Redo (Ctrl+Y)";
            this.redoToolButton.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // newFileToolButton
            // 
            this.newFileToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newFileToolButton.Image = global::SwqlStudio.Properties.Resources.NewFile_16x;
            this.newFileToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newFileToolButton.Name = "newFileToolButton";
            this.newFileToolButton.Size = new System.Drawing.Size(23, 22);
            this.newFileToolButton.ToolTipText = "New Query Tab (Ctrl+T)";
            this.newFileToolButton.Click += new System.EventHandler(this.menuFileTabPage_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileButton.Image = global::SwqlStudio.Properties.Resources.OpenFolder_16x;
            this.openFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(23, 22);
            this.openFileButton.ToolTipText = "Open File... (Ctrl+O)";
            this.openFileButton.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // saveToolButton
            // 
            this.saveToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolButton.Image = global::SwqlStudio.Properties.Resources.Save_16x;
            this.saveToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolButton.Name = "saveToolButton";
            this.saveToolButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolButton.ToolTipText = "Save (Ctrl+S)";
            this.saveToolButton.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 595);
            this.Controls.Add(this.filesDock);
            this.Controls.Add(this.mainToolbar);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "SWQL Studio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TextEditor_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextEditorForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextEditorForm_DragEnter);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.mainToolbar.ResumeLayout(false);
            this.mainToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuFileClose;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuEditCut;
        private System.Windows.Forms.ToolStripMenuItem menuEditCopy;
        private System.Windows.Forms.ToolStripMenuItem menuEditPaste;
        private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuQueryExecute;
        private System.Windows.Forms.Timer startTimer;
        private System.Windows.Forms.ToolStripMenuItem parametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enumEntitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSWQLStudioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuNotificationListenerActive;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableAutocompleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupEntityTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byNamespaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noGroupingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byBaseTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byHierarchyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuFileClose2;
        private System.Windows.Forms.ToolStripMenuItem menuFileTabPage;
        private System.Windows.Forms.ToolStripSeparator separatorAboveNotificationListenerActive;
        private System.Windows.Forms.ToolStripMenuItem searchInTreeHotKeyToolStripMenuItem;
        private SwqlStudio.QueriesDockPanel filesDock;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discoverQueryParametersMenuItem;
        private System.Windows.Forms.ToolStrip mainToolbar;
        private System.Windows.Forms.ToolStripButton undoToolButton;
        private System.Windows.Forms.ToolStripButton redoToolButton;
        private System.Windows.Forms.ToolStripButton newFileToolButton;
        private System.Windows.Forms.ToolStripButton saveToolButton;
        private System.Windows.Forms.ToolStripButton executeToolButton;
        private System.Windows.Forms.ToolStripButton openFileButton;
        private System.Windows.Forms.ToolStripComboBox connectionsCombobox;
        private System.Windows.Forms.ToolStripButton newConnectionButton;
        private System.Windows.Forms.ToolStripButton disconnectToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton refreshToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem copyQueryAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curlCmdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curlBashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getSwisDataPowerShellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promptToSaveOnCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showObsoleteToolStripMenuItem;
        private ModifiedEditors modifiedEditors1;
    }
}

