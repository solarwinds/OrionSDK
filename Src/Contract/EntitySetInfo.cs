using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarWinds.InformationService.Contract2
{
    internal class EntitySetInfo
    {
        private string name;
        private Dictionary<string, EntityInfo> entities = new Dictionary<string, EntityInfo>();

        public EntitySetInfo(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public Dictionary<string, EntityInfo> Entities
        {
            get
            {
                return this.entities;
            }
        }

    }
}
