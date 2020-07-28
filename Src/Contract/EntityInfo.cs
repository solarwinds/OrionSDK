using System.Collections.Generic;

namespace SolarWinds.InformationService.Contract2
{
    internal class EntityInfo
    {
        public EntityInfo(string entityName, string entityType, bool dynamic)
        {
            this.EntityName = entityName;
            this.EntityType = entityType;
            this.Dynamic = dynamic;
        }

        public string EntityName { get; }

        public string EntityType { get; }

        public bool Dynamic { get; }

        public Dictionary<string, EntityPropertyInfo> Properties { get; } = new Dictionary<string, EntityPropertyInfo>();

        public Dictionary<string, EntitySetInfo> EntitySets { get; } = new Dictionary<string, EntitySetInfo>();
    }
}
