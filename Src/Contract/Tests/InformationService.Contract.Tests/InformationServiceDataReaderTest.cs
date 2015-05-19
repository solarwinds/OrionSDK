using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SolarWinds.InformationService.InformationServiceClient;
using System.Xml;
using System.IO;

namespace SolarWinds.InformationService.Contract2
{
    [TestFixture]
    public class InformationServiceDataReaderTest
    {

        [Test]
        public void InformationServiceDataReader_DbNull()
        {
            string response = @"
<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice'
xmlns:" + InformationServiceDataReader.DBNullPrefix + "='" + InformationServiceDataReader.DBNullNamespace + @"'>
  <QueryXmlResult>
    <queryResult>
      <template>
        <resultset>
          <column name='IsNavigable' type='Boolean' ordinal='0'></column>
          <column name='IsInherited' type='Boolean' ordinal='1'></column>
        </resultset>
      </template>
      <data>
        <row>
          <c0 " + DbNullAttribute + @"></c0>
          <c1 " + InformationServiceDataReader.DBNullPrefix + ':' + InformationServiceDataReader.DBNullAttribute + @"='false'>True</c1>
        </row>
      </data>
    </queryResult>
  </QueryXmlResult>
</QueryXmlResponse>
";

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

            Assert.IsTrue(reader.Read());

            Assert.AreEqual(DBNull.Value, reader.GetValue(0));

            //This shouldn't be DBNull, but a boolean true
            Assert.AreEqual(true, reader.GetValue(1));
        }

        [Test]
        public void InformationServiceDataReader_ZeroRows()
        {
            const string response = @"
<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice'
xmlns:" + InformationServiceDataReader.DBNullPrefix + "='" + InformationServiceDataReader.DBNullNamespace + @"'>
  <QueryXmlResult>
    <queryResult xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
      <template>
        <resultset>
          <column name='Caption' type='String' ordinal='0' />
        </resultset>
      </template>
    </queryResult>
  </QueryXmlResult>
</QueryXmlResponse>
";

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

            Assert.IsFalse(reader.Read());
        }

        [Test]
        public void InformationServiceDataReader_EmptyString()
        {
            string response =
                string.Format(
                    @"<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice' xmlns:{0}='{1}'>
  <QueryXmlResult>
    <queryResult>
      <template>
        <resultset>
          <column name='EntityName' type='String' ordinal='0'></column>
          <column name='Name' type='String' ordinal='1'></column>
        </resultset>
      </template>
      <data>
        <row>
          <c0 {2}></c0>
          <c1></c1>
        </row>
      </data>
    </queryResult>
  </QueryXmlResult>
</QueryXmlResponse>
",
                    InformationServiceDataReader.DBNullPrefix, InformationServiceDataReader.DBNullNamespace,
                    DbNullAttribute);

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

            Assert.IsTrue(reader.Read());

            Assert.IsNull(reader.GetString(0));                  //Should be null string.
            Assert.AreEqual(String.Empty, reader.GetString(1));  //Should be empty string

        }

        [Test]
        public void InformationServiceDataReader_EmptyElement()
        {
            const string response =
@"<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice'>
  <QueryXmlResult>
    <queryResult>
      <template>
        <resultset>
          <column name='EntityName' type='String' ordinal='0'></column>
        </resultset>
      </template>
      <data>
        <row>
          <c0/>
        </row>
      </data>
    </queryResult>
  </QueryXmlResult>
</QueryXmlResponse>
";

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

            Assert.IsTrue(reader.Read());

            Assert.AreEqual(String.Empty, reader.GetString(0));  //Should be empty string

        }

        [Test]
        public void InformationServiceDataReader_Array()
        {
            const string response =
@"<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice'>
  <QueryXmlResult>
    <queryResult>
      <template>
        <resultset>
          <column name='EntityName' type='String' ordinal='0'></column>
          <column name='SomeArray' type='String[]' ordinal='1'></column>
        </resultset>
      </template>
      <data>
        <row>
          <c0>some name</c0>
          <c1>
            <item>first</item>
            <item>second</item>
          </c1>
        </row>
      </data>
    </queryResult>
  </QueryXmlResult>
</QueryXmlResponse>
";

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

            Assert.IsTrue(reader.Read());

            Assert.AreEqual("some name", reader.GetString(0));
            string[] values = (string[])reader.GetValue(1);
            Assert.AreEqual(2, values.Length);
            Assert.AreEqual("first", values[0]);
            Assert.AreEqual("second", values[1]);
        }

