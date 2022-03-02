// Important:
//   This file has a copy that needs to be kept in sync:
//   //depot/Dev/Main/Platform/InformationService/Src/InformationService/Addons/SolarWinds.InformationService.Addons.Test/PropertyBagTest.cs

using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;

namespace SolarWinds.InformationService.Contract2
{
    [TestFixture]
    public class PropertyBagTest
    {
        private const string xmlWhitespace = @"<dictionary xmlns=""http://schemas.solarwinds.com/2007/08/informationservice/propertybag"">
    <item>
        <key>CustomerID</key>
        <type>System.String</type>
        <value>3333</value>
    </item>
</dictionary>
";

        private const string xmlNoNamespace = @"<dictionary>
    <item>
        <key>CustomerID</key>
        <type>System.String</type>
        <value>3333</value>
    </item>
</dictionary>
";

        private const string xmlNoWhitespace = @"<dictionary xmlns=""http://schemas.solarwinds.com/2007/08/informationservice/propertybag""><item><key>CustomerID</key><type>System.String</type><value>3333</value></item></dictionary>";

        private const string xmlValueAfterNull = @"<dictionary xmlns=""http://schemas.solarwinds.com/2007/08/informationservice/propertybag""><item><key>CustomerID</key><type>null</type><value/></item><item><key>asdf</key><type>System.String</type><value>myvalue</value></item></dictionary>";

        private readonly PropertyBag nested = new PropertyBag
                                                  {
                                                      {"prop", "value"},
                                                      {"bag", new PropertyBag {{"inner", "stuff"}}}
                                                  };

        private const string nestedXml = "<dictionary xmlns=\"http://schemas.solarwinds.com/2007/08/informationservice/propertybag\"><item><key>prop</key><type>System.String</type><value>value</value></item><item><key>bag</key><type overrideType=\"SolarWinds.InformationService.PropertyBag\">System.String</type><value>&lt;item xmlns=\"http://schemas.solarwinds.com/2007/08/informationservice/propertybag\"&gt;&lt;key&gt;inner&lt;/key&gt;&lt;type&gt;System.String&lt;/type&gt;&lt;value&gt;stuff&lt;/value&gt;&lt;/item&gt;</value></item></dictionary>";

        private const string xmlDiscoveryNode = "<dictionary xmlns=\"http://schemas.solarwinds.com/2007/08/informationservice/propertybag\"><item><key>PollInterval</key><type>System.TimeSpan</type><value>1200000000</value></item><item><key>NodeId</key><type>System.Int32</type><value>4</value></item><item><key>ObjectName</key><type>System.String</type><value>Text-2821.tex</value></item><item><key>InstanceType</key><type>System.String</type><value>Orion.Nodes</value></item><item><key>NextPoll</key><type>System.DateTime</type><value>2012-09-06T01:44:51.6484765Z</value></item><item><key>RWCommunity</key><type>null</type>null</item><item><key>SNMPV2Only</key><type>System.Boolean</type><value>false</value></item><item><key>EngineID</key><type>System.Int32</type><value>1</value></item><item><key>StatCollection</key><type>System.TimeSpan</type><value>6000000000</value></item><item><key>Community</key><type>System.String</type><value>public</value></item><item><key>IPAddress</key><type>System.String</type><value>10.199.1.1</value></item></dictionary>";

        private readonly PropertyBag doubleNested = new PropertyBag
                                               {
                                                   {"prop", "value"},
                                                   {
                                                       "bag", new PropertyBag
                                                                  {
                                                                      {"inner", "stuff"},
                                                                      {"bagbag", new PropertyBag {{"bottom", "thing"}}}
                                                                  }
                                                       }
                                               };

        private readonly PropertyBag twoNulls = new PropertyBag
            {
                {"asdf", null},
                {"qwer", null}
            };

