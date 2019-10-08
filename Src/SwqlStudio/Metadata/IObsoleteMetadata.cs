namespace SwqlStudio.Metadata
{
    public interface IObsoleteMetadata
    {
        bool IsObsolete { get; set; }
        string ObsolescenceReason { get; set; }
    }
}
