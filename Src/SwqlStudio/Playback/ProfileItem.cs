using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using SolarWinds.InformationService.Contract2;

namespace SwqlStudio.Playback
{
    [Serializable]
    [XmlType(TypeName = "ProfileItem", Namespace = "")]
    public class ProfileItem
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long Duration { get; set; }
        public string RequestUri { get; set; }
        public string UserName { get; set; }
        public string AppDomain { get; set; }
        public string Query { get; set; }
        public string QueryPlan { get; set; }
        public List<QueryParameter> QueryParameters { get; set; }
        public string SqlQuery { get; set; }
        public string Results { get; set; }

        public PropertyBag GetQueryParameters()
        {
            var retval = new PropertyBag();
            if (QueryParameters != null)
            {
                foreach (var queryParameter in QueryParameters)
                {
                    retval.Add(queryParameter.Key, queryParameter.Value);
                }
            }
            return retval;
        }
    }

    public class QueryParameter
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }

    [Serializable()]
    [XmlRoot("ProfileItems")]
    public class ProfileItems
    {
        [XmlArray("ProfileItems")]
        [XmlArrayItem("ProfileItem", typeof(ProfileItem))]
        public ProfileItem[] Items { get; set; }

        public static ProfileItems Deserialize(string xml)
        {
            var serializer = new XmlSerializer(typeof (ProfileItems));
            var reader = new StringReader(xml);
            return (ProfileItems) serializer.Deserialize(reader);
        }

        private static XmlSerializer _serializer = new XmlSerializer(typeof(ProfileItems));
        public static string Serialize(ProfileItems obj)
        {
            var serialXml = new StringBuilder();

            using (var xWriter = XmlWriter.Create(serialXml))
            {
                _serializer.Serialize(xWriter, obj);
                xWriter.Flush();
                return serialXml.ToString();
            }
        }
    }
}
