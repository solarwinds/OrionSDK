using System.Collections.Generic;
using System.Windows.Forms;
using SwqlStudio.Metadata;

namespace SwqlStudio.Filtering
{
    /// <summary>
    /// Filtering strategy marks as not visible (VisibilityStatus.None) nodes that does not have visible children nodes.
    /// All other nodes are marked with no special visibility status (VisibilityStatus.None).
    /// </summary>
    internal class ObsoleteNodeFilter : INodeFilterStrategy
    {
        private readonly Dictionary<TreeNode, VisibilityStatus> _visibility = new Dictionary<TreeNode, VisibilityStatus>(TreeNodeUtils.ReferenceEqualityComparer.Default);

        public void Initialize(TreeNode node)
        {
            InitializeObsoleteVisibility(node);
        }

        public VisibilityStatus GetVisibility(TreeNode node) => _visibility.ContainsKey(node) ? _visibility[node] : VisibilityStatus.None;

        private void InitializeObsoleteVisibility(TreeNode node)
        {
            if (!_visibility.ContainsKey(node))
            {
                _visibility[node] = IsObsolete(node) ? VisibilityStatus.NotVisible : VisibilityStatus.None;
            }
        }

        public bool IsObsolete(TreeNode node)
        {
            var tag = node?.Tag as IObsoleteMetadata;

            return tag != null && tag.IsObsolete && !HasVisibleChildEntity(node);
        }

        private bool HasVisibleChildEntity(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                return false;
            }

            if (_visibility.ContainsKey(node))
            {
                return _visibility[node] == VisibilityStatus.None;
            }

            foreach (TreeNode child in node.Nodes)
            {
                var tag = child?.Tag as Entity;
                if (tag != null && (!tag.IsObsolete || HasVisibleChildEntity(child)))
                {
                    _visibility.Add(node, VisibilityStatus.None);
                    return true;
                }
            }

            _visibility.Add(node, VisibilityStatus.NotVisible);
            return false;
        }
    }
}
