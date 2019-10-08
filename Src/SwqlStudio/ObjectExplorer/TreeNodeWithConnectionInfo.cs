using System;
using System.Windows.Forms;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal class TreeNodeWithConnectionInfo : TreeNode
    {
        public IMetadataProvider Provider { get; }

        public ConnectionInfo Connection => this.Provider.ConnectionInfo;


        public TreeNodeWithConnectionInfo(string text, IMetadataProvider provider) : base(text)
        {
            Provider = provider;
        }

        public TreeNode CloneShallow()
        {
            var treeNode = new TreeNodeWithConnectionInfo(this.Text, this.Provider);
            TreeNodeUtils.CopyContent(this, treeNode);
            return treeNode;
        }
    }
}
