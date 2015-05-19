using System.Collections.Generic;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    interface IMetadataProvider
    {
        string Name { get; }
        IEnumerable<Entity> Tables { get; }
        void Refresh();
        IEnumerable<VerbArgument> GetVerbArguments(Verb verb);
        ConnectionInfo ConnectionInfo { get; }
    }
}
