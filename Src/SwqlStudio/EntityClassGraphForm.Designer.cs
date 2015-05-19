namespace SwqlStudio
{
    partial class EntityClassGraphForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityClassGraphForm));
            this.entityClassGraphTreeView = new System.Windows.Forms.TreeView();
            this.ObjectExplorerImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // entityClassGraphTreeView
            // 
            this.entityClassGraphTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityClassGraphTreeView.ImageIndex = 0;
            this.entityClassGraphTreeView.ImageList = this.ObjectExplorerImageList;
            this.entityClassGraphTreeView.Location = new System.Drawing.Point(0, 0);
            this.entityClassGraphTreeView.Name = "entityClassGraphTreeView";
            this.entityClassGraphTreeView.SelectedImageIndex = 0;
            this.entityClassGraphTreeView.Size = new System.Drawing.Size(377, 615);
            this.entityClassGraphTreeView.TabIndex = 0;
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
            // 
            // EntityClassGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 615);
            this.Controls.Add(this.entityClassGraphTreeView);
            this.Name = "EntityClassGraphForm";
            this.Text = "Entity Inheritance Graph";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView entityClassGraphTreeView;
        private System.Windows.Forms.ImageList ObjectExplorerImageList;
    }
}