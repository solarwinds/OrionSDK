using System;
using System.Windows.Forms;

namespace SwqlStudio
{
    public class TreeNodeWithConnectionInfo : TreeNode, ICloneable
    {
        public TreeNodeWithConnectionInfo(string text, ConnectionInfo connection) : base(text)
        {
            Connection = connection;
        }

        public TreeNode CloneShallow()
        {
            var treeNode = new TreeNodeWithConnectionInfo(Text, Connection);
            treeNode.Text = Text;
            treeNode.Name = Name;
            treeNode.ImageIndex = ImageIndex;
            treeNode.SelectedImageIndex = SelectedImageIndex;
            treeNode.StateImageIndex = StateImageIndex;

            treeNode.SelectedImageKey = SelectedImageKey;
            treeNode.ImageKey = ImageKey;
            treeNode.Tag = Tag;
            
            treeNode.ToolTipText = ToolTipText;
            treeNode.ContextMenu = ContextMenu;
            treeNode.ContextMenuStrip = ContextMenuStrip;
            treeNode.Checked = Checked;
            return treeNode;
        }

        public ConnectionInfo Connection { get; private set; }
    }
}
