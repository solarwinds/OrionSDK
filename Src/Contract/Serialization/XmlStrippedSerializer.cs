// Important:
//   This file has a copy that needs to be kept in sync:
//   //depot/Dev/Main/Platform/InformationService/Src/InformationService/Core/Serialization/XmlStrippedSerializer.cs

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace SolarWinds.InformationService.Contract2.Serialization
{
    /// <summary>
    /// This class allows XML serialization in a more human readable format.  The resulting stripped xml of the serialized object contains
    /// no XML declaration and no root element.
    /// 
    /// For example 
    ///     An integer value of 5 would result stripped XML of 
    ///         5
    /// 
    ///     An array of strings would have stripped xml of
    ///         <string>Karen</string><string>Caleb</string><string>Rachel</string><string>Morgen</string><string>Katy</string>
    /// 
    /// </summary>
    class XmlStrippedSerializer
    {
        public XmlStrippedSerializer(XmlSerializer serializer, string xsdElementName, string ns, Type type)
        {
            Serializer = serializer;
            XsdElementName = xsdElementName;
            Namespace = ns;
            Type = type;
        }

        public XmlSerializer Serializer { get; }

        //XML element name of the mapped object
        public string XsdElementName { get; }

        public string Namespace { get; }

        /// <summary>
        /// The System.Type that this serializer knows how to serialize.
        /// </summary>
        public Type Type { get; }

        public string SerializeToStrippedXml(object value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            if (value.GetType() != Type)
                throw new ArgumentException("The value argument must be of the System.Type that the serializer knows how to serialize");

            XmlDocument xmlDocument = new XmlDocument();

            XPathNavigator navigator = xmlDocument.CreateNavigator();
            if (navigator == null)
                throw new ArgumentNullException("navigator");

            using (XmlWriter xmlWriter = navigator.AppendChild())
            {
                Serializer.Serialize(xmlWriter, value);
            }

            return xmlDocument.FirstChild.InnerXml;
        }

        public object DeserializeFromStrippedXml(string strippedXml)
        {
            //Deserializing an empty string is okay, but not a null string
            if (strippedXml == null)
                throw new ArgumentNullException("strippedXml");

            string xml = string.Format("<{0} xmlns='{1}'>{2}</{0}>", XsdElementName, Namespace, strippedXml);

            return Serializer.Deserialize(new StringReader(xml));
        }

    }
}
