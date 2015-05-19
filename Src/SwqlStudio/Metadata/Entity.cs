using System.Collections.Generic;

namespace SwqlStudio.Metadata
{
    class Entity
    {
        private readonly List<Property> properties = new List<Property>();
        private readonly List<Verb> verbs = new List<Verb>();

        public string FullName { get; set; }
        public string Namespace { get; set; }
        public string BaseType { get; set; }
        public bool IsIndication { get; set; }
        public bool IsAbstract { get; set; }

        public bool CanCreate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanInvoke { get; set; }
        public bool CanRead   { get; set; }
        public bool CanUpdate { get; set; }

        public Entity BaseEntity { get; set; }

        public List<Property> Properties { get { return properties; } }
        public List<Verb> Verbs { get { return verbs; } }
    }
}
