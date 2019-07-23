using System;
using System.Text;
using System.Windows.Forms;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal class DocumentationBuilder
    {
        public static Documentation Build(TreeNode node)
        {
            var data = node.Tag;
            var connectedNode = node as TreeNodeWithConnectionInfo;
            var provider = connectedNode?.Provider;

            if (provider == null)
                return Documentation.Empty;

            if (data is SwisMetaDataProvider)
                return ProviderDocumentation(provider);

            if (data is string nameSpace)
                return NamespaceDocumentation(nameSpace, node.Nodes.Count);

            if (data is Entity entity)
                return EntityDocumentation(provider, entity);

            if (data is Property property)
                return PropertyDocumentation(property);

            if (data is Verb verb)
                return VerbDocumentation(verb);

            if (data is VerbArgument verbArg)
                return VerbArgumentDocumentation(verbArg);

            return Documentation.Empty;
        }

        private static Documentation VerbArgumentDocumentation(VerbArgument verbArg)
        {
            var docs = MetadataDocumentation(verbArg);
            return new Documentation("Verb argument", docs);
        }

        private static Documentation VerbDocumentation(Verb verb)
        {
            var builder = new StringBuilder();
            builder.AppendName(verb.Name);
            builder.AppendSummaryParagraph(verb.Summary);
            var docs = builder.ToString();
            return new Documentation("Verb", docs);
        }

        private static Documentation EntityDocumentation(IMetadataProvider provider, Entity entity)
        {
            var builder = new StringBuilder();
            builder.AppendName(entity.FullName);
            builder.Append($"Base type: {entity.BaseType}\r\n");
            builder.AppendAccessControl(provider.ConnectionInfo, entity);
            builder.AppendSummaryParagraph(entity.Summary);
            var docs = builder.ToString();
            return new Documentation("Entity", docs);
        }

        private static Documentation NamespaceDocumentation(string nameSpace, int childrenCount)
        {
            var builder = new StringBuilder();
            builder.AppendName(nameSpace);
            var children = ChildrenText(childrenCount);
            builder.Append(children);
            var docs = builder.ToString();
            return new Documentation("Namespace", docs);
        }

        private static Documentation PropertyDocumentation(Property property)
        {
            var docs = MetadataDocumentation(property);
            return new Documentation("Property", docs);
        }

        private static Documentation ProviderDocumentation(IMetadataProvider provider)
        {
            var documents = $@"Connection: {provider.Name}";
            return new Documentation("Database", documents);
        }

        private static string MetadataDocumentation(ITypedMetadata metadata)
        {
            var builder = new StringBuilder();
            builder.AppendName(metadata.Name);
            builder.AppendType(metadata.Type);
            builder.AppendSummaryParagraph(metadata.Summary);
            return builder.ToString();
        }

        public static string ToToolTip(ITypedMetadata metadata)
        {
            var builder = new StringBuilder();
            builder.AppendSummary(metadata.Summary);
            return builder.ToString();
        }
        
        public static string ToToolTip(ConnectionInfo connection, Entity entity)
        {
            var builder = new StringBuilder();
            builder.AppendSummary(entity.Summary);
            return builder.ToString();
        }
        
        public static string ToToolTip(Verb verb)
        {
            var builder = new StringBuilder();
            builder.AppendSummary(verb.Summary);
            return builder.ToString();
        }

        public static string ToNodeText(string name, int childrenCount)
        {
            var children = ChildrenText(childrenCount);
            return $"{name} ({children})";
        }

        private static string ChildrenText(int childrenCount)
        {
            var countSuffix = childrenCount > 1 ? "s" : String.Empty;
            return $"{childrenCount} item{countSuffix}";
        }

        public static string ToNodeText(ITypedMetadata metadata)
        {
            return $"{metadata.Name} ({metadata.Type})";
        }

        public static string ToBaseNodeText(TreeNode baseNode, int childrenCount)
        {
            var entitiesSuffix = childrenCount > 1 ? "ies" : "y";
            return $"{baseNode.Text} ({childrenCount} derived entit{entitiesSuffix})";
        }
    }
}