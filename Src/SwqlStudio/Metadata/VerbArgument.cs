namespace SwqlStudio.Metadata
{
    public class VerbArgument : ITypedMetadata
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string EntityName { get; set; }

        public string VerbName { get; set; }

        public int Position { get; set; }

        public string XmlTemplate { get; set; }

        public string Summary { get; set; }
    }
}
