using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using NUnit.Framework;
using SolarWinds.InformationService.InformationServiceClient;

namespace SolarWinds.InformationService.Contract2
{
    [TestFixture]
    public class InformationServiceDataReaderTest
    {

        [TestCase(DataSetDateTime.Local)]
        [TestCase(DataSetDateTime.Utc)]
        [TestCase(DataSetDateTime.Unspecified)]
        public void InformationServiceDataReader_DateTimeMode(DataSetDateTime dateTimeMode)
        {
            var nowUtc = DateTime.UtcNow;
            var nowLocal = nowUtc.ToLocalTime();

            string col1Date = nowUtc.ToString("o");
            string col2Date = nowLocal.ToString("o");

            string response = $@"
<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice'
xmlns:{InformationServiceDataReader.DBNullPrefix}='{InformationServiceDataReader.DBNullNamespace}'>
  <QueryXmlResult>
    <queryResult>
      <template>
        <resultset>
          <column name='col1' type='DateTime' ordinal='0'></column>
          <column name='col2' type='DateTime' ordinal='1'></column>
        </resultset>
      </template>
      <data>
        <row>
          <c0>{col1Date}</c0>
          <c1>{col2Date}</c1>
        </row>
      </data>
    </queryResult>
  </QueryXmlResult>
</QueryXmlResponse>
";
            using (InformationServiceDataReader reader = GetInformationServiceDataReader(response, dateTimeMode))
            {
                Assert.IsTrue(reader.Read());

                var dt1 = reader.GetDateTime(0);
                var dt2 = reader.GetDateTime(1);

                switch (dateTimeMode)
                {
                    case DataSetDateTime.Local:
                        Assert.AreEqual(nowLocal, dt1);
                        Assert.AreEqual(DateTimeKind.Local, dt1.Kind);
                        Assert.AreEqual(dt1, dt2);
                        break;
                    case DataSetDateTime.Utc:
                        Assert.AreEqual(nowUtc, dt1);
                        Assert.AreEqual(DateTimeKind.Utc, dt1.Kind);
                        Assert.AreEqual(dt1, dt2);
                        break;
                    case DataSetDateTime.Unspecified:
                        Assert.AreEqual(nowUtc, dt1);
                        Assert.AreEqual(DateTimeKind.Unspecified, dt1.Kind);

                        Assert.AreEqual(nowLocal, dt2);
                        Assert.AreEqual(DateTimeKind.Unspecified, dt2.Kind);

                        break;
                    default:
                        throw new NotImplementedException();
                }


            }
        }


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
            Assert.AreEqual(string.Empty, reader.GetString(1));  //Should be empty string

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

            Assert.AreEqual(string.Empty, reader.GetString(0));  //Should be empty string

        }

