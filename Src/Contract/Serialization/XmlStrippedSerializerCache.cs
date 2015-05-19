// Important:
//   This file has a copy that needs to be kept in sync:
//   //depot/Dev/Main/Platform/InformationService/Src/InformationService/Core/Serialization/XmlStrippedSerializerCache.cs

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SolarWinds.InformationService.Contract2.Serialization
{
    /// <summary>
    /// Since it is so expensive to construct serializers, this object caches them.
    /// </summary>
    class XmlStrippedSerializerCache
    {
        private readonly Dictionary<string, XmlStrippedSerializer> cache = new Dictionary<string, XmlStrippedSerializer>();

        public XmlStrippedSerializer GetSerializer(Type type)
        {
            XmlStrippedSerializer strippedSerializer;

            string typeName = type.FullName;

            bool found;
            lock (cache)
            {
                found = cache.TryGetValue(typeName, out strippedSerializer);
            }

            if (!found)
            {
                strippedSerializer = GetSerializerInternal(type, typeName);
            }

            return strippedSerializer;
        }

        private XmlStrippedSerializer GetSerializerInternal(Type type, string typeName)
        {
            XmlReflectionImporter xmlReflectionImporter = new XmlReflectionImporter();
            XmlTypeMapping xmlTypeMapping = xmlReflectionImporter.ImportTypeMapping(type);

            //Create the new serializer                
            XmlStrippedSerializer strippedSerializer = new XmlStrippedSerializer(new XmlSerializer(type), xmlTypeMapping.XsdElementName, xmlTypeMapping.Namespace, type);

            lock (cache)
            {
                cache[typeName] = strippedSerializer;
            }

            return strippedSerializer;
        }
    }
}