        private const string xmlPropertyBagNoRootElement = @"
    <item><key>PollInterval</key><type>System.TimeSpan</type><value>1200000000</value></item><item><key>NodeId</key><type>System.Int32</type><value>4</value></item><item><key>ObjectName</key><type>System.String</type><value>Text-2821.tex</value></item><item><key>InstanceType</key><type>System.String</type><value>Orion.Nodes</value></item><item><key>NextPoll</key><type>System.DateTime</type><value>2012-09-06T01:44:51.6484765Z</value></item><item><key>RWCommunity</key><type>null</type>null</item><item><key>SNMPV2Only</key><type>System.Boolean</type><value>false</value></item><item><key>EngineID</key><type>System.Int32</type><value>1</value></item><item><key>StatCollection</key><type>System.TimeSpan</type><value>6000000000</value></item><item><key>Community</key><type>System.String</type><value>public</value></item><item><key>IPAddress</key><type>System.String</type><value>10.199.1.1</value></item>
    ";

        private readonly string[] stringArray = { "CustomerID", "PollInterval", "InstanceType", "NodeId" };

        private readonly System.TimeSpan span = new System.TimeSpan(1200000000);

        private const string xmlstringArray = "<string>CustomerID</string><string>PollInterval</string><string>InstanceType</string><string>NodeId</string>";



        [Test]
        public void XmlSerializer_Deserialize_NoWhitespace()
        {
            var serializer = new XmlSerializer(typeof(PropertyBag));
            var bag = (PropertyBag)serializer.Deserialize(new StringReader(xmlNoWhitespace));
            Assert.That(bag.ContainsKey("CustomerID"));
            Assert.That(bag["CustomerID"], Is.EqualTo("3333"));
        }


        [Test]
        public void SerializationHelper_Deserialize_PropertyBag()
        {
            var bag = (PropertyBag)SerializationHelper.Deserialize(xmlPropertyBagNoRootElement, typeof(PropertyBag).FullName);
            Assert.That(bag.ContainsKey("PollInterval"));
            Assert.That(bag["NodeId"], Is.EqualTo(4));
        }

        [Test]
        public void SerializationHelper_Deserialize_TimeSpan()
        {
            var typeName = typeof(System.TimeSpan).FullName;
            var timespan = (System.TimeSpan)SerializationHelper.Deserialize("1200000000", typeName);
            Assert.That(timespan.Ticks, Is.EqualTo(1200000000));
        }

        [Test]
        public void SerializationHelper_Serialize_TimeSpan()
        {
            var typeName = typeof(System.TimeSpan).FullName;
            var serialzedXml = SerializationHelper.Serialize(span, typeName);
            Assert.That(serialzedXml, Is.EqualTo("1200000000"));
        }

        [Test]
        public void SerializationHelper_Serialize_StringArray()
        {
            var typeName = typeof(string).MakeArrayType().FullName;
            var serialzedXml = SerializationHelper.Serialize(stringArray, typeName);
            Assert.That(serialzedXml, Is.EqualTo("<string>CustomerID</string><string>PollInterval</string><string>InstanceType</string><string>NodeId</string>"));
        }

        [Test]
        public void SerializationHelper_Deserialize_StringArray()
        {
            var typeName = typeof(string).MakeArrayType().FullName;
            var stringArray = (string[])SerializationHelper.Deserialize(xmlstringArray, typeName);
            Assert.That(stringArray.GetValue(0), Is.EqualTo("CustomerID"));
            Assert.That(stringArray.GetValue(1), Is.EqualTo("PollInterval"));
        }

        [Test]
        public void SerializationHelper_Deserialize_DateTime()
        {
            var typeName = typeof(System.DateTime).FullName;
            var date = (System.DateTime)SerializationHelper.Deserialize("2012-09-06T01:44:51.648", typeName);
            Assert.AreEqual(date.ToString(CultureInfo.GetCultureInfo("en-US")), "9/6/2012 1:44:51 AM");
        }

        [Test]
        public void SerializationHelper_Serialize_DateTime()
        {
            var typeName = typeof(System.DateTime).FullName;
            var serialzedXml = SerializationHelper.Serialize(new System.DateTime(2012, 9, 6, 1, 44, 51, 648), typeName);

            Assert.That(serialzedXml, Is.EqualTo("2012-09-06T01:44:51.648Z"));
        }