        [Test]
        public void InformationServiceDataReader_Metadata()
        {
            const string response =
                @"<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice'>
  <QueryXmlResult>
    <queryResult>
      <template>
        <resultset>
          <column name='EntityName' type='String' ordinal='0' foo='bar'></column>
        </resultset>
      </template>
      <data>
        <row>
          <c0>some name</c0>
        </row>
      </data>
    </queryResult>
  </QueryXmlResult>
</QueryXmlResponse>
";

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

            Assert.IsTrue(reader.Read());

            DataTable schemaTable = reader.GetSchemaTable();
            Assert.That(schemaTable.Rows[0]["foo"], Is.EqualTo("bar"));
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
        public void InformationServiceDataReader_QueryPlan()
        {
            string response =
                string.Format(
                    @"<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice' xmlns:{0}='{1}'>
  <QueryXmlResult>    
    <queryResult>
      <queryPlan type='physical'>
        <thisIsMyBoomstick />
      </queryPlan>
      <template>
        <resultset>
          <column name='EntityName' type='String' ordinal='0'></column>
        </resultset>
      </template>
      <data>
        <row>
          <c0>Whatever</c0>
        </row>
      </data>
    </queryResult>
  </QueryXmlResult>
</QueryXmlResponse>
",
                    InformationServiceDataReader.DBNullPrefix, InformationServiceDataReader.DBNullNamespace);

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

            Assert.IsTrue(reader.Read());

            Assert.AreEqual("Whatever", reader.GetString(0));
            Assert.IsFalse(reader.Read());

            var queryPlan = reader.QueryPlan;
            Assert.That(queryPlan, Is.Not.Null);
            Assert.That(queryPlan.InnerXml, Is.EqualTo("<queryPlan type=\"physical\" xmlns=\"http://schemas.solarwinds.com/2007/08/informationservice\"><thisIsMyBoomstick /></queryPlan>"));
        }

        [Test]
        public void InformationServiceDataReader_NoRows_QueryPlan()
        {
            string response =
                string.Format(
                    @"<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice' xmlns:{0}='{1}'>
  <QueryXmlResult>    
    <queryResult>
      <queryPlan type='physical'>
        <thisIsMyBoomstick />
      </queryPlan>
      <template>
        <resultset>
          <column name='EntityName' type='String' ordinal='0'></column>
        </resultset>
      </template>
    </queryResult>
  </QueryXmlResult>
</QueryXmlResponse>
",
                    InformationServiceDataReader.DBNullPrefix, InformationServiceDataReader.DBNullNamespace);

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

            Assert.IsFalse(reader.Read());

            var queryPlan = reader.QueryPlan;
            Assert.That(queryPlan, Is.Not.Null);
            Assert.That(queryPlan.InnerXml, Is.EqualTo("<queryPlan type=\"physical\" xmlns=\"http://schemas.solarwinds.com/2007/08/informationservice\"><thisIsMyBoomstick /></queryPlan>"));
        }

        [Test]
        public void InformationServiceDataReader_QueryPlanAndErrorMessages()
        {
            string response =
                string.Format(
                    @"<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice' xmlns:{0}='{1}'>
  <QueryXmlResult>    
    <queryResult>
      <queryPlan type='physical'>
        <thisIsMyBoomstick />
      </queryPlan>
      <template>
        <resultset>
          <column name='EntityName' type='String' ordinal='0'></column>
        </resultset>
      </template>
      <data>
        <row>
          <c0>Whatever</c0>
        </row>
      </data>
    </queryResult>
    <errors><error><errorType>System.ServiceModel.EndpointNotFoundException</errorType><context>net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl</context><message>There was no endpoint listening at net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.</message></error>
            <error><errorType>System.ServiceModel.EndpointNotFoundException</errorType><context>net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl</context><message>There was no endpoint listening at net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.</message></error>
    </errors>
  </QueryXmlResult>
</QueryXmlResponse>
",
                    InformationServiceDataReader.DBNullPrefix, InformationServiceDataReader.DBNullNamespace);

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

            Assert.IsTrue(reader.Read());

            Assert.AreEqual("Whatever", reader.GetString(0));
            Assert.IsFalse(reader.Read());

            var queryPlan = reader.QueryPlan;
            Assert.That(queryPlan, Is.Not.Null);
            Assert.That(queryPlan.InnerXml, Is.EqualTo("<queryPlan type=\"physical\" xmlns=\"http://schemas.solarwinds.com/2007/08/informationservice\"><thisIsMyBoomstick /></queryPlan>"));

            Assert.IsNotNull(reader.Errors);
            Assert.AreEqual(2, reader.Errors.Count);
            Assert.AreEqual("System.ServiceModel.EndpointNotFoundException", reader.Errors[0].ErrorType);
            Assert.AreEqual("There was no endpoint listening at net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.", reader.Errors[0].Message);
            Assert.AreEqual("net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl", reader.Errors[0].Context);
            Assert.AreEqual("System.ServiceModel.EndpointNotFoundException", reader.Errors[1].ErrorType);
            Assert.AreEqual("There was no endpoint listening at net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.", reader.Errors[1].Message);
            Assert.AreEqual("net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl", reader.Errors[1].Context);
        }

        [Test]
        public void InformationServiceDataReader_NoRows_QueryPlanAndErrorMessages()
        {
            string response =
                string.Format(
                    @"<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice' xmlns:{0}='{1}'>
  <QueryXmlResult>    
    <queryResult>
      <queryPlan type='physical'>
        <thisIsMyBoomstick />
      </queryPlan>
      <template>
        <resultset>
          <column name='EntityName' type='String' ordinal='0'></column>
        </resultset>
      </template>
    </queryResult>
    <errors><error><errorType>System.ServiceModel.EndpointNotFoundException</errorType><context>net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl</context><message>There was no endpoint listening at net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.</message></error>
            <error><errorType>System.ServiceModel.EndpointNotFoundException</errorType><context>net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl</context><message>There was no endpoint listening at net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.</message></error>
    </errors>
  </QueryXmlResult>
</QueryXmlResponse>
",
                    InformationServiceDataReader.DBNullPrefix, InformationServiceDataReader.DBNullNamespace);

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

            Assert.IsFalse(reader.Read());

            var queryPlan = reader.QueryPlan;
            Assert.That(queryPlan, Is.Not.Null);
            Assert.That(queryPlan.InnerXml, Is.EqualTo("<queryPlan type=\"physical\" xmlns=\"http://schemas.solarwinds.com/2007/08/informationservice\"><thisIsMyBoomstick /></queryPlan>"));

            Assert.IsNotNull(reader.Errors);
            Assert.AreEqual(2, reader.Errors.Count);
            Assert.AreEqual("System.ServiceModel.EndpointNotFoundException", reader.Errors[0].ErrorType);
            Assert.AreEqual("There was no endpoint listening at net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.", reader.Errors[0].Message);
            Assert.AreEqual("net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl", reader.Errors[0].Context);
            Assert.AreEqual("System.ServiceModel.EndpointNotFoundException", reader.Errors[1].ErrorType);
            Assert.AreEqual("There was no endpoint listening at net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.", reader.Errors[1].Message);
            Assert.AreEqual("net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl", reader.Errors[1].Context);
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
            Assert.AreEqual(new[] { "item 1", "item 2", "last item" }, reader.GetArray<string>(1));
            Assert.IsTrue(reader.Read());
            Assert.AreEqual(30, reader.GetInt32(0));
            Assert.AreEqual(new[] { "item 11", "item 21", "last item 1" }, reader.GetArray<string>(1));
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

        [Test]
        public void InformationServiceDataReader_NoRows_WithErrorMessgaes()
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
                            </queryResult>
                            <errors><error><errorType>System.ServiceModel.EndpointNotFoundException</errorType><context>net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl</context><message>There was no endpoint listening at net.tcp://10.100.116.119:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.</message></error>
                                    <error><errorType>System.ServiceModel.EndpointNotFoundException</errorType><context>net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl</context><message>There was no endpoint listening at net.tcp://10.100.116.120:17777/SolarWinds/InformationService/v3/Orion/ssl that could accept the message. This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.</message></error>
                            </errors>
                        </QueryXmlResult>
                    </QueryXmlResponse>", InformationServiceDataReader.DBNullPrefix, InformationServiceDataReader.DBNullNamespace);

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

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

        [Test]
        public void InformationServiceDataReader_WithQueryStatistics()
        {
            //Assert.AreEqual("", sb.ToString());
            string response = string.Format(
                @"<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice' xmlns:{0}='{1}'>
  <QueryXmlResult>
    <queryResult>
      <template>
        <resultset>
          <column name='nodeIdAlias' type='Int32' ordinal='0' />
        </resultset>
      </template>
      <data>
        <row>
          <c0>0</c0>
        </row>
      </data>
      <statistics>
        <query type='SWQL' rows='1' elapsedMs='1'>
          <commandText>test</commandText>
        </query>
      </statistics>
    </queryResult>
  </QueryXmlResult>
</QueryXmlResponse>
",
                InformationServiceDataReader.DBNullPrefix, InformationServiceDataReader.DBNullNamespace);

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);
            Assert.IsTrue(reader.Read());

            Assert.IsNotNull(reader.QueryStats);
        }

        [Test]
        public void InformationServiceDataReader_WithoutQueryStatistics()
        {
            //Assert.AreEqual("", sb.ToString());
            string response = string.Format(
                @"<QueryXmlResponse xmlns='http://schemas.solarwinds.com/2007/08/informationservice' xmlns:{0}='{1}'>
  <QueryXmlResult>
    <queryResult>
      <template>
        <resultset>
          <column name='nodeIdAlias' type='Int32' ordinal='0' />
        </resultset>
      </template>
      <data>
        <row>
          <c0>0</c0>
        </row>
      </data>
    </queryResult>
  </QueryXmlResult>
</QueryXmlResponse>
",
                InformationServiceDataReader.DBNullPrefix, InformationServiceDataReader.DBNullNamespace);

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);
            Assert.IsTrue(reader.Read()); // no rows

            Assert.IsNull(reader.QueryStats);
        }

