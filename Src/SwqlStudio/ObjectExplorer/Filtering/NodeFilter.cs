using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SwqlStudio.Metadata;
using SwqlStudio.Properties;

namespace SwqlStudio.Filtering
{
    internal class NodeFilter
    {
        private readonly List<INodeFilterStrategy> _filters = new List<INodeFilterStrategy>();
        private const int _limitOfExpandedNodes = 5000;
        private int _visibleNodesCount;

        public NodeFilter(TreeView treeData, string filter)
        {
            InitializeFilters(treeData, filter);
        }

        private void InitializeFilters(TreeView treeData, string filter)
        {
            if (!Settings.Default.ShowObsolete)
            {
                _filters.Add(new ObsoleteNodeFilter());
            }
            if (filter != null)
            {
                _filters.Add(new SearchNodeFilter(filter));
            }

            TreeNodeUtils.IterateNodes(treeData, node => _filters.ForEach(strategy => strategy.Initialize(node)));

            TreeNodeUtils.IterateNodes(treeData, node =>
            {
                if (FilterAction(node)) _visibleNodesCount++;
            });
        }

        private VisibilityStatus NodeVisibility(TreeNode node) => _filters.Aggregate(VisibilityStatus.None, (current, filter) => current | filter.GetVisibility(node));

        internal bool FilterAction(TreeNode node) => !NodeVisibility(node).HasFlag(VisibilityStatus.NotVisible);

        internal void UpdateAction(TreeNode data, TreeNode display)
        {
            var nodeVisibility = NodeVisibility(data);

            if (nodeVisibility.HasFlag(VisibilityStatus.ChildVisible))
                // this one is not directly visible, gray it out
                display.ForeColor = ColorTranslator.FromHtml("#2BBDBE");

            else if (nodeVisibility.HasFlag(VisibilityStatus.ParentVisible))
                // this one is not directly visible, gray it out
                display.ForeColor = Color.DarkGray;

            // this one is visible directly, ensure it is visible (parents are expanded).
            // it's children are visible as well, but may be not expanded
            else if (nodeVisibility.HasFlag(VisibilityStatus.Visible))
            {
                //expand parents of visible node
                if (_visibleNodesCount < _limitOfExpandedNodes)
                {
                    display.EnsureVisible();
                }
                //If too many objects are visible, treeView performance drops dramatically.
                //In case of many object only entity level is expanded
                else
                {
                    if (data.Tag is Entity)
                    {
                        display.EnsureVisible();
                    }
                }
            }
        }
    }
}
