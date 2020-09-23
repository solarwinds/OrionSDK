using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SwqlStudio.Filtering
{
    /// <summary>
    /// Used in filtering of the nodes in Object explorer. It filters based on provided keyword (filter)
    /// Everything that match pattern is marked as Visible and all parents of visible nodes are marked as ChildVisible.
    /// Everything that does not match is considered NotVisible or ParentVisible if there is explicitly visible parent.
    /// </summary>
    internal class SearchNodeFilter : INodeFilterStrategy
    {
        private readonly string _filter;

        private readonly Dictionary<TreeNode, VisibilityStatus> _visibility = new Dictionary<TreeNode, VisibilityStatus>(TreeNodeUtils.ReferenceEqualityComparer.Default);

        public SearchNodeFilter(string filter)
        {
            _filter = filter;
        }

        public void Initialize(TreeNode node)
        {
            if (PassesFilter(node))
                SetVisible(node);
        }

        private void SetVisible(TreeNode node)
        {
            _visibility[node] = VisibilityStatus.Visible;
            for (var parent = node.Parent; parent != null; parent = parent.Parent)
            {
                _visibility.TryGetValue(parent, out var parentVisibility);
                if (parentVisibility != VisibilityStatus.Visible)//for deprecated we care for entity only
                    parentVisibility = VisibilityStatus.ChildVisible;

                _visibility[parent] = parentVisibility;
            }
        }

        public VisibilityStatus GetVisibility(TreeNode node)
        {
            if (!_visibility.TryGetValue(node, out var rv))
            {
                rv = VisibilityStatus.NotVisible;
                // check if some of the parents is not directly visible (visible, not childvisible)
                for (var parent = node.Parent; parent != null; parent = parent.Parent)
                {
                    if (_visibility.TryGetValue(parent, out var parentVisibility))
                    {
                        if (parentVisibility == VisibilityStatus.Visible)
                            rv = VisibilityStatus.ParentVisible;
                        else
                            break;
                    }
                }
            }

            return rv;
        }

        private bool PassesFilter(TreeNode node)
        {
            var nodeText = node.Text.Split('(')[0]; // trim everything after first (, we do not want to use it in search

            if (_filter == null || nodeText.IndexOf(_filter, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;

            else // behave in 'special' way for dots, and capitals, the same way as resharper does
                 // let's Met.Ent match also METadata...ENTity
                 // also Met.EntNa should match Metadata.EntityName
            {
                var filter = SplitTextByCapsAndDot(_filter);
                var text = SplitTextByCapsAndDot(nodeText);

                int textPivot = 0;

                for (int filterPivot = 0; filterPivot < filter.Count; filterPivot++)
                {
                    for (; textPivot <= text.Count; textPivot++)
                    {
                        if (textPivot == text.Count)
                            return false;

                        if (text[textPivot].StartsWith(filter[filterPivot], StringComparison.OrdinalIgnoreCase))
                            break;
                    }
                    textPivot++;
                }

                return true;
            }
        }

        private static List<string> SplitTextByCapsAndDot(string text)
        {
            var rv = new List<string>();

            var buf = new StringBuilder();

            void FlushBuffer()
            {
                if (buf.Length > 0)
                    rv.Add(buf.ToString());

                buf.Clear();
            }

            foreach (var t in text)
            {
                if (t == '.')
                {
                    FlushBuffer();
                }
                else
                {
                    if (char.IsUpper(t))
                        FlushBuffer();

                    buf.Append(t);
                }
            }

            FlushBuffer();
            return rv;
        }
    }
}
