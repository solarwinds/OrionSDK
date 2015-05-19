using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Xml;
using SolarWinds.InformationService.Contract2;

namespace SolarWinds.InformationService.InformationServiceClient
{
    public class InformationServiceDataAdapter : DbDataAdapter
    {
        public InformationServiceDataAdapter(InformationServiceCommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            base.SelectCommand = command;
        }

        public XmlDocument QueryPlan { get; private set; }

        protected override int Fill(DataTable dataTable, IDataReader dataReader)
        {
            AddMetadata(new[] {dataTable}, dataReader);
            AddErrorMessages(new[] {dataTable}, dataReader);
            return base.Fill(dataTable, dataReader);
        }

        protected override int Fill(DataSet dataSet, string srcTable, IDataReader dataReader, int startRecord, int maxRecords)
        {
            AddMetadata(dataSet.Tables, dataReader);
            AddErrorMessages(dataSet.Tables, dataReader);
            return base.Fill(dataSet, srcTable, dataReader, startRecord, maxRecords);
        }

        protected override int Fill(DataTable[] dataTables, IDataReader dataReader, int startRecord, int maxRecords)
        {
            AddMetadata(dataTables, dataReader);
            AddErrorMessages(dataTables, dataReader);
            return base.Fill(dataTables, dataReader, startRecord, maxRecords);
        }

        private void AddMetadata(IEnumerable dataTables, IDataReader dataReader)
        {
            var informationServiceDataReader = dataReader as InformationServiceDataReader;
            if (informationServiceDataReader != null)
            {
                QueryPlan = informationServiceDataReader.QueryPlan;
                foreach (DataTable dataTable in dataTables)
                {
                    dataTable.ExtendedProperties.Add("TotalRows", (informationServiceDataReader).TotalRows);
                }
            }
        }

        private void AddErrorMessages(IEnumerable dataTables, IDataReader reader)
        {
            var informationServiceDataReader = reader as InformationServiceDataReader;

            if (informationServiceDataReader != null)
            {
                foreach (DataTable dataTable in dataTables)
                {
                    dataTable.ExtendedProperties.Add(Constants.ErrorMessagesProperty, informationServiceDataReader.Errors);
                }
            }
        }
    }
}
