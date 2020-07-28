using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
