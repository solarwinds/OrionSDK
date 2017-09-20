using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace SwqlStudio
{
    internal static class TreeNodeUtils
    {
        /// <summary>
        /// Copies tree from data to display.
        /// Returns "bindings", mapping data->display (so, if you have data node, you can find it's counterpart on display)
        /// </summary>
        /// <returns></returns>
        public static TreeNodeBindings CopyTree(TreeView data, TreeView display)
        {
            var bindings = new TreeNodeBindings();
            display.Nodes.Clear();
            CopyTree(data.Nodes, display.Nodes, bindings);
            return bindings;
        }

        private static void CopyTree(TreeNodeCollection source, TreeNodeCollection target, TreeNodeBindings bindings)
        {
            foreach (TreeNode node in source)
            {
                TreeNode newNode;
                if (node is TreeNodeWithConnectionInfo)
                    newNode = ((TreeNodeWithConnectionInfo) node).CloneShallow();
                else
                {
                    newNode = CloneShallow(node);
                }
                target.Add(newNode);
                bindings.BindNodes(node, newNode);
                CopyTree(node.Nodes, newNode.Nodes, bindings);
                if (node.IsExpanded)
                    newNode.Expand();
            }
        }

        // we need copy without children
        private static TreeNode CloneShallow(TreeNode node)
        {
            var treeNode = new TreeNode();
            treeNode.Text = node.Text;
            treeNode.Name = node.Name;
            treeNode.ImageIndex = node.ImageIndex;
            treeNode.SelectedImageIndex = node.SelectedImageIndex;
            treeNode.StateImageIndex = node.StateImageIndex;

            treeNode.SelectedImageKey = node.SelectedImageKey;
            treeNode.ImageKey = node.ImageKey;
            treeNode.Tag = node.Tag;

            treeNode.ToolTipText = node.ToolTipText;
            treeNode.ContextMenu = node.ContextMenu;
            treeNode.ContextMenuStrip = node.ContextMenuStrip;
            treeNode.Checked = node.Checked;
            return treeNode;
        }

        public class TreeNodeBindings
        {
            private readonly Dictionary<TreeNode, TreeNode> _bindingsData2Display =
                new Dictionary<TreeNode, TreeNode>(ReferenceEqualityComparer.Default);

            private readonly Dictionary<TreeNode, TreeNode> _bindingsDisplay2Data =
                new Dictionary<TreeNode, TreeNode>(ReferenceEqualityComparer.Default);

            public void BindNodes(TreeNode dataNode, TreeNode displayNode)
            {
                _bindingsData2Display.Add(dataNode, displayNode);
                _bindingsDisplay2Data.Add(displayNode, dataNode);
            }

            public TreeNode FindDisplayNode(TreeNode dataTreeNode)
            {
                if (dataTreeNode == null)
                    return null;

                _bindingsData2Display.TryGetValue(dataTreeNode, out var rv);
                return rv;
            }

            public TreeNode FindDataNode(TreeNode displayTreeNode)
            {
                if (displayTreeNode == null)
                    return null;

                _bindingsDisplay2Data.TryGetValue(displayTreeNode, out var rv);
                return rv;
            }
        }
        private sealed class ReferenceEqualityComparer : IEqualityComparer, IEqualityComparer<object>
        {
            public static ReferenceEqualityComparer Default { get; } = new ReferenceEqualityComparer();

            public new bool Equals(object x, object y) => ReferenceEquals(x, y);
            public int GetHashCode(object obj) => RuntimeHelpers.GetHashCode(obj);
        }
    }
}
