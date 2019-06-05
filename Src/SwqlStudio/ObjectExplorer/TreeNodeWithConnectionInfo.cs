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
            TreeNodeUtils.CopyContent(this, treeNode);
            return treeNode;
        }

        public ConnectionInfo Connection { get; private set; }
    }
}
