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
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNotificationListenerActive = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
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
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSWQLStudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileTabs = new SwqlStudio.Controls.TabControlEx();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.objectExplorer = new SwqlStudio.ObjectExplorer();
            this.ObjectExplorerImageList = new System.Windows.Forms.ImageList(this.components);
            this.startTimer = new System.Windows.Forms.Timer(this.components);
            this.menuFileClose2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileTabPage = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(214, 6);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(214, 6);
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
            toolStripMenuItem1,
            this.menuNotificationListenerActive,
            toolStripSeparator1,
            this.menuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // menuFileNew
            // 
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuFileNew.Size = new System.Drawing.Size(217, 22);
            this.menuFileNew.Text = "&New";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuFileOpen.Size = new System.Drawing.Size(217, 22);
            this.menuFileOpen.Text = "&Open";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuFileSave.Size = new System.Drawing.Size(217, 22);
            this.menuFileSave.Text = "&Save";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.Size = new System.Drawing.Size(217, 22);
            this.menuFileSaveAs.Text = "&Save As";
            this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
            // 
            // menuFileClose
            // 
            this.menuFileClose.Name = "menuFileClose";
            this.menuFileClose.ShortcutKeyDisplayString = "Ctrl+W, Ctrl-F4";
            this.menuFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.menuFileClose.Size = new System.Drawing.Size(217, 22);
            this.menuFileClose.Text = "&Close";
            this.menuFileClose.Click += new System.EventHandler(this.menuFileClose_Click);
            // 
            // menuNotificationListenerActive
            // 
            this.menuNotificationListenerActive.Checked = true;
            this.menuNotificationListenerActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuNotificationListenerActive.Name = "menuNotificationListenerActive";
            this.menuNotificationListenerActive.Size = new System.Drawing.Size(217, 22);
            this.menuNotificationListenerActive.Text = "Notification Listener Active";
            this.menuNotificationListenerActive.Click += new System.EventHandler(this.menuNotificationListenerActive_Click);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(217, 22);
            this.menuFileExit.Text = "&Exit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditCut,
            this.menuEditCopy,
            this.menuEditPaste});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // menuEditCut
            // 
            this.menuEditCut.Name = "menuEditCut";
            this.menuEditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuEditCut.Size = new System.Drawing.Size(144, 22);
            this.menuEditCut.Text = "Cu&t";
            this.menuEditCut.Click += new System.EventHandler(this.menuEditCut_Click);
            // 
            // menuEditCopy
            // 
            this.menuEditCopy.Name = "menuEditCopy";
            this.menuEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuEditCopy.Size = new System.Drawing.Size(144, 22);
            this.menuEditCopy.Text = "&Copy";
            this.menuEditCopy.Click += new System.EventHandler(this.menuEditCopy_Click);
            // 
            // menuEditPaste
            // 
            this.menuEditPaste.Name = "menuEditPaste";
            this.menuEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menuEditPaste.Size = new System.Drawing.Size(144, 22);
            this.menuEditPaste.Text = "&Paste";
            this.menuEditPaste.Click += new System.EventHandler(this.menuEditPaste_Click);
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
            this.menuQueryExecute.Name = "menuQueryExecute";
            this.menuQueryExecute.ShortcutKeyDisplayString = "F5, Ctrl-E";
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
            this.groupEntityTreeToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "&Preferences";
            // 
            // groupEntityTreeToolStripMenuItem
            // 
            this.groupEntityTreeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byNamespaceToolStripMenuItem,
            this.byBaseTypeToolStripMenuItem,
            this.byHierarchyToolStripMenuItem,
            this.noGroupingToolStripMenuItem});
            this.groupEntityTreeToolStripMenuItem.Name = "groupEntityTreeToolStripMenuItem";
            this.groupEntityTreeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
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
            // fileTabs
            // 
            this.fileTabs.AllowDrop = true;
            this.fileTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTabs.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.fileTabs.Location = new System.Drawing.Point(0, 0);
            this.fileTabs.Margin = new System.Windows.Forms.Padding(0);
            this.fileTabs.Name = "fileTabs";
            this.fileTabs.SelectedIndex = 0;
            this.fileTabs.Size = new System.Drawing.Size(632, 571);
            this.fileTabs.SizeMode = System.Windows.Forms.TabSizeMode.Normal;
            this.fileTabs.TabIndex = 1;
            this.fileTabs.TabStop = false;
            this.fileTabs.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextEditorDragDrop);
            this.fileTabs.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextEditorDragEnter);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.objectExplorer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fileTabs);
            this.splitContainer1.Size = new System.Drawing.Size(827, 571);
            this.splitContainer1.SplitterDistance = 191;
            this.splitContainer1.TabIndex = 2;
            // 
            // objectExplorer
            // 
            this.objectExplorer.ApplicationService = null;
            this.objectExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectExplorer.EntityGroupingMode = SwqlStudio.EntityGroupingMode.Flat;
            this.objectExplorer.ImageList = this.ObjectExplorerImageList;
            this.objectExplorer.Location = new System.Drawing.Point(0, 0);
            this.objectExplorer.Name = "objectExplorer";
            this.objectExplorer.Size = new System.Drawing.Size(191, 571);
            this.objectExplorer.TabIndex = 0;
            // 
            // ObjectExplorerImageList
            // 
            this.ObjectExplorerImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ObjectExplorerImageList.ImageStream")));
            this.ObjectExplorerImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ObjectExplorerImageList.Images.SetKeyName(0, "Column");
            this.ObjectExplorerImageList.Images.SetKeyName(1, "Database");
            this.ObjectExplorerImageList.Images.SetKeyName(2, "Link");
            this.ObjectExplorerImageList.Images.SetKeyName(3, "Table");
            this.ObjectExplorerImageList.Images.SetKeyName(4, "InheritedColumn");
            this.ObjectExplorerImageList.Images.SetKeyName(5, "KeyColumn");
            this.ObjectExplorerImageList.Images.SetKeyName(6, "Verb");
            this.ObjectExplorerImageList.Images.SetKeyName(7, "Argument");
            this.ObjectExplorerImageList.Images.SetKeyName(8, "Indication");
            this.ObjectExplorerImageList.Images.SetKeyName(9, "Namespace");
            this.ObjectExplorerImageList.Images.SetKeyName(10, "BaseType");
            this.ObjectExplorerImageList.Images.SetKeyName(11, "BaseTypeAbstract");
            this.ObjectExplorerImageList.Images.SetKeyName(12, "TableAbstract");
            // 
            // startTimer
            // 
            this.startTimer.Tick += new System.EventHandler(this.startTimer_Tick);
            // 
            // menuFileClose2
            // 
            this.menuFileClose2.Name = "menuFileClose2";
            this.menuFileClose2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.menuFileClose2.Size = new System.Drawing.Size(217, 22);
            this.menuFileClose2.Text = "Close";
            this.menuFileClose2.Visible = false;
            this.menuFileClose2.Click += new System.EventHandler(this.menuFileClose_Click);
            // 
            // menuFileTabPage
            // 
            this.menuFileTabPage.Name = "menuFileTabPage";
            this.menuFileTabPage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.menuFileTabPage.Size = new System.Drawing.Size(217, 22);
            this.menuFileTabPage.Text = "Tab Page";
            this.menuFileTabPage.Click += new System.EventHandler(this.menuFileTabPage_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 595);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "SWQL Studio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TextEditor_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextEditorForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextEditorForm_DragEnter);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private SwqlStudio.Controls.TabControlEx fileTabs;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuFileClose;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuEditCut;
        private System.Windows.Forms.ToolStripMenuItem menuEditCopy;
        private System.Windows.Forms.ToolStripMenuItem menuEditPaste;
        private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuQueryExecute;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ObjectExplorer objectExplorer;
        private System.Windows.Forms.ImageList ObjectExplorerImageList;
        private System.Windows.Forms.Timer startTimer;
        private System.Windows.Forms.ToolStripMenuItem parametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enumEntitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSWQLStudioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuNotificationListenerActive;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupEntityTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byNamespaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noGroupingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byBaseTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byHierarchyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuFileClose2;
        private System.Windows.Forms.ToolStripMenuItem menuFileTabPage;
    }
}