        private readonly OldContract.XmlStrippedSerializer legacySerializer =
            new OldContract.XmlStrippedSerializerCache().GetSerializer(typeof(System.DateTime));

        /// <summary> Legacy version of <see cref="SerializationHelper.SerializeDateTime"/>; 
        /// for deserialization, <see cref="SerializationHelper.DeserializeValue"/> was used
        /// </summary>
        private string Legacy_SerializationHelper_SerializeDateTime(object value)
        {
            return legacySerializer.SerializeToStrippedXml(value);
        }

        /// <summary> <see cref="SerializationHelper.DeserializeValue"/> was used before </summary>
        private object Legacy_SerializationHelper_DeserializeDateTime(string value)
        {
            return legacySerializer.DeserializeFromStrippedXml(value);
        }

        [Test, Description("Unspecified DateTime - old serialization to new de-serialization")]
        public void SerializationHelper_DateTime_Unspecified_Old_To_New()
        {
            var anyTime = new System.DateTime(2011, 1, 1, 1, 1, 1, 1, System.DateTimeKind.Unspecified);

            string serialized = Legacy_SerializationHelper_SerializeDateTime(anyTime);

            var deserialized = SerializationHelper.DeserializeDateTime(serialized, typeof(System.DateTime));

            Assert.That(((System.DateTime)deserialized).Kind, Is.Not.EqualTo(System.DateTimeKind.Unspecified));
            Assert.That(deserialized, Is.EqualTo(anyTime), "serialized='{0}'", serialized);
        }

        [Test, Description("Unspecified DateTime - new serialization to old de-serialization")]
        public void SerializationHelper_DateTime_Unspecified_New_To_Old()
        {
            var anyTime = new System.DateTime(2011, 1, 1, 1, 1, 1, 1, System.DateTimeKind.Unspecified);

            string serialized = SerializationHelper.SerializeDateTime(anyTime, typeof(System.DateTime));

            var deserialized = Legacy_SerializationHelper_DeserializeDateTime(serialized);

            // we need same point in tame, but not necessarily in the same format
            var deserializedUtc = ((System.DateTime)deserialized).ToUniversalTime();

            Assert.That(((System.DateTime)deserialized).Kind, Is.Not.EqualTo(System.DateTimeKind.Unspecified));
            Assert.That(deserializedUtc, Is.EqualTo(anyTime), "serialized='{0}'", serialized);
        }

        [Test, Description("Local DateTime - old serialization to new de-serialization")]
        public void SerializationHelper_DateTime_Local_Old_To_New()
        {
            var anyTime = new System.DateTime(2011, 1, 1, 1, 1, 1, 1, System.DateTimeKind.Local);

            string serialized = Legacy_SerializationHelper_SerializeDateTime(anyTime);

            var deserialized = SerializationHelper.DeserializeDateTime(serialized, typeof(System.DateTime));

            Assert.That(((System.DateTime)deserialized).Kind, Is.Not.EqualTo(System.DateTimeKind.Unspecified));

            var anyTimeUtc = anyTime.ToUniversalTime();

            Assert.That(deserialized, Is.EqualTo(anyTimeUtc), "serialized='{0}'", serialized);
        }

        [Test, Description("Local DateTime - new serialization to old de-serialization")]
        public void SerializationHelper_DateTime_Local_New_To_Old()
        {
            var anyTime = new System.DateTime(2011, 1, 1, 1, 1, 1, 1, System.DateTimeKind.Local);

            string serialized = SerializationHelper.SerializeDateTime(anyTime, typeof(System.DateTime));

            var deserialized = Legacy_SerializationHelper_DeserializeDateTime(serialized);

            Assert.That(((System.DateTime)deserialized).Kind, Is.Not.EqualTo(System.DateTimeKind.Unspecified));

            var anyTimeUtc = anyTime.ToUniversalTime();

            Assert.That(deserialized, Is.EqualTo(anyTimeUtc), "serialized='{0}'", serialized);
        }