        [Test]
        public void InformationServiceDataReader_WithEncoding()
        {
            string column1Value = "Hello &gt; World";
            string column2Value = "gA7KÃ·A7KÃ§A7KÃ—A7KÃ‡A7KÂ§A7Kâ€”A7JA7UÃ‡ ";
            string column3Value = "Valid string";

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
          <c0 isEncoded='true' encodingType='Base64'>{2}</c0>
          <c1 isEncoded='true' encodingType='Base64'>{3}</c1>
          <c2>{4}</c2>
        </row>
      </data>
    </queryResult>
  </QueryXmlResult>
</QueryXmlResponse>
",
                    InformationServiceDataReader.DBNullPrefix, InformationServiceDataReader.DBNullNamespace,
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(column1Value)),
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(column2Value)),
                    column3Value);

            InformationServiceDataReader reader = GetInformationServiceDataReader(response);

            Assert.IsTrue(reader.Read());

            Assert.AreEqual(column1Value, reader.GetString(0));
            Assert.AreEqual(column2Value, reader.GetString(1));
            Assert.AreEqual(column3Value, reader.GetString(2));

            Assert.IsFalse(reader.Read());
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

        private static InformationServiceDataReader GetInformationServiceDataReader(string response, DataSetDateTime dateTimeMode = DataSetDateTime.Unspecified)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(response);
            MemoryStream stream = new MemoryStream(byteArray);

            XmlDictionaryReader xmlDictionaryreader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());

            InformationServiceDataReader reader = new InformationServiceDataReader(new InformationServiceCommand("My statment"), xmlDictionaryreader, dateTimeMode);

            return reader;
        }

    }
}
