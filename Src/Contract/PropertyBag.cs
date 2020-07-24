// Important:
//   This file has a copy that needs to be kept in sync:
//   //depot/Dev/Main/Platform/InformationService/Src/InformationService/Addons/PropertyBag.cs

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SolarWinds.InformationService.Contract2
{
    [Serializable]
    [XmlRoot("dictionary", Namespace = Constants.PropertyBagNamespace)]
    [XmlSchemaProvider("GetSchema")]
    public class PropertyBag : Dictionary<string, object>, IXmlSerializable
    {
        private const string propertyBagTypeName = "SolarWinds.InformationService.PropertyBag";
        private static readonly XNamespace ns = Constants.PropertyBagNamespace;
        private static readonly XNamespace otherNs = "http://schemas.solarwinds.com/2007/08/informationservice";

        public PropertyBag()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        public PropertyBag(IDictionary<string, object> dictionary)
            : base(dictionary, StringComparer.OrdinalIgnoreCase)
        {
        }

        public PropertyBag(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public static XmlQualifiedName GetSchema(XmlSchemaSet xs)
        {
            var schemaSerializer = new XmlSerializer(typeof(XmlSchema));
            var s = (XmlSchema)schemaSerializer.Deserialize(new StringReader(Resources.PropertyBagSchema));
            xs.XmlResolver = new XmlUrlResolver();
            xs.Add(s);

            return new XmlQualifiedName("dictionary", Constants.PropertyBagNamespace);
        }

        public override string ToString()
        {
            var buffer = new StringBuilder();
            foreach (var pair in this)
            {
                buffer.AppendFormat("{0}: {1}", pair.Key, pair.Value);
                buffer.AppendLine();
            }
            return buffer.ToString();
        }

        public T TryGet<T>(string key) where T : class
        {
            object obj;
            if (TryGetValue(key, out obj))
                return obj as T;
            else
                return null;
        }

        // Serializability adapted from http://weblogs.asp.net/pwelter34/archive/2006/05/03/444961.aspx
        // Modified to use XmlStrippedSerializer to minimize the xml data amount
        #region IXmlSerializable Members

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            var root = (XElement)XNode.ReadFrom(reader);
            foreach (var item in ElementsNamespaceOptional(root, "item"))
            {
                var keyNode = ElementNamespaceOptional(item, "key");
                if (keyNode == null)
                    continue;

                string key = keyNode.Value;

                var typeNode = ElementNamespaceOptional(item, "type");
                if (typeNode == null)
                    continue;

                string typeName = typeNode.Value;
                var overrideTypeAttribute = typeNode.Attribute("overrideType");
                if (overrideTypeAttribute != null)
                    typeName = overrideTypeAttribute.Value;

                Type valueType;
                if (typeName == propertyBagTypeName)
                    valueType = typeof(PropertyBag);
                else
                    valueType = Type.GetType(typeName);

                object value = null;

                var valueNode = ElementNamespaceOptional(item, "value");
                if (valueNode != null && !valueNode.IsEmpty && valueType != null)
                {
                    string serializedValue = valueNode.Value;
                    value = SerializationHelper.Deserialize(serializedValue, typeName);


                }

                Add(key, value);
            }
        }

        private static IEnumerable<XElement> ElementsNamespaceOptional(XElement parent, string name)
        {
            return parent.Elements(ns + name).Concat(parent.Elements(name)).Concat(parent.Elements(otherNs + name));
        }

        private static XElement ElementNamespaceOptional(XElement parent, string name)
        {
            return parent.Element(ns + name) ?? parent.Element(name) ?? parent.Element(otherNs + name);
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (KeyValuePair<string, object> kvp in this)
            {
                writer.WriteStartElement("item", Constants.PropertyBagNamespace);

                writer.WriteStartElement("key", Constants.PropertyBagNamespace);
                writer.WriteString(kvp.Key);
                writer.WriteEndElement();

                if (kvp.Value != null)
                {
                    Type valueType = kvp.Value.GetType();
                    writer.WriteStartElement("type", Constants.PropertyBagNamespace);
                    string typeName = valueType.FullName;
                    if (valueType == typeof(PropertyBag))
                    {
                        // Old contracts can't deserialize an item value of type PropertyBag. Lie to them that this is a 
                        // string and put an attribute to indicate that it is really a PropertyBag.
                        writer.WriteAttributeString("overrideType", propertyBagTypeName);
                        typeName = typeof(string).FullName;
                    }
                    writer.WriteString(typeName);
                    writer.WriteEndElement();

                    writer.WriteStartElement("value", Constants.PropertyBagNamespace);

                    string value;

                    value = SerializationHelper.Serialize(kvp.Value, valueType.FullName);

                    writer.WriteString(value);

                    if (kvp.Value is string && ((string)kvp.Value) == String.Empty)
                        writer.WriteFullEndElement();
                    else
                        writer.WriteEndElement();
                }
                else
                {
                    writer.WriteStartElement("type", Constants.PropertyBagNamespace);
                    writer.WriteString("null");
                    writer.WriteEndElement();
                    writer.WriteString("null"); // it's a bit goofy to put a text node in the output here, but this is the only thing
                    // I have found that will reliably keep the old contract PropertyBag parser in sync
                }

                writer.WriteEndElement();
            }
        }

        #endregion
    }
}
