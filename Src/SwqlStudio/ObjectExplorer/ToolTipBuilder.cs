using System;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal class ToolTipBuilder
    {
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