        [Test, Description("UTC DateTime - old serialization to new de-serialization")]
        public void SerializationHelper_DateTime_Utc_Old_To_New()
        {
            var anyTime = new System.DateTime(2011, 1, 1, 1, 1, 1, 1, System.DateTimeKind.Utc);

            string serialized = Legacy_SerializationHelper_SerializeDateTime(anyTime);

            var deserialized = SerializationHelper.DeserializeDateTime(serialized, typeof(System.DateTime));

            Assert.That(((System.DateTime)deserialized).Kind, Is.Not.EqualTo(System.DateTimeKind.Unspecified));
            Assert.That(deserialized, Is.EqualTo(anyTime), "serialized='{0}'", serialized);
        }

        [Test, Description("UTC DateTime - new serialization to old de-serialization")]
        public void SerializationHelper_DateTime_Utc_New_To_Old()
        {
            var anyTime = new System.DateTime(2011, 1, 1, 1, 1, 1, 1, System.DateTimeKind.Utc);
            string serialized = SerializationHelper.SerializeDateTime(anyTime, typeof(System.DateTime));

            var deserialized = Legacy_SerializationHelper_DeserializeDateTime(serialized);

            Assert.That(((System.DateTime)deserialized).Kind, Is.Not.EqualTo(System.DateTimeKind.Unspecified));

            // we need same point in tame, but not necessarily in the same format
            var deserializedUtc = ((System.DateTime)deserialized).ToUniversalTime();

            Assert.That(deserializedUtc, Is.EqualTo(anyTime), "serialized='{0}'", serialized);
        }

        [Test]
        public void XmlSerializer_Deserialize_Whitespace()
        {
            var serializer = new XmlSerializer(typeof(PropertyBag));
            var bag = (PropertyBag)serializer.Deserialize(new StringReader(xmlWhitespace));
            Assert.That(bag.ContainsKey("CustomerID"));
            Assert.That(bag["CustomerID"], Is.EqualTo("3333"));
        }

        [Test]
        public void DataContractSerializer_Deserialize_NoWhitespace()
        {
            var serializer = new DataContractSerializer(typeof(PropertyBag));
            var bag = (PropertyBag)serializer.ReadObject(new XmlTextReader(new StringReader(xmlNoWhitespace)));
            Assert.That(bag.ContainsKey("CustomerID"));
            Assert.That(bag["CustomerID"], Is.EqualTo("3333"));
        }

        [Test]
        public void DataContractSerializer_Deserialize_Whitespace()
        {
            var serializer = new DataContractSerializer(typeof(PropertyBag));
            var bag = (PropertyBag)serializer.ReadObject(new XmlTextReader(new StringReader(xmlWhitespace)));
            Assert.That(bag.ContainsKey("CustomerID"));
            Assert.That(bag["CustomerID"], Is.EqualTo("3333"));
        }

        [Test]
        public void DataContractSerializer_Serialize()
        {
            var serializer = new DataContractSerializer(typeof(PropertyBag));
            var bag = new PropertyBag { { "CustomerID", "3333" } };
            var buffer = new StringBuilder();
            using (var writer = new StringWriter(buffer))
            using (var xmlWriter = new XmlTextWriter(writer))
                serializer.WriteObject(xmlWriter, bag);
            Assert.That(buffer.ToString(), Is.EqualTo(xmlNoWhitespace));
        }

        [Test]
        public void XmlSerializer_Serialize()
        {
            var serializer = new XmlSerializer(typeof(PropertyBag));
            var bag = new PropertyBag { { "CustomerID", "3333" } };
            var buffer = new StringBuilder();
            using (var xmlWriter = XmlWriter.Create(buffer, new XmlWriterSettings { OmitXmlDeclaration = true }))
                serializer.Serialize(xmlWriter, bag);
            Assert.That(buffer.ToString(), Is.EqualTo(xmlNoWhitespace));
        }

