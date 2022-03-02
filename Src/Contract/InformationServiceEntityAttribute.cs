using System;

namespace SolarWinds.InformationService.Contract2
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class InformationServiceEntityAttribute : Attribute
    {
        public InformationServiceEntityAttribute()
        {
        }

        public string EntityType { get; set; }
        public ParserType ParserType { get; set; }

    }
}
