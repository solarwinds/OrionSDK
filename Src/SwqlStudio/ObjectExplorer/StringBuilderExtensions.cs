using System;
using System.Text;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal static class StringBuilderExtensions
    {
        public static void AppendName(this StringBuilder builder, string name)
        {
            builder.AppendFormat("Name: {0}\r\n", name);
        }

        public static void AppendType(this StringBuilder builder, string metadataType)
        {
            builder.AppendFormat("Type: {0}\r\n", metadataType);
        }

        public static void AppendSummaryParagraph(this StringBuilder builder,string summary)
        {
            builder.Append("\r\n\r\n");
            builder.AppendSummary(summary);
        }

        public static void AppendSummary(this StringBuilder builder,string summary)
        {
            if (String.IsNullOrEmpty(summary))
                return;

            var trimmed = summary.Trim();
            builder.AppendFormat(trimmed);
        }

        public static void AppendAccessControl(this StringBuilder builder, ConnectionInfo connection, Entity entity)
        {
            if (entity.IsIndication)
            {
                builder.Append($@"Can Subscribe: {connection.CanCreateSubscription}");
            }
            else
            {
                builder.Append($"Can Read: {entity.CanRead}\r\n");
                builder.Append($"Can Create: {entity.CanCreate}\r\n");
                builder.Append($"Can Update: {entity.CanUpdate}\r\n");
                builder.Append($"Can Delete: {entity.CanDelete}\r\n");
            }
        }

        public static void AppendObsoleteSection(this StringBuilder builder, IObsoleteMetadata entity)
        {
            if (entity != null && entity.IsObsolete)
            {
                builder.Append($"Obsolete: {entity.ObsolescenceReason}{Environment.NewLine}");
            }
        }
    }
}