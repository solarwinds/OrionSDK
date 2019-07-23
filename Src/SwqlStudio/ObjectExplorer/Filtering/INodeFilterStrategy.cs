using System.Windows.Forms;

namespace SwqlStudio.Filtering
{
    internal interface INodeFilterStrategy
    {
        void Initialize(TreeNode node);
        VisibilityStatus GetVisibility(TreeNode node);
    }
}
