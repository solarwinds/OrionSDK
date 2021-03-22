using System;
using System.Reflection;
using System.Xml;

namespace SolarWinds.InformationService.Contract2
{
    internal interface IResponseParser<T> where T : new()
    {
        T ReadNextEntity(XmlReader reader);
    }

    internal enum ParserState
    {
        Start,
        Root,
        Template,
        EntityTemplate,
        PropertyTemplate,
        Data,
        Entity,
        EntitySet,
        Property,
        ArrayProperty,
        ArrayItem,
        Errors,
        Error
    }

    internal struct StackFrame
    {
        public EntityInfo entity;
        public EntitySetInfo entitySet;
        public string elementName;
        public PropertyInfo property;
        public EntityPropertyInfo entityPropertyInfo;
        public MethodInfo addMethod;
        public object instance;
        public Type instanceType;
        public ParserState state;
        public bool dynamic;
        public string xmlName;
        public IEntityPropertySetter iAddInstance;

        internal StackFrame Clone()
        {
            var clone = new StackFrame();
            clone.entity = entity;
            clone.entitySet = entitySet;
            clone.elementName = elementName;
            clone.instance = instance;
            clone.instanceType = instanceType;
            clone.dynamic = dynamic;
            clone.property = property;
            clone.entityPropertyInfo = entityPropertyInfo;
            clone.state = state;
            clone.addMethod = addMethod;
            clone.xmlName = xmlName;
            clone.iAddInstance = iAddInstance;

            return clone;
        }
    }

    public enum ParserType
    {
        EntityCollectionResponseParser
    }
}
