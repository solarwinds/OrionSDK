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
        [ExpectedException(typeof(ArgumentNullException), ExpectedMessage = "reader", MatchType = MessageMatch.Contains)]
        public void ReadNextEntityNullReader()
        {
            ResponseParser<object> parser = new ResponseParser<object>();
            parser.ReadNextEntity(null);
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
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage = "Don't know how to handle element MapStudioFiles")]
        public void ReaderNextEntityWithRootEntityWrongName()
        {
            MemoryStream input = new MemoryStream(Encoding.UTF8.GetBytes(Properties.Resources.ResponseWithBlob));

            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(input, XmlDictionaryReaderQuotas.Max);

            ResponseParser<Z> parser = new ResponseParser<Z>();
            Z mapStudioFile = parser.ReadNextEntity(reader);
        }

        class MapStudioFiles
        {
            public Guid FileId { get; set; }
            public string FileName { get; set; }
            public byte[] FileData { get; set; }
            public DateTime Timestamp { get; set; }
            public string Owner { get; set; }
            public string UpdateUser { get; set; }
            public Boolean IsDeleted { get; set; }
            public string LockUser { get; set; }
            public Int32 FileType { get; set; }
            public DateTime LockDate { get; set; }
            public string ComputerName { get; set; }
            public string[] SomeStringArray { get; set; }
        }

        [InformationServiceEntity(EntityType = "Orion.MapStudioFiles")]
        class M : MapStudioFiles
        {
        }

        class Z : MapStudioFiles
        {
        }
    }
}
