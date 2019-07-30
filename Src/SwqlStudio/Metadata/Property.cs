
namespace SwqlStudio.Metadata
{
    public class Property : ITypedMetadata, IObsoleteMetadata
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsNavigable { get; set; }
        public bool IsInherited { get; set; }
        public bool IsKey { get; set; }
        public string Summary { get; set; }

        public bool IsObsolete { get; set; }
        public string ObsolescenceReason { get; set; }
    }
}
