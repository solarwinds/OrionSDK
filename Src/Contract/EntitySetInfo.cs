using System.Collections.Generic;

namespace SolarWinds.InformationService.Contract2
{
    internal class EntitySetInfo
    {
        public EntitySetInfo(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public Dictionary<string, EntityInfo> Entities { get; } = new Dictionary<string, EntityInfo>();
    }
}
