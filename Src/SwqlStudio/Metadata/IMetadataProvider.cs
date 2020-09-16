using System;
using System.Collections.Generic;

namespace SwqlStudio.Metadata
{
    internal interface IMetadataProvider
    {
        event EventHandler EntitiesRefreshed;
        string Name { get; }
        IEnumerable<Entity> Tables { get; }
        void Refresh();
        IEnumerable<VerbArgument> GetVerbArguments(Verb verb);
        ConnectionInfo ConnectionInfo { get; }
    }
}