        [Test]
        public void InformationServiceDataReader_StringWithSpecialChars()
        {
            string response =
                string.Format(
                    @"<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice' xmlns:{0}='{1}'>
  <QueryXmlResult>
    <queryResult>
      <template>
        <resultset>
          <column name='EntityName' type='String' ordinal='0'></column>
          <column name='Name' type='String' ordinal='1'></column>
          <column name='Name2' type='String' ordinal='2'></column>
        </resultset>
      </template>
      <data>
        <row>
          <c0>Hello &gt; World</c0>
          <c1>Karlo &amp; Zeid</c1>
          <c2>&#91;Zarlo&#93;</c2>
        </row>
      </data>
    </queryResult>
  </QueryXmlResult>
</QueryXmlResponse>
",
                    InformationServiceDataReader.DBNullPrefix, InformationServiceDataReader.DBNullNamespace);

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

            Assert.IsTrue(reader.Read());

            Assert.AreEqual("Hello > World", reader.GetString(0));
            Assert.AreEqual("Karlo & Zeid", reader.GetString(1));
            Assert.AreEqual("[Zarlo]", reader.GetString(2));

            Assert.IsFalse(reader.Read());
        }

        [Test]
        public void InformationServiceDataReader_ErrorMessages()
        {
            string response =
                string.Format(
                    @"<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice' xmlns:{0}='{1}'>
                        <QueryXmlResult>
                            <queryResult>
                                <template>
                                <resultset>
                                    <column name='NodeID' type='Int32' ordinal='0'>
                                    </column>
                                    <column name='strValues' type='String[]' ordinal='1'>
                                    </column>
                                </resultset>
                                </template>
                                <data>
                                <row>
                                    <c0>29</c0>
                                    <c1>
                                        <item>item 1</item>
                                        <item>item 2</item>
                                        <item>last item</item>
                                    </c1>
                                </row>    
                                <row>
                                    <c0>30</c0>
                                    <c1>
                                        <item>item 11</item>
                                        <item>item 21</item>
                                        <item>last item 1</item>
                                    </c1>
                                </row>                            
                                </data>
                            </queryResult>
                            <errors><error><errorType>System.ServiceModel.EndpointNotFoundException</errorType><context>net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl</context><message>There was no endpoint listening at net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.</message></error>
                                    <error><errorType>System.ServiceModel.EndpointNotFoundException</errorType><context>net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl</context><message>There was no endpoint listening at net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.</message></error>
                            </errors>
                        </QueryXmlResult>
                    </QueryXmlResponse>", InformationServiceDataReader.DBNullPrefix, InformationServiceDataReader.DBNullNamespace);

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

            Assert.IsTrue(reader.Read());
            Assert.AreEqual(29, reader.GetInt32(0));
            Assert.AreEqual(new String[] { "item 1", "item 2", "last item" }, reader.GetArray<string>(1));
            Assert.IsTrue(reader.Read());
            Assert.AreEqual(30, reader.GetInt32(0));
            Assert.AreEqual(new String[] { "item 11", "item 21", "last item 1" }, reader.GetArray<string>(1));
            Assert.IsFalse(reader.Read());
            Assert.IsNotNull(reader.Errors);
            Assert.AreEqual(2, reader.Errors.Count);
            Assert.AreEqual("System.ServiceModel.EndpointNotFoundException", reader.Errors[0].ErrorType);
            Assert.AreEqual("There was no endpoint listening at net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.", reader.Errors[0].Message);
            Assert.AreEqual("net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl", reader.Errors[0].Context);
            Assert.AreEqual("System.ServiceModel.EndpointNotFoundException", reader.Errors[1].ErrorType);
            Assert.AreEqual("There was no endpoint listening at net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.", reader.Errors[1].Message);
            Assert.AreEqual("net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl", reader.Errors[1].Context);

        }

        private string DbNullAttribute
        {
            get
            {
                return string.Format("{0}:{1}='{2}'",
                                     InformationServiceDataReader.DBNullPrefix,
                                     InformationServiceDataReader.DBNullAttribute,
                                     InformationServiceDataReader.DBNullValue);
            }
        }

        private static InformationServiceDataReader GetInformationServiceDataReader(string response)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(response);
            MemoryStream stream = new MemoryStream(byteArray);

            XmlDictionaryReader xmlDictionaryreader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());

            InformationServiceDataReader reader = new InformationServiceDataReader(new InformationServiceCommand("My statment"), xmlDictionaryreader);

            return reader;
        }

    }
}
