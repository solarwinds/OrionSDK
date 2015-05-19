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
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
            System.Windows.Forms.Button ok;
            System.Windows.Forms.Button cancel;
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ok = new System.Windows.Forms.Button();
            cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(284, 231);
            this.dataGridView1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(cancel);
            flowLayoutPanel1.Controls.Add(ok);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 231);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(284, 31);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // ok
            // 
            ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            ok.Location = new System.Drawing.Point(125, 3);
            ok.Name = "ok";
            ok.Size = new System.Drawing.Size(75, 23);
            ok.TabIndex = 0;
            ok.Text = "OK";
            ok.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancel.Location = new System.Drawing.Point(206, 3);
            cancel.Name = "cancel";
            cancel.Size = new System.Drawing.Size(75, 23);
            cancel.TabIndex = 1;
            cancel.Text = "Cancel";
            cancel.UseVisualStyleBackColor = true;
            // 
            // QueryParameters
            // 
            this.AcceptButton = ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = cancel;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(flowLayoutPanel1);
            this.MinimizeBox = false;
            this.Name = "QueryParameters";
            this.Text = "QueryParameters";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
    }
}