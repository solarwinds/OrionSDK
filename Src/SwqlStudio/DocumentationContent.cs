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
                var doc = DocumentationBuilder.Build(newNode);
                itemTypeLabel.Text = doc.ItemType;
                docTextBox.Text = doc.Documents;
            }
        }
    }
}
