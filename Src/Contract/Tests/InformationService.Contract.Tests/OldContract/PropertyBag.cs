// !!!!!! This is the PropertyBag from c:\Dev\Release\Platform\InformationService\2012.1\Src\InformationService\Contract\PropertyBag.cs
// !!!!!! It is here in SolarWinds.InformationService.Addons.Test because I want unit tests to verify the behavior of old contracts when 
// !!!!!! they deserialize PropertyBags (especially nested ones) serialized by the new PropertyBag code.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SolarWinds.InformationService.Contract2.OldContract
{
    [Serializable]
    [XmlRoot("dictionary", Namespace = PropertyBagNamespace)]
    public class PropertyBag : Dictionary<string, object>, IXmlSerializable
    {
        public const string PropertyBagNamespace = "http://schemas.solarwinds.com/2007/08/informationservice/propertybag";

        private static XmlStrippedSerializerCache serializerCache;

        static PropertyBag()
        {
            serializerCache = new XmlStrippedSerializerCache();
        }

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

        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
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
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();

            if (wasEmpty)
                return;

            reader.MoveToContent();

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                ReadStartElementAnyNamespace(reader, "item");

                reader.MoveToContent();

                ReadStartElementAnyNamespace(reader, "key");
                string key = reader.ReadContentAsString();
                reader.ReadEndElement();

                reader.MoveToContent();

                ReadStartElementAnyNamespace(reader, "type");
                string typeName = reader.ReadContentAsString();
                reader.ReadEndElement();

                reader.MoveToContent();

                object value = null;
                Type valueType = Type.GetType(typeName);
                if (valueType != null)
                {
                    string serializedValue = string.Empty;
                    if ((!reader.IsEmptyElement) && (reader.LocalName == "value"))
                    {
                        serializedValue = reader.ReadInnerXml();
                    }
                    else
                    {
                        reader.Read();
                    }

                    //XmlSerializer can't serialize TimeSpan type, so take the Ticks property
                    if (valueType == typeof(TimeSpan))
                    {
                        long ticks = (long)serializerCache.GetSerializer(typeof(long)).DeserializeFromStrippedXml(serializedValue);
                        value = TimeSpan.FromTicks(ticks);
                    }
                    else
                        value = serializerCache.GetSerializer(valueType).DeserializeFromStrippedXml(serializedValue);
                }
                else
                    //for unknown types skip the node
                    reader.Read();

                this.Add(key, value);

                reader.MoveToContent();

                reader.ReadEndElement();
                reader.MoveToContent();
            }

            reader.ReadEndElement();
        }

        private static void ReadStartElementAnyNamespace(XmlReader reader, string localName)
        {
            if (reader.LocalName == localName)
                reader.ReadStartElement();
            else
                throw new XmlException(string.Format("Expected element <{0}> but found <{1}>", localName, reader.LocalName));
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (string key in this.Keys)
            {
                writer.WriteStartElement("item", PropertyBagNamespace);

                writer.WriteStartElement("key", PropertyBagNamespace);
                writer.WriteString(key);
                writer.WriteEndElement();

                if (this[key] != null)
                {
                    Type valueType = this[key].GetType();
                    writer.WriteStartElement("type", PropertyBagNamespace);
                    writer.WriteString(valueType.FullName);
                    writer.WriteEndElement();

                    writer.WriteStartElement("value", PropertyBagNamespace);
                    string value = string.Empty;
                    //XmlSerializer can't serialize TimeSpan type, so take the Ticks property
                    if (valueType == typeof(TimeSpan))
                        value = serializerCache.GetSerializer(typeof(long)).SerializeToStrippedXml(((TimeSpan)this[key]).Ticks);
                    else
                        value = serializerCache.GetSerializer(valueType).SerializeToStrippedXml(this[key]);
                    writer.WriteString(value);
                    writer.WriteEndElement();
                }
                else
                {
                    writer.WriteStartElement("type", PropertyBagNamespace);
                    writer.WriteString("null");
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        #endregion
    }
}


