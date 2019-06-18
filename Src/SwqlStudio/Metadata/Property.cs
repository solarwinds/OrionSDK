
namespace SwqlStudio.Metadata
{
    public class Property : ITypedMetadata
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsNavigable { get; set; }
        public bool IsInherited { get; set; }
        public bool IsKey { get; set; }
        public string Summary { get; set; }
    }
}
