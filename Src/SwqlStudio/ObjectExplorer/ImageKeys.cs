using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal class ImageKeys
    {
        internal const string Database = "Database";
        internal const string Namespace = "Namespace";
        internal const string Verb = "Verb";
        internal const string Argument = "Argument";

        internal const string BaseTypeAbstract = "BaseTypeAbstract";
        internal const string BaseType = "BaseType";

        internal const string Indication = "Indication";
        internal const string TableAbstract = "TableAbstract";
        internal const string TableCrud = "TableCrud";
        internal const string Table = "Table";

        internal const string Column = "Column";
        internal const string Link = "Link";
        internal const string KeyColumn = "KeyColumn";
        internal const string InheritedColumn = "InheritedColumn";

        public static string GetImageKey(Entity entity)
        {
            if (entity.IsIndication)
                return Indication;

            if (entity.IsAbstract)
                return TableAbstract;

            if (entity.CanCreate || entity.CanDelete || entity.CanUpdate)
            {
                return TableCrud;
            }

            return Table;
        }

        public static string GetImageKey(Property property)
        {
            if (property.IsNavigable)
                return Link;
            if (property.IsKey)
                return KeyColumn;
            if (property.IsInherited)
                return InheritedColumn;

            return Column;
        }
    }
}
