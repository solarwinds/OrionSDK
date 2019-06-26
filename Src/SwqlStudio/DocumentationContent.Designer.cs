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
            this.docTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // docTextBox
            // 
            this.docTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.docTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docTextBox.Location = new System.Drawing.Point(5, 5);
            this.docTextBox.Name = "docTextBox";
            this.docTextBox.ReadOnly = true;
            this.docTextBox.Size = new System.Drawing.Size(274, 251);
            this.docTextBox.TabIndex = 1;
            this.docTextBox.Text = "";
            // 
            // DocumentationContent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.docTextBox);
            this.Name = "DocumentationContent";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Documentation";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox docTextBox;
    }
}
