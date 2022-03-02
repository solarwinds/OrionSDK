using System;
using System.IO;
using System.Text;
using System.Xml;
using NUnit.Framework;

namespace SolarWinds.InformationService.Contract2
{
    [TestFixture]
    public class ResponseParserTest
    {
        [Test]
        public void ReadNextEntityNullReader()
        {
            ResponseParser<object> parser = new ResponseParser<object>();
            var ex = Assert.Throws<ArgumentNullException>(() => parser.ReadNextEntity(null));
            Assert.True(ex.Message.Contains("reader"));
        }

        [Test]
        public void ReadNextEntityBlob()
        {
            MemoryStream input = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.ResponseWithBlob));

            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(input, XmlDictionaryReaderQuotas.Max);

            ResponseParser<MapStudioFiles> parser = new ResponseParser<MapStudioFiles>();
            MapStudioFiles mapStudioFile = parser.ReadNextEntity(reader);
            Assert.AreEqual(3, mapStudioFile.SomeStringArray.Length);
            Assert.AreEqual("item 1", mapStudioFile.SomeStringArray[0]);
            Assert.AreEqual("item 2", mapStudioFile.SomeStringArray[1]);
            Assert.AreEqual("last item", mapStudioFile.SomeStringArray[2]);
        }

        [Test]
        public void ReaderNextEntityWithRootEntityAttribute()
        {
            MemoryStream input = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.ResponseWithBlob));

            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(input, XmlDictionaryReaderQuotas.Max);

            ResponseParser<M> parser = new ResponseParser<M>();
            M mapStudioFile = parser.ReadNextEntity(reader);
        }

        [Test]
        public void ReaderNextEntityWithRootEntityWrongName()
        {
            MemoryStream input = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.ResponseWithBlob));

            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(input, XmlDictionaryReaderQuotas.Max);

            ResponseParser<Z> parser = new ResponseParser<Z>();
            var ex = Assert.Throws<InvalidOperationException>(() => parser.ReadNextEntity(reader));
            Assert.AreEqual("Don't know how to handle element MapStudioFiles", ex.Message);
        }

        private class MapStudioFiles
        {
            public Guid FileId { get; set; }
            public string FileName { get; set; }
            public byte[] FileData { get; set; }
            public DateTime Timestamp { get; set; }
            public string Owner { get; set; }
            public string UpdateUser { get; set; }
            public bool IsDeleted { get; set; }
            public string LockUser { get; set; }
            public int FileType { get; set; }
            public DateTime LockDate { get; set; }
            public string ComputerName { get; set; }
            public string[] SomeStringArray { get; set; }
        }

        [InformationServiceEntity(EntityType = "Orion.MapStudioFiles")]
        private class M : MapStudioFiles
        {
        }

        private class Z : MapStudioFiles
        {
        }
    }
}
