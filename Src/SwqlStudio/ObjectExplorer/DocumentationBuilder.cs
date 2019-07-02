using System;
using System.Windows.Forms;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal class DocumentationBuilder
    {
        public static string Build(TreeNode node)
        {
            var data = node.Tag;
            var connectedNode = node as TreeNodeWithConnectionInfo;
            var provider = connectedNode?.Provider;

            if (provider == null)
                return string.Empty;

            if (data is SwisMetaDataProvider)
                return provider.Name;

            if (data is string nameSpace)
                return nameSpace;

            if (data is Entity entity)
                return ToToolTip(provider.ConnectionInfo, entity);

            if (data is Property property)
                return ToToolTip(property, "name");

            if (data is Verb verb)
                return ToToolTip(verb);

            if (data is VerbArgument verbArg)
                return ToToolTip(verbArg);

            return string.Empty;
        }

        public static string ToToolTip(VerbArgument arg)
        {
            if (!String.IsNullOrEmpty(arg.Summary))
                return arg.Summary;

            return String.Empty;
        }

        public static string ToToolTip(Property column, string name)
        {
            if (!String.IsNullOrEmpty(column.Summary))
                return name + Environment.NewLine + column.Summary;

            return String.Empty;
        }

        public static string ToToolTip(ConnectionInfo connection, Entity entity)
        {
            var summary = String.IsNullOrEmpty(entity.Summary) ? String.Empty : entity.Summary;

            if (entity.IsIndication)
            {
                return $@"{entity.FullName}
Base type: {entity.BaseType}
CanSubscribe: {connection.CanCreateSubscription}
{summary}";
            }

            return $@"{entity.FullName}
Base type: {entity.BaseType}
CanCreate: {entity.CanCreate}
CanUpdate: {entity.CanUpdate}
CanDelete: {entity.CanDelete}
{summary}";
        }

        public static string ToToolTip(Verb verb)
        {
            return verb.Name + Environment.NewLine + verb.Summary;
        }

        public static string ToNodeText(string name, int childsCount)
        {
            var countSuffix = childsCount > 1 ? "s" : String.Empty;
            return $"{name} ({childsCount} item{countSuffix})";
        }

        public static string ToNodeText(ITypedMetadata metadata)
        {
            return $"{metadata.Name} ({metadata.Type})";
        }

        public static string ToBaseNodeText(TreeNode baseNode, int childsCount)
        {
            var entitiesSuffix = childsCount > 1 ? "ies" : "y";
            return $"{baseNode.Text} ({childsCount} derived entit{entitiesSuffix})";
        }
    }
}