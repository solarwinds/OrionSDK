using System;
using System.Text;
using System.Windows.Forms;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal class DocumentationBuilder
    {
        public static string Build(TreeNode node)
        {
            var data = node.Tag;
            var builder = new StringBuilder();
            
            // TODO if (data is SwisMetaDataProvider provider)
            //    return ToToolTip(builder, provider);

            if (data is string nameSpace)
                builder.Append(nameSpace);

            // TODO if (data is Entity entity)
            //    return ToToolTip(connection, entity);
            
            if (data is Property property)
                return ToToolTip(property, "name");

            if (data is Verb verb)
                return ToToolTip(verb);

            if (data is VerbArgument verbArg)
                return ToToolTip(verbArg);

            return builder.ToString();
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
            if (entity.IsIndication)
            {
                return $@"{entity.FullName}
{(String.IsNullOrEmpty(entity.Summary) ? String.Empty : entity.Summary + Environment.NewLine)}Base type: {entity.BaseType}
CanSubscribe: {connection.CanCreateSubscription}";
            }

            return $@"{entity.FullName}
{(String.IsNullOrEmpty(entity.Summary) ? String.Empty : entity.Summary + Environment.NewLine)}Base type: {entity.BaseType}
CanCreate: {entity.CanCreate}
CanUpdate: {entity.CanUpdate}
CanDelete: {entity.CanDelete}";
        }

        public static string ToToolTip(Verb verb)
        {
            return verb.Name + Environment.NewLine + verb.Summary;
        }
    }
}