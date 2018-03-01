namespace SwqlStudio
{
    partial class QueryParameters
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
            this.parametersGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.parametersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // parametersGrid
            // 
            this.parametersGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.parametersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parametersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametersGrid.Location = new System.Drawing.Point(0, 0);
            this.parametersGrid.Name = "parametersGrid";
            this.parametersGrid.Size = new System.Drawing.Size(284, 262);
            this.parametersGrid.TabIndex = 0;
            // 
            // QueryParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.parametersGrid);
            this.MinimizeBox = false;
            this.Name = "QueryParameters";
            this.ShowIcon = false;
            this.Text = "QueryParameters";
            ((System.ComponentModel.ISupportInitialize)(this.parametersGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView parametersGrid;
    }
}