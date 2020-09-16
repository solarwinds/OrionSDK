using System.Windows.Forms;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal class ArgumentsPlaceholderTreeNode : TreeNode
    {
        public Verb Verb { get; set; }
        public IMetadataProvider Provider { get; set; }

        public ArgumentsPlaceholderTreeNode(Verb verb, IMetadataProvider provider)
        {
            Verb = verb;
            Provider = provider;
        }
    }
}
