using System.Windows.Forms;
using ScintillaNET;

namespace SwqlStudio
{
    partial class QueryTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResultsAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryWorker = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sciTextEditorControl1 = new SwqlStudio.SciTextEditorControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.resultTab = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.queryPlanTab = new System.Windows.Forms.TabPage();
            this.xmlBrowser1 = new SwqlStudio.XmlRender.XmlBrowser();
            this.queryStatsTab = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.rawXmlTab = new System.Windows.Forms.TabPage();
            this.rawXmlBrowser = new SwqlStudio.XmlRender.XmlBrowser();
            this.errorMessagesTab = new System.Windows.Forms.TabPage();
            this.errorMessagesBrowser = new SwqlStudio.XmlRender.XmlBrowser();
            this.logTab = new System.Windows.Forms.TabPage();
            this.logTextbox = new System.Windows.Forms.TextBox();
            this.notificationTab = new System.Windows.Forms.TabPage();
            this.subscriptionTab1 = new SwqlStudio.SubscriptionTab();
            this.queryStatusBar1 = new SwqlStudio.QueryStatusBar();
            this.subscriptionWorker = new System.ComponentModel.BackgroundWorker();
            this.delayTimer = new System.Windows.Forms.Timer(this.components);
            this.gridContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.resultTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.queryPlanTab.SuspendLayout();
            this.queryStatsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.rawXmlTab.SuspendLayout();
            this.errorMessagesTab.SuspendLayout();
            this.logTab.SuspendLayout();
            this.notificationTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridContextMenuStrip
            // 
            this.gridContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.saveResultsAsToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.gridContextMenuStrip.Name = "gridContextMenuStrip";
            this.gridContextMenuStrip.Size = new System.Drawing.Size(162, 70);
            this.gridContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.gridContextMenuStrip_Opening);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem2.Text = "&Copy";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // saveResultsAsToolStripMenuItem
            // 
            this.saveResultsAsToolStripMenuItem.Name = "saveResultsAsToolStripMenuItem";
            this.saveResultsAsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.saveResultsAsToolStripMenuItem.Text = "&Save Results as...";
            this.saveResultsAsToolStripMenuItem.Click += new System.EventHandler(this.saveResultsAsToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // queryWorker
            // 
            this.queryWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.queryWorker_DoWork);
            this.queryWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.queryWorker_RunWorkerCompleted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sciTextEditorControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(474, 353);
            this.splitContainer1.SplitterDistance = 117;
            this.splitContainer1.TabIndex = 0;
            // 
            // sciTextEditorControl1
            // 
            this.sciTextEditorControl1.AutoCIgnoreCase = true;
            this.sciTextEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sciTextEditorControl1.FileName = null;
            this.sciTextEditorControl1.Lexer = ScintillaNET.Lexer.Sql;
            this.sciTextEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.sciTextEditorControl1.Margin = new System.Windows.Forms.Padding(0);
            this.sciTextEditorControl1.Name = "sciTextEditorControl1";
            this.sciTextEditorControl1.Size = new System.Drawing.Size(474, 117);
            this.sciTextEditorControl1.TabIndex = 0;
            this.sciTextEditorControl1.UseTabs = false;
            this.sciTextEditorControl1.WrapMode = ScintillaNET.WrapMode.Word;
            this.sciTextEditorControl1.TextChanged += new System.EventHandler(this.sciTextEditorControl1_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.resultTab);
            this.tabControl1.Controls.Add(this.queryPlanTab);
            this.tabControl1.Controls.Add(this.queryStatsTab);
            this.tabControl1.Controls.Add(this.rawXmlTab);
            this.tabControl1.Controls.Add(this.errorMessagesTab);
            this.tabControl1.Controls.Add(this.logTab);
            this.tabControl1.Controls.Add(this.notificationTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(474, 232);
            this.tabControl1.TabIndex = 0;
            // 
            // resultTab
            // 
            this.resultTab.Controls.Add(this.dataGridView1);
            this.resultTab.Location = new System.Drawing.Point(4, 4);
            this.resultTab.Name = "resultTab";
            this.resultTab.Size = new System.Drawing.Size(466, 206);
            this.resultTab.TabIndex = 0;
            this.resultTab.Text = "Results";
            this.resultTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.gridContextMenuStrip;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(466, 206);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // queryPlanTab
            // 
            this.queryPlanTab.Controls.Add(this.xmlBrowser1);
            this.queryPlanTab.Location = new System.Drawing.Point(4, 4);
            this.queryPlanTab.Name = "queryPlanTab";
            this.queryPlanTab.Size = new System.Drawing.Size(466, 206);
            this.queryPlanTab.TabIndex = 2;
            this.queryPlanTab.Text = "Query Plan";
            this.queryPlanTab.UseVisualStyleBackColor = true;
            // 
            // xmlBrowser1
            // 
            this.xmlBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlBrowser1.Location = new System.Drawing.Point(0, 0);
            this.xmlBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.xmlBrowser1.Name = "xmlBrowser1";
            this.xmlBrowser1.Size = new System.Drawing.Size(466, 206);
            this.xmlBrowser1.TabIndex = 0;
            this.xmlBrowser1.XmlDocument = null;
            this.xmlBrowser1.XmlDocumentTransformType = SwqlStudio.XmlRender.XmlBrowser.XslTransformType.XSL;
            this.xmlBrowser1.XmlText = "";
            // 
            // queryStatsTab
            // 
            this.queryStatsTab.Controls.Add(this.dataGridView2);
            this.queryStatsTab.Location = new System.Drawing.Point(4, 4);
            this.queryStatsTab.Name = "queryStatsTab";
            this.queryStatsTab.Size = new System.Drawing.Size(466, 206);
            this.queryStatsTab.TabIndex = 2;
            this.queryStatsTab.Text = "Query Stats";
            this.queryStatsTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ContextMenuStrip = this.gridContextMenuStrip;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(466, 206);
            this.dataGridView2.TabIndex = 0;
            // 
            // rawXmlTab
            // 
            this.rawXmlTab.Controls.Add(this.rawXmlBrowser);
            this.rawXmlTab.Location = new System.Drawing.Point(4, 4);
            this.rawXmlTab.Name = "rawXmlTab";
            this.rawXmlTab.Size = new System.Drawing.Size(466, 206);
            this.rawXmlTab.TabIndex = 3;
            this.rawXmlTab.Text = "Raw XML";
            this.rawXmlTab.UseVisualStyleBackColor = true;
            // 
            // rawXmlBrowser
            // 
            this.rawXmlBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawXmlBrowser.Location = new System.Drawing.Point(0, 0);
            this.rawXmlBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.rawXmlBrowser.Name = "rawXmlBrowser";
            this.rawXmlBrowser.Size = new System.Drawing.Size(466, 206);
            this.rawXmlBrowser.TabIndex = 0;
            this.rawXmlBrowser.XmlDocument = null;
            this.rawXmlBrowser.XmlDocumentTransformType = SwqlStudio.XmlRender.XmlBrowser.XslTransformType.XSL;
            this.rawXmlBrowser.XmlText = "";
            // 
            // errorMessagesTab
            // 
            this.errorMessagesTab.Controls.Add(this.errorMessagesBrowser);
            this.errorMessagesTab.Location = new System.Drawing.Point(4, 4);
            this.errorMessagesTab.Name = "errorMessagesTab";
            this.errorMessagesTab.Size = new System.Drawing.Size(466, 206);
            this.errorMessagesTab.TabIndex = 4;
            this.errorMessagesTab.Text = "Errors";
            this.errorMessagesTab.UseVisualStyleBackColor = true;
            // 
            // errorMessagesBrowser
            // 
            this.errorMessagesBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorMessagesBrowser.Location = new System.Drawing.Point(0, 0);
            this.errorMessagesBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.errorMessagesBrowser.Name = "errorMessagesBrowser";
            this.errorMessagesBrowser.Size = new System.Drawing.Size(466, 206);
            this.errorMessagesBrowser.TabIndex = 0;
            this.errorMessagesBrowser.XmlDocument = null;
            this.errorMessagesBrowser.XmlDocumentTransformType = SwqlStudio.XmlRender.XmlBrowser.XslTransformType.XSL;
            this.errorMessagesBrowser.XmlText = "";
            // 
            // logTab
            // 
            this.logTab.Controls.Add(this.logTextbox);
            this.logTab.Location = new System.Drawing.Point(4, 4);
            this.logTab.Name = "logTab";
            this.logTab.Size = new System.Drawing.Size(466, 206);
            this.logTab.TabIndex = 4;
            this.logTab.Text = "Log";
            this.logTab.UseVisualStyleBackColor = true;
            // 
            // logTextbox
            // 
            this.logTextbox.BackColor = System.Drawing.SystemColors.Window;
            this.logTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextbox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTextbox.Location = new System.Drawing.Point(0, 0);
            this.logTextbox.Multiline = true;
            this.logTextbox.Name = "logTextbox";
            this.logTextbox.ReadOnly = true;
            this.logTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextbox.Size = new System.Drawing.Size(466, 206);
            this.logTextbox.TabIndex = 0;
            // 
            // notificationTab
            // 
            this.notificationTab.Controls.Add(this.subscriptionTab1);
            this.notificationTab.Location = new System.Drawing.Point(4, 4);
            this.notificationTab.Margin = new System.Windows.Forms.Padding(0);
            this.notificationTab.Name = "notificationTab";
            this.notificationTab.Size = new System.Drawing.Size(466, 206);
            this.notificationTab.TabIndex = 5;
            this.notificationTab.Text = "Notifications";
            this.notificationTab.UseVisualStyleBackColor = true;
            // 
            // subscriptionTab1
            // 
            this.subscriptionTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subscriptionTab1.Location = new System.Drawing.Point(0, 0);
            this.subscriptionTab1.Margin = new System.Windows.Forms.Padding(0);
            this.subscriptionTab1.Name = "subscriptionTab1";
            this.subscriptionTab1.Size = new System.Drawing.Size(466, 206);
            this.subscriptionTab1.TabIndex = 0;
            // 
            // queryStatusBar1
            // 
            this.queryStatusBar1.Location = new System.Drawing.Point(0, 353);
            this.queryStatusBar1.Name = "queryStatusBar1";
            this.queryStatusBar1.Padding = new System.Windows.Forms.Padding(0);
            this.queryStatusBar1.Size = new System.Drawing.Size(474, 22);
            this.queryStatusBar1.SizingGrip = false;
            this.queryStatusBar1.TabIndex = 1;
            this.queryStatusBar1.Text = "queryStatusBar1";
            // 
            // subscriptionWorker
            // 
            this.subscriptionWorker.WorkerReportsProgress = true;
            this.subscriptionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.subscriptionWorker_DoWork);
            this.subscriptionWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.subscriptionWorker_ProgressChanged);
            this.subscriptionWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.subscriptionWorker_RunWorkerCompleted);
            // 
            // delayTimer
            // 
            this.delayTimer.Tick += new System.EventHandler(this.delayTimer_Tick);
            // 
            // QueryTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.queryStatusBar1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "QueryTab";
            this.Size = new System.Drawing.Size(474, 375);
            this.gridContextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.resultTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.queryPlanTab.ResumeLayout(false);
            this.queryStatsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.rawXmlTab.ResumeLayout(false);
            this.errorMessagesTab.ResumeLayout(false);
            this.logTab.ResumeLayout(false);
            this.logTab.PerformLayout();
            this.notificationTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private SciTextEditorControl sciTextEditorControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage resultTab;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private QueryStatusBar queryStatusBar1;
        private System.Windows.Forms.ContextMenuStrip gridContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem saveResultsAsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker queryWorker;
        private System.Windows.Forms.TabPage queryPlanTab;
        private System.Windows.Forms.TabPage queryStatsTab;
        private XmlRender.XmlBrowser xmlBrowser1;
        private XmlRender.XmlBrowser errorMessagesBrowser;
        private System.Windows.Forms.TabPage rawXmlTab;
        private System.Windows.Forms.TabPage errorMessagesTab;
        private XmlRender.XmlBrowser rawXmlBrowser;
        private System.Windows.Forms.TabPage logTab;
        private System.Windows.Forms.TextBox logTextbox;
        private System.Windows.Forms.TabPage notificationTab;
        private SubscriptionTab subscriptionTab1;
        private System.ComponentModel.BackgroundWorker subscriptionWorker;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private Timer delayTimer;
    }
}
