using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Xml;
using SolarWinds.InformationService.Contract2;

namespace SolarWinds.InformationService.InformationServiceClient
{
    public class InformationServiceDataAdapter : DbDataAdapter
    {
        private DataTable currentSchema;

        internal InformationServiceDataAdapter()
        {

        }

        public InformationServiceDataAdapter(InformationServiceCommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            base.SelectCommand = command;
        }

        public XmlDocument QueryPlan { get; private set; }
        public XmlDocument QueryStats { get; private set; }

        private void Columns_CollectionChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
            if (e.Action == System.ComponentModel.CollectionChangeAction.Add)
            {
                DataColumn column = (DataColumn)e.Element;
                if (column.DataType == typeof(DateTime))
                {
                    column.DateTimeMode = (DataSetDateTime)currentSchema.Rows[column.Ordinal]["ColumnDateTimeMode"];
                }
            }
        }

        internal int FillData(DataTable dataTable, IDataReader dataReader)
        {
            currentSchema = dataReader.GetSchemaTable();

            return this.Fill(dataTable, dataReader);
        }

        protected override int Fill(DataTable dataTable, IDataReader dataReader)
        {
            currentSchema = dataReader.GetSchemaTable();

            try
            {
                dataTable.Columns.CollectionChanged += Columns_CollectionChanged;

                AddExtendedProperties(new[] { dataTable }, dataReader);
                return base.Fill(dataTable, dataReader);
            }
            finally
            {
                dataTable.Columns.CollectionChanged -= Columns_CollectionChanged;
            }
        }

        protected override int Fill(DataSet dataSet, string srcTable, IDataReader dataReader, int startRecord, int maxRecords)
        {
            currentSchema = dataReader.GetSchemaTable();

            try
            {
                foreach (var dt in dataSet.Tables.Cast<DataTable>())
                    dt.Columns.CollectionChanged += Columns_CollectionChanged;

                AddExtendedProperties(dataSet.Tables, dataReader);
                return base.Fill(dataSet, srcTable, dataReader, startRecord, maxRecords);
            }
            finally
            {
                foreach (var dt in dataSet.Tables.Cast<DataTable>())
                    dt.Columns.CollectionChanged -= Columns_CollectionChanged;
            }
        }

        protected override int Fill(DataTable[] dataTables, IDataReader dataReader, int startRecord, int maxRecords)
        {
            currentSchema = dataReader.GetSchemaTable();

            try
            {
                foreach (var dt in dataTables)
                    dt.Columns.CollectionChanged += Columns_CollectionChanged;

                AddExtendedProperties(dataTables, dataReader);

                return base.Fill(dataTables, dataReader, startRecord, maxRecords);
            }
            finally
            {
                foreach (var dt in dataTables)
                    dt.Columns.CollectionChanged -= Columns_CollectionChanged;
            }
        }

        private void AddExtendedProperties(IEnumerable dataTables, IDataReader dataReader)
        {
            var informationServiceDataReader = dataReader as InformationServiceDataReader;
            if (informationServiceDataReader != null)
            {
                QueryPlan = informationServiceDataReader.QueryPlan;
                QueryStats = informationServiceDataReader.QueryStats;
                foreach (DataTable dataTable in dataTables)
                {
                    dataTable.ExtendedProperties["TotalRows"] = (informationServiceDataReader).TotalRows;
                    dataTable.ExtendedProperties[Constants.ErrorMessagesProperty] = informationServiceDataReader.Errors;
                    dataTable.ExtendedProperties["Metadata"] = informationServiceDataReader.GetSchemaTable();
                }
            }
        }
    }
}
