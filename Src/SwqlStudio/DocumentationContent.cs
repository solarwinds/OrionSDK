using System.Windows.Forms;
using SwqlStudio.Utils;
using WeifenLuo.WinFormsUI.Docking;

namespace SwqlStudio
{
    public partial class DocumentationContent : DockContent
    {
        public DocumentationContent()
        {
            DpiHelper.FixFont(this);
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
