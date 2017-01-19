namespace SwqlStudio
{
    partial class SubscriptionTab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubscriptionTab));
            this.NotificationsImageList = new System.Windows.Forms.ImageList(this.components);
            this.NotificationsTreeView = new System.Windows.Forms.TreeView();
            this.treeViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotificationsImageList
            // 
            this.NotificationsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("NotificationsImageList.ImageStream")));
            this.NotificationsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.NotificationsImageList.Images.SetKeyName(0, "Dotted Line.ico");
            this.NotificationsImageList.Images.SetKeyName(1, "Created.png");
            this.NotificationsImageList.Images.SetKeyName(2, "Changed.png");
            this.NotificationsImageList.Images.SetKeyName(3, "Deleted.png");
            this.NotificationsImageList.Images.SetKeyName(4, "Custom.png");
            // 
            // NotificationsTreeView
            // 
            this.NotificationsTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NotificationsTreeView.ContextMenuStrip = this.treeViewMenuStrip;
            this.NotificationsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotificationsTreeView.ImageIndex = 0;
            this.NotificationsTreeView.ImageList = this.NotificationsImageList;
            this.NotificationsTreeView.Location = new System.Drawing.Point(0, 0);
            this.NotificationsTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.NotificationsTreeView.Name = "NotificationsTreeView";
            this.NotificationsTreeView.SelectedImageIndex = 0;
            this.NotificationsTreeView.Size = new System.Drawing.Size(150, 150);
            this.NotificationsTreeView.TabIndex = 5;
            this.NotificationsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.NotificationsTreeView_NodeMouseClick);
            // 
            // treeViewMenuStrip
            // 
            this.treeViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.treeViewMenuStrip.Name = "treeViewMenuStrip";
            this.treeViewMenuStrip.Size = new System.Drawing.Size(103, 26);
            this.treeViewMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.treeViewMenuStrip_Opening);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // SubscriptionTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NotificationsTreeView);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SubscriptionTab";
            this.treeViewMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList NotificationsImageList;
        private System.Windows.Forms.TreeView NotificationsTreeView;
        private System.Windows.Forms.ContextMenuStrip treeViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    }
}