        [Test]
        public void NoNamespace()
        {
            var stringReader = new StringReader(xmlNoNamespace);
            var xmlReader = new XmlTextReader(stringReader);
            xmlReader.Read();
            var bag = new PropertyBag();
            bag.ReadXml(xmlReader);
            Assert.That(bag.ContainsKey("CustomerID"));
            Assert.That(bag["CustomerID"], Is.EqualTo("3333"));
        }

        [Test]
        public void DiscoveryNodeOldContract()
        {
            var bag2 = DataContractDeserialize<OldContract.PropertyBag>(xmlDiscoveryNode);
            Assert.That(bag2.ContainsKey("SNMPV2Only"));
        }

        [Test]
        public void NestedNewContract()
        {
            string xml = DataContractSerialize(nested);
            Assert.That(xml, Is.EqualTo(nestedXml));
            var bag2 = DataContractDeserialize<PropertyBag>(xml);
            Assert.That(((PropertyBag)bag2["bag"])["inner"], Is.EqualTo("stuff"));
        }

        [Test]
        public void NestedOldContract()
        {
            string xml = DataContractSerialize(nested);
            var bag2 = DataContractDeserialize<OldContract.PropertyBag>(xml);
            Assert.That(bag2["prop"], Is.EqualTo("value"));
        }

        [Test]
        public void DoublyNestedNewContract()
        {
            string xml = DataContractSerialize(doubleNested);
            var bag2 = DataContractDeserialize<PropertyBag>(xml);
            Assert.That(((PropertyBag)bag2["bag"])["inner"], Is.EqualTo("stuff"));
            var innerBag = ((PropertyBag)bag2["bag"]);
            Assert.That(((PropertyBag)innerBag["bagbag"])["bottom"], Is.EqualTo("thing"));
        }

        [Test]
        public void DoublyNestedOldContract()
        {
            string xml = DataContractSerialize(doubleNested);
            var bag2 = DataContractDeserialize<OldContract.PropertyBag>(xml);
            Assert.That(bag2["prop"], Is.EqualTo("value"));
        }

        [Test]
        public void EmptyAndNullStrings()
        {
            PropertyBag bag = new PropertyBag
            {
                {"p0", (string) null},
                {"p1", ""}
            };

            string xml = DataContractSerialize(bag);
            var bag2 = DataContractDeserialize<PropertyBag>(xml);
            Assert.That(bag2["p0"], Is.Null);
            Assert.That(bag2["p1"], Is.Empty);
        }

        [Test]
        public void TwoNullsNew2New()
        {
            string xml = DataContractSerialize(twoNulls);
            var bag2 = DataContractDeserialize<PropertyBag>(xml);
            Assert.That(bag2["asdf"], Is.Null);
            Assert.That(bag2["qwer"], Is.Null);
        }

        [Test]
        public void TwoNullsOld2New()
        {
            string xml = DataContractSerialize(new OldContract.PropertyBag(twoNulls));
            var bag2 = DataContractDeserialize<PropertyBag>(xml);
            Assert.That(bag2["asdf"], Is.Null);
            Assert.That(bag2["qwer"], Is.Null);
        }

        [Test]
        public void TwoNullsNew2Old()
        {
            string xml = DataContractSerialize(twoNulls);
            // I'm just happy if it doesn't crash!
            Assert.DoesNotThrow(() => DataContractDeserialize<OldContract.PropertyBag>(xml));
        }

        [Test]
        [Ignore("This test fails, but there's nothing I can do about it. If I could fix the old contracts this would be much easier!")]
        public void TwoNullsOld2Old()
        {
            string xml = DataContractSerialize(new OldContract.PropertyBag(twoNulls));
            var bag2 = DataContractDeserialize<OldContract.PropertyBag>(xml);
            Assert.That(bag2["asdf"], Is.Null);
            Assert.That(bag2["qwer"], Is.Null);
        }

        [Test]
        public void OldContractValueAfterNull()
        {
            var bag = DataContractDeserialize<OldContract.PropertyBag>(xmlValueAfterNull);
            Assert.That(bag["asdf"], Is.EqualTo("myvalue"));
        }

