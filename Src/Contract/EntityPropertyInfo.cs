using System;
using System.Collections.Generic;

namespace SolarWinds.InformationService.Contract2
{
    internal class EntityPropertyInfo
    {
        private TypeInfo typeInfo;
        private static Dictionary<string, TypeInfo> typeMap = new Dictionary<string, TypeInfo>(StringComparer.Ordinal);

        static EntityPropertyInfo()
        {
            typeMap.Add("Blob", new TypeInfo() { Type = typeof(byte[]), PropertyType = EntityPropertyType.Blob });
            typeMap.Add("Boolean", new TypeInfo() { Type = typeof(Boolean), PropertyType = EntityPropertyType.Boolean });
            typeMap.Add("Byte", new TypeInfo() { Type = typeof(byte), PropertyType = EntityPropertyType.Byte });
            typeMap.Add("Char", new TypeInfo() { Type = typeof(char), PropertyType = EntityPropertyType.Char });
            typeMap.Add("DateTime", new TypeInfo() { Type = typeof(DateTime), PropertyType = EntityPropertyType.DateTime });
            typeMap.Add("Decimal", new TypeInfo() { Type = typeof(Decimal), PropertyType = EntityPropertyType.Decimal });
            typeMap.Add("Double", new TypeInfo() { Type = typeof(Double), PropertyType = EntityPropertyType.Double });
            typeMap.Add("Guid", new TypeInfo() { Type = typeof(Guid), PropertyType = EntityPropertyType.Guid });
            typeMap.Add("Int16", new TypeInfo() { Type = typeof(Int16), PropertyType = EntityPropertyType.Int16 });
            typeMap.Add("Int32", new TypeInfo() { Type = typeof(Int32), PropertyType = EntityPropertyType.Int32 });
            typeMap.Add("Int64", new TypeInfo() { Type = typeof(Int64), PropertyType = EntityPropertyType.Int64 });
            typeMap.Add("Single", new TypeInfo() { Type = typeof(Single), PropertyType = EntityPropertyType.Single });
            typeMap.Add("String", new TypeInfo() { Type = typeof(String), PropertyType = EntityPropertyType.String });
            typeMap.Add("Type", new TypeInfo() { Type = typeof(String), PropertyType = EntityPropertyType.Type });
            typeMap.Add("Uri", new TypeInfo() { Type = typeof(String), PropertyType = EntityPropertyType.Uri });
            typeMap.Add("Null", new TypeInfo() { Type = typeof(Object), PropertyType = EntityPropertyType.Null });

            // define array types for all preceding types
            var toAdd = new Dictionary<string, TypeInfo>(StringComparer.Ordinal);
            foreach (var pair in typeMap)
            {
                toAdd.Add(pair.Key + "[]", new TypeInfo()
                {
                    Type = pair.Value.Type.MakeArrayType(),
                    PropertyType = pair.Value.PropertyType,
                    IsArray = true
                });
            }

            // Dictionary<K,V> doesn't have AddRange?
            foreach (var pair in toAdd)
                typeMap.Add(pair.Key, pair.Value);
        }

        public EntityPropertyInfo(string name, string typeName)
        {

            if (!typeMap.TryGetValue(typeName, out typeInfo))
                throw new ArgumentException(String.Format("unsupported type name '{0}'", typeName), nameof(typeName));

            Name = name;
            TypeName = typeName;
        }

        public String Name { get; }

        public String TypeName { get; }

        public Type Type
        {
            get
            {
                return typeInfo.Type;
            }
        }

        public EntityPropertyType EntityPropertyType
        {
            get
            {
                return typeInfo.PropertyType;
            }
        }

        public bool IsArray
        {
            get
            {
                return typeInfo.IsArray;
            }
        }

        class TypeInfo
        {
            public Type Type;
            public EntityPropertyType PropertyType;
            public bool IsArray;
        }
    }
}
