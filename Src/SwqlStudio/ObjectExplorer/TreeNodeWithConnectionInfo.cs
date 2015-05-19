using System.Windows.Forms;

namespace SwqlStudio
{
    internal class TreeNodeWithConnectionInfo : TreeNode
    {
        public TreeNodeWithConnectionInfo(string text, ConnectionInfo connection) : base(text)
        {
            Connection = connection;
        }

        public ConnectionInfo Connection { get; private set; }
    }
}
