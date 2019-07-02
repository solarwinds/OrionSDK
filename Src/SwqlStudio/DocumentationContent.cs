using System.Drawing.Design;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace SwqlStudio
{
    public partial class DocumentationContent : DockContent
    {
        public DocumentationContent()
        {
            InitializeComponent();
        }

        public void UpdateDocumentation(TreeNode newNode)
        {
            if (newNode != null)
            {
                this.docTextBox.Text = newNode.Text;
                this.docTextBox.AppendText(newNode.ToolTipText);
                
                this.docTextBox.AppendText("\r\n\r\n ");
                var doc = DocumentationBuilder.Build(newNode);
                this.docTextBox.AppendText(doc);
            }
        }
    }
}
