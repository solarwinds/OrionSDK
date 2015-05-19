using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarWinds.InformationService.Contract2
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class InformationServiceEntityAttribute : Attribute
    {
        public InformationServiceEntityAttribute()
        {
        }

        public string EntityType { get; set; }
        public ParserType ParserType { get; set; }
        
    }
}