        [Test]
        [Ignore("This is a simple performance test that takes about a minute to run.")]
        public void TestSerializationPerformance()
        {
            const int bagSize = 1000;
            const int iterations = 1000;

            var bigbag = new PropertyBag();
            for (int i = 0; i < bagSize; ++i)
                bigbag["key" + i] = "value" + i;

            var newSerializer = new DataContractSerializer(typeof(PropertyBag));
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; ++i)
                DataContractSerialize(bigbag, newSerializer);
            stopwatch.Stop();

            var oldbigbag = new OldContract.PropertyBag();
            for (int i = 0; i < bagSize; ++i)
                oldbigbag["key" + i] = "value" + i;

            var oldSerializer = new DataContractSerializer(typeof(OldContract.PropertyBag));
            Stopwatch oldContractStopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; ++i)
                DataContractSerialize(oldbigbag, oldSerializer);
            oldContractStopwatch.Stop();

            Debug.WriteLine(string.Format("New PropertyBag with {0} items serialized {1} times in {2} milliseconds", bagSize, iterations,
                                          stopwatch.ElapsedMilliseconds));
            Debug.WriteLine(string.Format("Old PropertyBag with {0} items serialized {1} times in {2} milliseconds", bagSize, iterations,
                                          oldContractStopwatch.ElapsedMilliseconds));

            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(2 * oldContractStopwatch.ElapsedMilliseconds));
        }

        [Test]
        [Ignore("This is a simple performance test that takes about a minute to run.")]
        public void TestDeserializationPerformance()
        {
            const int bagSize = 1000;
            const int iterations = 1000;

            var bigbag = new PropertyBag();
            for (int i = 0; i < bagSize; ++i)
                bigbag["key" + i] = "value" + i;

            var newSerializer = new DataContractSerializer(typeof(PropertyBag));
            var oldSerializer = new DataContractSerializer(typeof(OldContract.PropertyBag));

            string bagxml = DataContractSerialize(bigbag, newSerializer);

            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; ++i)
                DataContractDeserialize<PropertyBag>(bagxml, newSerializer);
            stopwatch.Stop();

            Stopwatch oldContractStopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; ++i)
                DataContractDeserialize<OldContract.PropertyBag>(bagxml, oldSerializer);
            oldContractStopwatch.Stop();

            Debug.WriteLine(string.Format("New PropertyBag with {0} items deserialized {1} times in {2} milliseconds", bagSize, iterations,
                                          stopwatch.ElapsedMilliseconds));
            Debug.WriteLine(string.Format("Old PropertyBag with {0} items deserialized {1} times in {2} milliseconds", bagSize, iterations,
                                          oldContractStopwatch.ElapsedMilliseconds));

            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(2 * oldContractStopwatch.ElapsedMilliseconds));
        }

        [Test]
        [SetCulture("is-IS")]
        public void TryIcelandicPropertyBagSerialization()
        {
            var pbag = new PropertyBag(new Dictionary<string, object> { { "Longitude", 16.561889648437 }, { "Latitude", 49.175419308763 } });

            var lng1 = (double)pbag["Longitude"];

            var pbag2 = RoundTrip(pbag);
            var value = (double)pbag2["Longitude"];
            Assert.That(lng1, Is.EqualTo(value), "oops - round trip failed to ensure double keeps same value INSIDE of PropertyBag.");
        }

        private T RoundTrip<T>(T obj)
        {
            var xml = DataContractSerialize(obj);
            return DataContractDeserialize<T>(xml);
        }

        private static string DataContractSerialize(object obj, DataContractSerializer serializer = null)
        {
            serializer = serializer ?? new DataContractSerializer(obj.GetType());
            var buffer = new StringBuilder();
            using (var writer = new StringWriter(buffer))
            using (var xmlWriter = new XmlTextWriter(writer))
                serializer.WriteObject(xmlWriter, obj);
            return buffer.ToString();
        }

        private static T DataContractDeserialize<T>(string xml, DataContractSerializer serializer = null)
        {
            serializer = serializer ?? new DataContractSerializer(typeof(T));
            return (T)serializer.ReadObject(new XmlTextReader(new StringReader(xml)));
        }
    }
}
