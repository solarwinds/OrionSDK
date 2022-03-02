using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SolarWinds.InformationService.Contract2
{
    [XmlRoot(ElementName = "error", Namespace = Constants.Namespace)]
    public class ErrorMessage : IXmlSerializable
    {
        public string ErrorType { get; private set; }
        public string Context { get; private set; }
        public string Message { get; private set; }

        public ErrorMessage()
        {

        }

        public ErrorMessage(string errorType, string context, string message)
        {
            ErrorType = errorType;
            Context = context;
            Message = message;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "error":
                            break;

                        case "errorType":
                            ErrorType = GetElementContent(reader);
                            break;

                        case "context":
                            Context = GetElementContent(reader);
                            break;

                        case "message":
                            Message = GetElementContent(reader);
                            break;

                        default:
                            throw new InvalidDataException("Xml input is invalid. Unable to convert to ErrorMessage.");
                    }
                }
            }
        }

        private string GetElementContent(XmlReader reader)
        {
            reader.Read();

            if (reader.NodeType == XmlNodeType.Text)
                return reader.Value;

            if (reader.NodeType == XmlNodeType.Whitespace)
                return null;

            throw new InvalidDataException("Xml input is invalid. Unable to convert to ErrorMessage.");
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("errorType", ErrorType);
            writer.WriteElementString("context", Context);
            writer.WriteElementString("message", Message);
        }
    }
}
