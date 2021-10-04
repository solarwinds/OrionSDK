using System;
using System.Text;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal static class StringBuilderExtensions
    {
        public static void AppendName(this StringBuilder builder, string name)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AppendFormat("Name: {0}{1}", name, Environment.NewLine);
        }

        public static void AppendType(this StringBuilder builder, string metadataType)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AppendFormat("Type: {0}{1}", metadataType, Environment.NewLine);
        }

        public static void AppendSummaryParagraph(this StringBuilder builder, string summary)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AppendLine();
            builder.AppendLine();
            builder.AppendSummary(summary);
        }

        public static void AppendSummary(this StringBuilder builder, string summary)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (string.IsNullOrEmpty(summary))
            {
                return;
            }

            string trimmed = summary.Trim();
            builder.Append(trimmed);
        }

        public static void AppendAccessControl(this StringBuilder builder, ConnectionInfo connection, Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }


            if (entity.IsIndication)
            {

                builder.Append($@"Can Subscribe: {connection.CanCreateSubscription}");
            }
            else
            {
                builder.AppendLine($"Can Read: {entity.CanRead}");
                builder.AppendLine($"Can Create: {entity.CanCreate}");
                builder.AppendLine($"Can Update: {entity.CanUpdate}");
                builder.AppendLine($"Can Delete: {entity.CanDelete}");
            }
        }

        public static void AppendObsoleteSection(this StringBuilder builder, IObsoleteMetadata entity)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (entity != null && entity.IsObsolete)
            {
                builder.AppendLine($"Obsolete: {entity.ObsolescenceReason}");
            }
        }
    }
}
