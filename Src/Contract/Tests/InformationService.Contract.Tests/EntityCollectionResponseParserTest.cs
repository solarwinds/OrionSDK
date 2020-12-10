using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using NUnit.Framework;

namespace SolarWinds.InformationService.Contract2
{
    [TestFixture]
    public class EntityCollectionResponseParserTest
    {
        [Test]
        public void ReadNextEntityNullReader()
        {
            EntityCollectionResponseParser<object> parser = new EntityCollectionResponseParser<object>();
            var ex = Assert.Throws<ArgumentNullException>(() => parser.ReadNextEntity(null));
            Assert.True(ex.Message.Contains("reader"));
        }

        [Test]
        public void ReadNextEntityBlob()
        {
            MemoryStream input = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.ResponseWithBlob));

            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(input, XmlDictionaryReaderQuotas.Max);

            EntityCollectionResponseParser<TestEntity> parser = new EntityCollectionResponseParser<TestEntity>();
            TestEntity entity = parser.ReadNextEntity(reader);
            Assert.AreEqual(8, entity.Properties.Count);

            Assert.AreEqual("Admin", entity.Properties["Owner"].ToString());
            Assert.AreEqual(new Guid("feba4a52-7b75-47fc-90ff-a4aeb995f607"), (Guid)entity.Properties["FileId"]);
            Assert.AreEqual(false, (bool)entity.Properties["IsDeleted"]);

            Assert.IsAssignableFrom(typeof(string[]), entity.Properties["SomeStringArray"]);
            Assert.AreEqual(3, ((string[])entity.Properties["SomeStringArray"]).Length);
            Assert.AreEqual("item 1", ((string[])entity.Properties["SomeStringArray"])[0]);
            Assert.AreEqual("item 2", ((string[])entity.Properties["SomeStringArray"])[1]);
            Assert.AreEqual("last item", ((string[])entity.Properties["SomeStringArray"])[2]);
        }

        [Test]
        public void ReaderNextEntityWithRootEntityAttribute()
        {
            MemoryStream input = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.ResponseWithBlob));

            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(input, XmlDictionaryReaderQuotas.Max);

            EntityCollectionResponseParser<M> parser = new EntityCollectionResponseParser<M>();
            M mapStudioFile = parser.ReadNextEntity(reader);
        }

        private class TestEntity
        {
            private readonly Dictionary<string, object> properties = new Dictionary<string, object>();
            public Dictionary<string, object> Properties
            {
                get
                {
                    return properties;
                }
            }

            public void Add(string propertyName, object propertyValue)
            {
                if (Properties.ContainsKey(propertyName))
                {
                    Properties[propertyName] = propertyValue;
                }
                else
                {
                    Properties.Add(propertyName, propertyValue);
                }
            }
        }

        private class M : TestEntity { }
    }
}
