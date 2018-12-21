using System.Drawing;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    public class CrudProperty
    {
        public bool UseInPropertyBag { get; }
        private readonly Property _property;

        public CrudProperty(Property property, bool useInPropertyBag = true)
        {
            UseInPropertyBag = useInPropertyBag;
            _property = property;
        }

        public int IconIndex
        {
            get
            {
                if (_property.IsKey) return 0;
                if (_property.IsNavigable) return 1;
                if (_property.IsInherited) return 2;
                else return 3;
            }
        }

        public string Name => _property.Name;

        public string Type => _property.Type;

        public string Value { get; set; }
    }
}