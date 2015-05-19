using System;
using System.Collections.Generic;
using System.Text;

namespace SolarWinds.InformationService.Contract2
{
    internal class EntityInfo
    {
        private string entityName;
        private string entityType;
        private bool dynamic;
        private Dictionary<string, EntityPropertyInfo> properties = new Dictionary<string, EntityPropertyInfo>();
        private Dictionary<string, EntitySetInfo> entitySets = new Dictionary<string, EntitySetInfo>();

        public EntityInfo(string entityName, string entityType, bool dynamic)
        {
            this.entityName = entityName;
            this.entityType = entityType;
            this.dynamic = dynamic;
        }

        public string EntityName
        {
            get
            {
                return this.entityName;
            }
        }

        public string EntityType
        {
            get
            {
                return this.entityType;
            }
        }

        public bool Dynamic
        {
            get
            {
                return this.dynamic;
            }
        }

        public Dictionary<string, EntityPropertyInfo> Properties
        {
            get
            {
                return this.properties;
            }
        }

        public Dictionary<string, EntitySetInfo> EntitySets
        {
            get
            {
                return this.entitySets;
            }
        }
    }
}
