using System.Collections.Generic;

namespace SwqlStudio.Metadata
{
    public class Verb : IObsoleteMetadata
    {
        private readonly List<VerbArgument> _arguments = new List<VerbArgument>();

        public string Name { get; set; }
        public string EntityName { get; set; }
        public string Summary { get; set; }

        public bool IsObsolete { get; set; }
        public string ObsolescenceReason { get; set; }

        public List<VerbArgument> Arguments
        {
            get { return _arguments; }
        }
    }
}
