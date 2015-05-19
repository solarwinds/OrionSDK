using System;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Xml.XPath;

namespace SolarWinds.InformationService.Contract2.OldContract
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
        private readonly XmlSerializer _serializer;
        private readonly string _xsdElementName;
        private readonly Type _type;

        public XmlStrippedSerializer(XmlSerializer serializer, string xsdElementName, Type type)
        {
            _serializer = serializer;
            _xsdElementName = xsdElementName;
            _type = type;
        }

        public XmlSerializer Serializer
        {
            get
            {
                return _serializer;
            }
        }

        //XML element name of the mapped object
        public string XsdElementName
        {
            get
            {
                return _xsdElementName;
            }
        }


        /// <summary>
        /// The System.Type that this serializer knows how to serialize.
        /// </summary>
        public Type Type
        {
            get
            {
                return _type;
            }
        }

        public string SerializeToStrippedXml(object value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            if (value.GetType() != _type)
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

            string xml = string.Format("<{0}>{1}</{0}>", XsdElementName, strippedXml);

            return Serializer.Deserialize(new StringReader(xml));
        }

    }
}
