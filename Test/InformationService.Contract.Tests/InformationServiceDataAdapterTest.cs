using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using NUnit.Framework;
using SolarWinds.InformationService.InformationServiceClient;

namespace SolarWinds.InformationService.Contract2.InformationServiceClient
{
    [TestFixture]
    public class InformationServiceDataAdapterTest
    {
        [TestCase(DataSetDateTime.Local)]
        [TestCase(DataSetDateTime.Utc)]
        [TestCase(DataSetDateTime.Unspecified)]
        public void FillData_DateTimeMode(DataSetDateTime dateTimeMode)
        {
            DataTable dataTable = new DataTable();

            InformationServiceDataAdapter instance = new InformationServiceDataAdapter();

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
                instance.FillData(dataTable, reader);
            }

            var dt1 = (DateTime)dataTable.Rows[0][0];
            var dt2 = (DateTime)dataTable.Rows[0][1];

            Assert.AreEqual(dateTimeMode, dataTable.Columns[0].DateTimeMode);
            Assert.AreEqual(dateTimeMode, dataTable.Columns[1].DateTimeMode);

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

        private static InformationServiceDataReader GetInformationServiceDataReader(string response, DataSetDateTime dateTimeMode = DataSetDateTime.Utc)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(response);
            MemoryStream stream = new MemoryStream(byteArray);

            XmlDictionaryReader xmlDictionaryreader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas());

            InformationServiceDataReader reader = new InformationServiceDataReader(new InformationServiceCommand("My statment"), xmlDictionaryreader, dateTimeMode);

            return reader;
        }
    }
}