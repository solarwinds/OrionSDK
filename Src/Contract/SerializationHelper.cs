using System.IO;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using SolarWinds.InformationService.Contract2.Serialization;
using System.Globalization;

namespace SolarWinds.InformationService.Contract2
{
    class SerializerInfo
    {
        public readonly Type ObjectType;
        public readonly Func<object, Type, string> Serializer;
        public readonly Func<string, Type, object> DeSerializer;


        public SerializerInfo(Type type, Func<object, Type, string> serializer, Func<string, Type, object> deserializer)
        {
            ObjectType = type;
            Serializer = serializer;
            DeSerializer = deserializer;
        }

    }

    public static class SerializationHelper
    {
        public static T Deserialize<T>(byte[] data)
        {
            T result;
            using (MemoryStream stream = new MemoryStream(data))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                result = (T) serializer.ReadObject(stream);
            }

            return result;
        }
        
        public static string GetString(byte[] data)
        {
            using (MemoryStream stream = new MemoryStream(data))
            using(StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static readonly Dictionary<string, SerializerInfo> cachedObjectTypes = new Dictionary<string, SerializerInfo>(StringComparer.OrdinalIgnoreCase)
        {
            {"System.String", new SerializerInfo(typeof(System.String),SerializeValue,DeserializeValue)},
            {"System.Guid", new SerializerInfo(typeof(System.Guid),SerializeValue,DeserializeGuid)},
            {"System.Int16",new SerializerInfo(typeof(System.Int16),SerializeValue,DeserializeValue)},
            {"System.Int32",new SerializerInfo(typeof(System.Int32),SerializeValue,DeserializeValue)},
            {"System.Int64",new SerializerInfo(typeof(System.Int64),SerializeValue,DeserializeValue)},
            {"System.DateTime",new SerializerInfo(typeof(System.DateTime),SerializeDateTime,DeserializeDateTime)},
            {"System.Boolean",new SerializerInfo(typeof(System.Boolean),SerializeBoolean,DeserializeBoolean)},
            {"System.Char",new SerializerInfo(typeof(System.Char),SerializeChar,DeserializeChar)},
            {"System.Decimal",new SerializerInfo(typeof(System.Decimal),SerializeValue,DeserializeValue)},
            {"System.Double",new SerializerInfo(typeof(System.Double),SerializeValue,DeserializeValue)},
            {"System.DBNull",new SerializerInfo(typeof(System.DBNull),SerializeToStrippedXml,DeserializeDBNull)},
            {"System.TimeSpan",new SerializerInfo(typeof(System.TimeSpan),SerializeTimeSpan,DeserializeTimeSpan)},
            {"System.Byte", new SerializerInfo(typeof(System.Byte),SerializeValue,DeserializeValue)},
            {"System.String[]", new SerializerInfo(typeof(System.String).MakeArrayType(),SerializeToStrippedXml,DeserializeFromStrippedXml)},
            {"System.Byte[]", new SerializerInfo(typeof(System.Byte).MakeArrayType(),SerializeToStrippedXml,DeserializeFromStrippedXml)},
            {"System.Int32[]", new SerializerInfo(typeof(System.Int32).MakeArrayType(),SerializeToStrippedXml,DeserializeFromStrippedXml)},
            {"System.Int16[]", new SerializerInfo(typeof(System.Int16).MakeArrayType(),SerializeToStrippedXml,DeserializeFromStrippedXml)},
            {"System.Int64[]", new SerializerInfo(typeof(System.Int64).MakeArrayType(),SerializeToStrippedXml,DeserializeFromStrippedXml)},
            {"System.DateTime[]", new SerializerInfo(typeof(System.DateTime).MakeArrayType(),SerializeToStrippedXml,DeserializeFromStrippedXml)},
            {"System.Boolean[]", new SerializerInfo(typeof(System.Boolean).MakeArrayType(),SerializeToStrippedXml,DeserializeFromStrippedXml)},
            {"System.Double[]", new SerializerInfo(typeof(System.Double).MakeArrayType(),SerializeToStrippedXml,DeserializeFromStrippedXml)},
            {"SolarWinds.InformationService.PropertyBag",new SerializerInfo(typeof(PropertyBag),SerializeToStrippedXml,DeserializeFromStrippedXml)},

        };

        private static XmlStrippedSerializerCache serializerCache;

        static SerializationHelper()
        {
            serializerCache = new XmlStrippedSerializerCache();
        }

        public static string Serialize(object value, string typename)
        {
            string serializedValue = string.Empty;

            SerializerInfo serializerInfo;

            if (cachedObjectTypes.TryGetValue(typename, out serializerInfo))
            {
                serializedValue = serializerInfo.Serializer.Invoke(value, serializerInfo.ObjectType);
            }
            else
            {
                Type valueType = Type.GetType(typename);
                serializedValue = SerializeToStrippedXml(value, valueType);
            }

            return serializedValue;
        }

        public static object Deserialize(string value, string typename)
        {

            object deserializedValue = null;

            SerializerInfo serializerInfo;

            if (cachedObjectTypes.TryGetValue(typename, out serializerInfo))
            {
                deserializedValue = serializerInfo.DeSerializer.Invoke(value, serializerInfo.ObjectType);
            }
            else
            {
                Type valueType = Type.GetType(typename);
                deserializedValue = DeserializeFromStrippedXml(value, valueType);
            }

            return deserializedValue;
        }
        
        public static string SerializeValue(object value, Type type)
        {
            return Convert.ToString(value, CultureInfo.InvariantCulture);
        }

        public static string SerializeBoolean(object value, Type type)
        {
            return XmlConvert.ToString(Convert.ToBoolean(value));
        }

        public static object DeserializeBoolean(string value, Type type)
        {
            if ("True".Equals(value, StringComparison.OrdinalIgnoreCase))
                return true;
            if ("False".Equals(value, StringComparison.OrdinalIgnoreCase))
                return false;
            // XmlConvert.ToBoolean is case-sensitive and accepts also '0' and '1'
            return XmlConvert.ToBoolean(value);
        }

        public static string SerializeChar(object value, Type type)
        {
            return XmlConvert.ToString((int)Convert.ToChar(value));
        }

        public static object DeserializeChar(string value, Type type)
        {
            return value.Length == 1
                ? value[0]
                : (char)int.Parse(value, CultureInfo.InvariantCulture);
        }

        public static string SerializeDateTime(object value, Type type)
        {
            return XmlConvert.ToString((DateTime)value, XmlDateTimeSerializationMode.Utc); 
        }

        public static object DeserializeDateTime(string value, Type type)
        {
            return XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.Utc);
        }

        public static string SerializeTimeSpan(object value, Type type)
        {
            return ((TimeSpan)value).Ticks.ToString();
        }

        public static object DeserializeTimeSpan(string value, Type type)
        {
            var ticks = Convert.ChangeType(value, typeof(long));
            return TimeSpan.FromTicks(((long)ticks));
        }

        public static object DeserializeGuid(string value, Type type)
        {
            return new Guid(value);
        }

        public static object DeserializeDBNull(string value, Type type)
        {
            return DBNull.Value;
        }

        public static object DeserializeValue(string value, Type type)
        {
            return Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
        }

        public static object DeserializeFromStrippedXml(string value, Type type)
        {
            return serializerCache.GetSerializer(type).DeserializeFromStrippedXml(value);
        }

        public static string SerializeToStrippedXml(object value, Type type)
        {
            return serializerCache.GetSerializer(type).SerializeToStrippedXml(value);

        }
    }
}
