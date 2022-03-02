using SwqlStudio.Utils;

namespace SwqlStudio
{
    partial class DocumentationContent
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
            this.itemTypeLabel = new System.Windows.Forms.Label();
            this.docTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // itemTypeLabel
            // 
            this.itemTypeLabel.AutoSize = true;
            this.itemTypeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemTypeLabel.Font = new System.Drawing.Font(DpiHelper.DefaultFont, System.Drawing.FontStyle.Bold);
            this.itemTypeLabel.Location = new System.Drawing.Point(0, 0);
            this.itemTypeLabel.Name = "itemTypeLabel";
            this.itemTypeLabel.Padding = new System.Windows.Forms.Padding(3);
            this.itemTypeLabel.Size = new System.Drawing.Size(6, 19);
            this.itemTypeLabel.TabIndex = 2;
            // 
            // docTextBox
            // 
            this.docTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.docTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docTextBox.Location = new System.Drawing.Point(0, 19);
            this.docTextBox.Name = "docTextBox";
            this.docTextBox.ReadOnly = true;
            this.docTextBox.Size = new System.Drawing.Size(284, 242);
            this.docTextBox.TabIndex = 3;
            this.docTextBox.Text = "";
            // 
            // DocumentationContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.docTextBox);
            this.Controls.Add(this.itemTypeLabel);
            this.Name = "DocumentationContent";
            this.Text = "Documentation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label itemTypeLabel;
        private System.Windows.Forms.RichTextBox docTextBox;
    }
}
