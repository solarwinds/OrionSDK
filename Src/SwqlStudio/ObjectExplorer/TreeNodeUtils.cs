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
        /// 
        /// filter method is called for each data node, and if returns false, display node is not created (and data children are not iterated)
        /// updateAction is called for each newly created display node, first parameter is data node, second one is display node
        /// </summary>
        /// <returns></returns>
        public static TreeNodeBindings CopyTree(TreeView data, TreeView display, Func<TreeNode, bool> filter, Action<TreeNode, TreeNode> updateAction)
        {
            var bindings = new TreeNodeBindings();
            display.Nodes.Clear();
            CopyTree(data.Nodes, display.Nodes, bindings, 
                filter ?? (_ => true), 
                updateAction ?? ((dataNode, displayNode) => { }));
            return bindings;
        }

        private static void CopyTree(TreeNodeCollection source, TreeNodeCollection target, TreeNodeBindings bindings, Func<TreeNode, bool> filter, Action<TreeNode, TreeNode> updateAction)
        {
            foreach (TreeNode node in source)
            {
                if (!filter(node))
                    continue;

                TreeNode newNode;
                if (node is TreeNodeWithConnectionInfo)
                    newNode = ((TreeNodeWithConnectionInfo) node).CloneShallow();
                else
                {
                    newNode = CloneShallow(node);
                }

                

                target.Add(newNode);
                bindings.BindNodes(node, newNode);
                CopyTree(node.Nodes, newNode.Nodes, bindings, filter, updateAction);

                if (node.IsExpanded)
                    newNode.Expand();

                updateAction(node, newNode);
            }
        }

        // we need copy without children
        private static TreeNode CloneShallow(TreeNode node)
        {
            var treeNode = new TreeNode();
            CopyContent(node, treeNode);
            return treeNode;
        }

        internal static void CopyContent(TreeNode source, TreeNode target)
        {
            target.Text = source.Text;
            target.Name = source.Name;
            target.ImageIndex = source.ImageIndex;
            target.SelectedImageIndex = source.SelectedImageIndex;
            target.StateImageIndex = source.StateImageIndex;

            target.SelectedImageKey = source.SelectedImageKey;
            target.ImageKey = source.ImageKey;
            target.Tag = source.Tag;

            target.ToolTipText = source.ToolTipText;
            target.ContextMenu = source.ContextMenu;
            target.ContextMenuStrip = source.ContextMenuStrip;
            target.Checked = source.Checked;
        }

        /// <summary>
        /// Used in filtering of the nodes.
        /// 
        /// Keeps track of visibility of each single one
        /// </summary>
        public class NodeVisibility
        {
            private readonly Dictionary<TreeNode, VisibilityStatus> _visibility = new Dictionary<TreeNode, VisibilityStatus>(ReferenceEqualityComparer.Default);


            public void SetVisible(TreeNode node)
            {
                _visibility[node] = VisibilityStatus.Visible;
                for (var parent = node.Parent; parent != null; parent = parent.Parent)
                {
                    _visibility.TryGetValue(parent, out var parentVisibility);
                    if (parentVisibility != VisibilityStatus.Visible)
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

            public enum VisibilityStatus
            {
                /// <summary>
                /// This node is not visible
                /// </summary>
                NotVisible,
                /// <summary>
                /// Some children of this node passed filter
                /// </summary>
                ChildVisible,
                /// <summary>
                /// This node passed filter
                /// </summary>
                Visible,
                /// <summary>
                /// This node's parent passed filter
                /// </summary>
                ParentVisible
            }
        }

        /// <summary>
        /// used for being able to get 'data' node from 'display' (and back).
        /// 
        /// useful, when someone for example expands display node, we want to sync that to data.
        /// </summary>
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

        /// <summary>
        /// Does DFS walk through the tree.
        /// </summary>
        /// <param name="treeData"></param>
        /// <param name="action"></param>
        public static void IterateNodes(TreeView treeData, Action<TreeNode> action)
        {
            IterateNodes(treeData.Nodes, action);
        }

        private static void IterateNodes(TreeNodeCollection nodes, Action<TreeNode> action)
        {
            foreach(TreeNode node in nodes)
            {
                action(node);
                IterateNodes(node.Nodes, action);
            }
        }
    }
}
