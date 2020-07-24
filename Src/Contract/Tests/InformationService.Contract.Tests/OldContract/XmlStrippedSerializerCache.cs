using System;
using System.Collections;
using System.Xml.Serialization;

namespace SolarWinds.InformationService.Contract2.OldContract
{
    /// <summary>
    /// Since it is so expensive to construct serializers, this object caches them.
    /// </summary>
    class XmlStrippedSerializerCache
    {
        private readonly Hashtable cache = new Hashtable();
        private object _syncLock = new object();

        public OldContract.XmlStrippedSerializer GetSerializer(Type type)
        {
            OldContract.XmlStrippedSerializer strippedSerializer;
            //Hashtable is thread safe for use by multiple reader threads and a single writing thread,
            //so the ContainsKey call is safe here
            if (cache.ContainsKey(type))
            {
                strippedSerializer = cache[type] as OldContract.XmlStrippedSerializer;
            }
            else
            {
                //create the serializer before locking so that other threads are not blocked here

                //Needed the element name of the root element, since we strip it out of our value stored in the database.
                XmlReflectionImporter xmlReflectionImporter = new XmlReflectionImporter();
                XmlTypeMapping xmlTypeMapping = xmlReflectionImporter.ImportTypeMapping(type);

                //Create the new serializer                
                strippedSerializer = new OldContract.XmlStrippedSerializer(new XmlSerializer(type), xmlTypeMapping.XsdElementName, type);
                lock (_syncLock)
                {
                    if (cache.ContainsKey(type))
                    {
                        strippedSerializer = cache[type] as OldContract.XmlStrippedSerializer;
                    }
                    else
                    {
                        //Add it to the cache
                        cache.Add(type, strippedSerializer);
                    }
                }
            }
            return strippedSerializer;
        }
    }
}
