using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using SolarWinds.InformationService.Contract2;

namespace SolarWinds.InformationService.InformationServiceClient
{
    /// <summary>
    /// Provides a way of reading a forward-only stream of rows from a SolarWinds Information Service.
    /// </summary>
    public sealed class InformationServiceDataReader : DbDataReader
    {
        internal const string DBNullNamespace = "http://www.w3.org/2001/XMLSchema-instance";
        internal const string DBNullPrefix = "xsi";
        internal const string DBNullAttribute = "nil";
        internal const string DBNullValue = "true";

        private readonly DbDataReader _resultsReader;
        private List<ErrorMessage> _errors;

        private bool _closed;

        internal InformationServiceDataReader(InformationServiceCommand command, XmlDictionaryReader reader)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            if (reader == null)
                throw new ArgumentNullException("reader");

            _resultsReader = LoadData(reader);
        }

        #region DbDataReader Methods

        public override void Close()
        {
            if (_closed)
                throw new InvalidOperationException("already closed");

            _closed = true;

            if (!_resultsReader.IsClosed)
                _resultsReader.Close();
        }

        public override int Depth
        {
            get { return _resultsReader.Depth; }
        }

        public override int FieldCount
        {
            get { return _resultsReader.FieldCount; }
        }

        public override bool GetBoolean(int ordinal)
        {
            return _resultsReader.GetBoolean(ordinal);
        }

        public override byte GetByte(int ordinal)
        {
            return _resultsReader.GetByte(ordinal);
        }

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            return _resultsReader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        public override char GetChar(int ordinal)
        {
            if (this.IsDBNull(ordinal))
                throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

            return _resultsReader.GetChar(ordinal);
        }

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            return _resultsReader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        public override string GetDataTypeName(int ordinal)
        {
            return _resultsReader.GetDataTypeName(ordinal);
        }

        public override DateTime GetDateTime(int ordinal)
        {
            if (this.IsDBNull(ordinal))
                throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

            return _resultsReader.GetDateTime(ordinal);
        }

        public override decimal GetDecimal(int ordinal)
        {
            if (this.IsDBNull(ordinal))
                throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

            return _resultsReader.GetDecimal(ordinal);
        }

        public override double GetDouble(int ordinal)
        {
            if (this.IsDBNull(ordinal))
                throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

            return _resultsReader.GetDouble(ordinal);
        }

        public override System.Collections.IEnumerator GetEnumerator()
        {
            return _resultsReader.GetEnumerator();
        }

        public override Type GetFieldType(int ordinal)
        {
            return _resultsReader.GetFieldType(ordinal);
        }

        public override float GetFloat(int ordinal)
        {
            if (this.IsDBNull(ordinal))
                throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

            return _resultsReader.GetFloat(ordinal);
        }

        public override Guid GetGuid(int ordinal)
        {
            if (this.IsDBNull(ordinal))
                throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

            return _resultsReader.GetGuid(ordinal);
        }

        public override short GetInt16(int ordinal)
        {
            if (this.IsDBNull(ordinal))
                throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

            return _resultsReader.GetInt16(ordinal);
        }

        public override int GetInt32(int ordinal)
        {
            if (this.IsDBNull(ordinal))
                throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

            return _resultsReader.GetInt32(ordinal);
        }

        public override long GetInt64(int ordinal)
        {
            if (this.IsDBNull(ordinal))
                throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

            return _resultsReader.GetInt64(ordinal);
        }

        public override string GetName(int ordinal)
        {
            return _resultsReader.GetName(ordinal);
        }

        public override int GetOrdinal(string name)
        {
            return _resultsReader.GetOrdinal(name);
        }

        public override DataTable GetSchemaTable()
        {
            return _resultsReader.GetSchemaTable();
        }

        public override string GetString(int ordinal)
        {
            if (IsDBNull(ordinal))
                return null;

            return _resultsReader.GetString(ordinal);
        }

        public T[] GetArray<T>(int ordinal)
        {
            if (IsDBNull(ordinal))
                return null;

            return (T[])_resultsReader[ordinal];
        }

        public override object GetValue(int ordinal)
        {
            return _resultsReader.GetValue(ordinal);
        }

        public override int GetValues(object[] values)
        {
            return _resultsReader.GetValues(values);
        }

        public override bool HasRows
        {
            get { return _resultsReader.HasRows; }
        }

        public override bool IsClosed
        {
            get { return _closed; }
        }

        public override bool IsDBNull(int ordinal)
        {
            return _resultsReader.IsDBNull(ordinal);
        }

        public override bool NextResult()
        {
            return _resultsReader.NextResult();
        }

        public override bool Read()
        {
            return _resultsReader.Read();
        }

        public override int RecordsAffected
        {
            get { return _resultsReader.RecordsAffected; }
        }

        public override object this[string name]
        {
            get { return _resultsReader[name]; }
        }

        public override object this[int ordinal]
        {
            get { return _resultsReader[ordinal]; }
        }

        #endregion

        private DbDataReader LoadData(XmlDictionaryReader reader)
        {
            DataTable dataTable = new DataTable();
            var dataReader = new InformationServiceResultsReader(reader);

            ResultsDataAdapter adapter = new ResultsDataAdapter();
            adapter.FillData(dataTable, dataReader);

            TotalRows = dataReader.TotalRows;
            QueryPlan = dataReader.QueryPlan;
            _errors = dataReader.Errors;

            return dataTable.CreateDataReader();
        }

        public long? TotalRows { get; private set; }
        public XmlDocument QueryPlan { get; private set; }

        public List<ErrorMessage> Errors
        {
            get
            {
                if (_errors != null)
                    return _errors;

                var reader = _resultsReader as InformationServiceResultsReader;

                if (reader != null)
                {
                    if (reader.Errors != null)
                        return reader.Errors;
                }
                return null;
            }
        }

        private class InformationServiceResultsReader : DbDataReader
        {
            private enum ParserState
            {
                Start,
                Root,
                Template,
                ResultSet,
                PropertyTemplate,
                Data,
                Row,
                Column,
                ArrayColumn,
                ArrayItem,
                Errors,
                Error
            }

            private XmlDictionaryReader reader;
            private ParserState state;
            private List<ColumnInfo> columns;
            private int currentColumnOrdinal;
            private bool currentColumnDBNull;
            private bool currentColumnEncoded;
            private string currentColumnEncodingType;
            private object[] values;
            private List<object> arrayColumnValues = new List<object>();
            private bool closed = false;
            private DataTable schemaTable = null;
            private bool hasRows = false;
            private static readonly XmlSerializer serializer = new XmlSerializer(typeof(ErrorMessage));

            internal const string DBNullNamespace = "http://www.w3.org/2001/XMLSchema-instance";
            internal const string DBNullPrefix = "xsi";
            internal const string DBNullAttribute = "nil";
            internal const string DBNullValue = "true";
            internal const string DBBase64 = "Base64";

            internal const string IsEncodedAttribute = "isEncoded";
            internal const string EncodingTypeAttribute = "encodingType";

            public List<ErrorMessage> Errors { get; private set; }

            internal InformationServiceResultsReader(XmlDictionaryReader reader)
            {
                if (reader == null)
                    throw new ArgumentNullException("reader");

                this.reader = reader;

                ReadMetadata();

                this.values = new object[this.columns.Count];
            }

            public override void Close()
            {
                if (this.closed)
                    throw new InvalidOperationException("already closed");

                this.closed = true;
            }

            public override int Depth
            {
                get { return 0; }
            }

            public override int FieldCount
            {
                get { return this.columns.Count; }
            }

            public override bool GetBoolean(int ordinal)
            {
                if (this.IsDBNull(ordinal))
                    throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

                return (bool)this.values[ordinal];
            }

            public override byte GetByte(int ordinal)
            {
                if (this.IsDBNull(ordinal))
                    throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

                return (byte)this.values[ordinal];
            }

            public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
            {
                throw new NotSupportedException("GetBytes");
            }

            public override char GetChar(int ordinal)
            {
                if (this.IsDBNull(ordinal))
                    throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

                return (char)this.values[ordinal];
            }

            public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
            {
                throw new NotSupportedException("GetChars");
            }

            public override string GetDataTypeName(int ordinal)
            {
                return this.columns[ordinal].TypeName;
            }

            public override DateTime GetDateTime(int ordinal)
            {
                if (this.IsDBNull(ordinal))
                    throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

                return (DateTime)this.values[ordinal];
            }

            public override decimal GetDecimal(int ordinal)
            {
                if (this.IsDBNull(ordinal))
                    throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

                return (Decimal)this.values[ordinal];
            }

            public override double GetDouble(int ordinal)
            {
                if (this.IsDBNull(ordinal))
                    throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

                return (Double)this.values[ordinal];
            }

            public override System.Collections.IEnumerator GetEnumerator()
            {
                throw new NotSupportedException("GetEnumerator");
            }

            public override Type GetFieldType(int ordinal)
            {
                return this.columns[ordinal].Type;
            }

            public override float GetFloat(int ordinal)
            {
                if (this.IsDBNull(ordinal))
                    throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

                return (float)this.values[ordinal];
            }

            public override Guid GetGuid(int ordinal)
            {
                if (this.IsDBNull(ordinal))
                    throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

                return (Guid)this.values[ordinal];
            }

            public override short GetInt16(int ordinal)
            {
                if (this.IsDBNull(ordinal))
                    throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

                return (Int16)this.values[ordinal];
            }

            public override int GetInt32(int ordinal)
            {
                if (this.IsDBNull(ordinal))
                    throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

                return (Int32)this.values[ordinal];
            }

            public override long GetInt64(int ordinal)
            {
                if (this.IsDBNull(ordinal))
                    throw new SqlNullValueException(string.Format("Column contains {0} DBNull", ordinal));

                return (Int64)this.values[ordinal];
            }

            public override string GetName(int ordinal)
            {
                return this.columns[ordinal].Name;
            }

            public override int GetOrdinal(string name)
            {
                for (int i = 0; i < this.columns.Count; ++i)
                {
                    if (this.columns[i].Name.Equals(name, StringComparison.Ordinal))
                        return i;
                }

                for (int i = 0; i < this.columns.Count; ++i)
                {
                    if (this.columns[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                        return i;
                }

                throw new IndexOutOfRangeException("The name specified is not a valid column name");
            }

            public override System.Data.DataTable GetSchemaTable()
            {
                if (this.schemaTable == null)
                    BuildSchemaTable();
                return this.schemaTable;
            }

            public override string GetString(int ordinal)
            {
                if (this.IsDBNull(ordinal))
                    return null;

                return (string)this.values[ordinal];
            }

            public override object GetValue(int ordinal)
            {
                return this.values[ordinal];
            }

            public override int GetValues(object[] values)
            {
                this.values.CopyTo(values, 0);
                return this.values.Length;
            }

            public override bool HasRows
            {
                get
                {
                    if (this.closed)
                        throw new InvalidOperationException("DataReader is closed");

                    return this.hasRows;
                }
            }

            public override bool IsClosed
            {
                get { return this.closed; }
            }

            public override bool IsDBNull(int ordinal)
            {
                return (this.values[ordinal] == DBNull.Value);
            }

            public override bool NextResult()
            {
                return false;
            }

            public override bool Read()
            {
                if (this.closed)
                    throw new InvalidOperationException("DataReader is closed");

                return ReadNextEntity();
            }

            public override int RecordsAffected
            {
                get { return -1; }
            }

            public long? TotalRows { get; private set; }

            public override object this[string name]
            {
                get { return this.values[GetOrdinal(name)]; }
            }

            public override object this[int ordinal]
            {
                get { return this.values[ordinal]; }
            }

            public XmlDocument QueryPlan { get; private set; }

            public void ReadMetadata()
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch (this.state)
                            {
                                case ParserState.Start:
                                    // Assumption:
                                    // - skip the soap response tags
                                    if ((reader.LocalName == "QueryXmlResponse") ||
                                        (reader.LocalName == "QueryXmlResult"))
                                        continue;

                                    if (string.CompareOrdinal(reader.LocalName, "queryResult") == 0)
                                        this.state = ParserState.Root;
                                    else
                                        throw new InvalidOperationException(
                                            "Expecting <queryResult> element but found " + reader.LocalName);
                                    break;

                                case ParserState.Root:
                                    if (string.CompareOrdinal(reader.LocalName, "queryPlan") == 0)
                                    {
                                        this.QueryPlan = new XmlDocument();
                                        QueryPlan.Load(reader.ReadSubtree());
                                    }
                                    else if (string.CompareOrdinal(reader.LocalName, "template") == 0)
                                    {
                                        this.state = ParserState.Template;
                                    }
                                    else if (string.CompareOrdinal(reader.LocalName, "data") == 0)
                                    {
                                        this.state = ParserState.Data;
                                        this.hasRows = true;
                                        string totalRowsAttr = reader.GetAttribute("totalRows");
                                        if (!string.IsNullOrEmpty(totalRowsAttr))
                                            TotalRows = Convert.ToInt64(totalRowsAttr);

                                        return;
                                    }
                                    else
                                    {
                                        throw new InvalidOperationException("Unexepected element " + reader.LocalName);
                                    }
                                    break;

                                case ParserState.Template:
                                    if (string.CompareOrdinal(reader.LocalName, "resultset") == 0)
                                    {
                                        if (this.columns != null)
                                            throw new InvalidOperationException("Only one resultset is supported");

                                        this.state = ParserState.ResultSet;
                                    }
                                    break;

                                case ParserState.ResultSet:
                                    if (string.CompareOrdinal(reader.LocalName, "column") != 0)
                                        throw new InvalidOperationException(
                                            "Only <column> elements are expected as children of a <resultset> element");

                                    if (this.columns == null)
                                    {
                                        this.columns = new List<ColumnInfo>();
                                    }

                                    ColumnInfo columnInfo = new ColumnInfo(reader["name"], reader["type"],
                                        Int32.Parse(reader["ordinal"]));

                                    this.columns.Add(columnInfo);

                                    // Sometime empty elements come with an end element, adjust the statemachine state accordingly
                                    if (!reader.IsEmptyElement)
                                        this.state = ParserState.PropertyTemplate;
                                    break;

                                default:
                                    throw new InvalidOperationException("Unexpected state " + this.state);
                            }
                            break;

                        case XmlNodeType.EndElement:
                            switch (this.state)
                            {
                                case ParserState.Root:
                                    if (string.CompareOrdinal(reader.LocalName, "queryResult") != 0)
                                        throw new InvalidOperationException(
                                            string.Format("Not expecting element {0} while in state {1}",
                                                reader.LocalName, this.state));
                                    return;

                                case ParserState.Template:
                                    ValidateEndElement(reader.LocalName, "template", ParserState.Root);
                                    break;

                                case ParserState.ResultSet:
                                    ValidateEndElement(reader.LocalName, "resultset", ParserState.Template);
                                    break;

                                case ParserState.PropertyTemplate:
                                    ValidateEndElement(reader.LocalName, "column", ParserState.ResultSet);
                                    break;

                                default:
                                    throw new InvalidOperationException(
                                        string.Format("Not expecting element {0} while in state {1}", reader.LocalName,
                                            this.state));
                            }
                            break;
                    }
                }

                throw new InvalidOperationException("Malformed Xml result");
            }

            private void ReadErrors(XmlReader reader)
            {
                if (Errors == null)
                    Errors = new List<ErrorMessage>();

                ErrorMessage message = (ErrorMessage)serializer.Deserialize(reader.ReadSubtree());

                if (message != null)
                    Errors.Add(message);
            }

            private bool ReadNextEntity()
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (this.state)
                        {
                            case ParserState.Data:
                                BeginRootEntity(reader);
                                break;

                            case ParserState.Row:
                                BeginColumn(reader);
                                break;

                            case ParserState.ArrayColumn:
                                BeginArrayItem(reader);
                                break;

                            case ParserState.Errors:
                                if (reader.LocalName == "errors")
                                {
                                    this.state = ParserState.Error;
                                }
                                break;

                            case ParserState.Error:
                                ReadErrors(reader);
                                break;

                            case ParserState.Root:
                                {
                                    if (reader.LocalName == "errors")
                                    {
                                        this.state = ParserState.Error;
                                    }
                                    else
                                        throw new InvalidOperationException("Unexpected state " + this.state);

                                    break;
                                }

                            default:
                                throw new InvalidOperationException("Unexpected state " + this.state);
                        }
                    }

                    if (reader.NodeType == XmlNodeType.EndElement ||
                        (reader.NodeType == XmlNodeType.Element && reader.IsEmptyElement))
                    {
                        switch (this.state)
                        {
                            case ParserState.Error:
                                if (reader.LocalName == "errors")
                                    return false;
                                break;

                            case ParserState.Errors:
                                return false;

                            case ParserState.Root:
                                if (hasRows)
                                    ValidateEndElement(reader.LocalName, "queryResult", ParserState.Errors);
                                else
                                    return false;
                                break;

                            case ParserState.Data:
                                ValidateEndElement(reader.LocalName, "data", ParserState.Root);
                                break;

                            case ParserState.Column:
                                EndColumn(reader);
                                break;

                            case ParserState.ArrayItem:
                                ValidateEndElement(reader.LocalName, "item", ParserState.ArrayColumn);
                                break;

                            case ParserState.ArrayColumn:
                                EndArrayColumn();
                                break;

                            case ParserState.Row:
                                ValidateEndElement(reader.LocalName, "row", ParserState.Data);
                                EndRootEntity();
                                return true;

                            default:
                                throw new InvalidOperationException(
                                    string.Format("Not expecting element {0} while in state {1}", reader.LocalName,
                                        this.state));
                        }
                    }

                    if (reader.NodeType == XmlNodeType.Text || reader.NodeType == XmlNodeType.Whitespace)
                    {
                        if (!this.currentColumnDBNull)
                        {
                            switch (this.state)
                            {
                                case ParserState.Column:
                                    ProcessColumnValue(reader);
                                    break;

                                case ParserState.ArrayItem:
                                    ProcessArrayItem(reader);
                                    break;

                                default:
                                    if (reader.NodeType == XmlNodeType.Whitespace)
                                        break;
                                    throw new InvalidOperationException("Not expecting element content for state " +
                                                                        this.state);
                            }
                        }
                    }
                }

                return false;
            }

            private void ValidateEndElement(string elementName, string expectedName, ParserState targetState)
            {
                if (string.CompareOrdinal(elementName, expectedName) != 0)
                    throw new InvalidOperationException(string.Format("Expecting </{0}> but encountered {1}",
                        expectedName, elementName));

                this.state = targetState;
            }

            private void BeginRootEntity(XmlReader reader)
            {
                // Assumptions: 
                // - expecting top level elements to be entities of the type expected by the query
                // - name must match exactly between the XML element and the type name
                // - not handling simple scalar results at this point, only classes/structs with properties
                // - not handling fields
                if (String.CompareOrdinal("row", reader.LocalName) != 0)
                    throw new InvalidOperationException("Expecting <row> element but found " + reader.LocalName);

                this.state = ParserState.Row;

                for (int i = 0; i < this.values.Length; ++i)
                    this.values[i] = DBNull.Value;
            }

            private void EndRootEntity()
            {
                this.state = ParserState.Data;
            }

            private void BeginColumn(XmlReader reader)
            {
                this.currentColumnOrdinal = Parse(reader.LocalName, 1, reader.LocalName.Length);

                string dbNullAtt = reader.GetAttribute(DBNullAttribute, DBNullNamespace);
                this.currentColumnDBNull = (!string.IsNullOrEmpty(dbNullAtt) && dbNullAtt.CompareTo(DBNullValue) == 0);

                bool.TryParse(reader.GetAttribute(IsEncodedAttribute), out this.currentColumnEncoded);
                this.currentColumnEncodingType = this.currentColumnEncoded ? reader.GetAttribute(EncodingTypeAttribute) : string.Empty;

                ColumnInfo columnInfo = this.columns[this.currentColumnOrdinal];
                if (columnInfo.IsArray)
                    this.state = ParserState.ArrayColumn;
                else
                {
                    this.state = ParserState.Column;

                    if (columnInfo.EntityPropertyType == EntityPropertyType.String && !currentColumnDBNull)
                        this.values[this.currentColumnOrdinal] = string.Empty;
                }
            }

            private static int Parse(string str, int start, int end)
            {
                // parse input
                int result = 0;
                for (; start < end; ++start)
                {
                    result = unchecked(10 * result + (str[start] - '0'));
                }

                return result;
            }

            private void BeginArrayItem(XmlDictionaryReader reader)
            {
                if (String.CompareOrdinal("item", reader.LocalName) != 0)
                    throw new InvalidOperationException("Expecting <item> element but found " + reader.LocalName);

                this.state = ParserState.ArrayItem;
            }

            private void ProcessArrayItem(XmlDictionaryReader reader)
            {
                ColumnInfo columnInfo = this.columns[this.currentColumnOrdinal];
                this.arrayColumnValues.Add(
                    DeserializeScalarValue(reader.Value, columnInfo.EntityPropertyType, columnInfo.Type.GetElementType()));
            }

            private void ProcessColumnValue(XmlDictionaryReader reader)
            {
                ColumnInfo columnInfo = this.columns[this.currentColumnOrdinal];

                object value = DeserializeScalarValue(reader.Value, columnInfo.EntityPropertyType, columnInfo.Type);
                if (columnInfo.EntityPropertyType == EntityPropertyType.String)
                {
                    value = this.values[this.currentColumnOrdinal] + value.ToString();
                }

                this.values[this.currentColumnOrdinal] = value;
            }

            private object DeserializeScalarValue(string value, EntityPropertyType columnType, Type targetType)
            {
                switch (columnType)
                {
                    case EntityPropertyType.String:
                        if (this.currentColumnEncoded)
                        {
                            if (DBBase64.Equals(this.currentColumnEncodingType, StringComparison.OrdinalIgnoreCase))
                                value = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(value));
                        }
                        return Convert.ChangeType(value, targetType, CultureInfo.InvariantCulture);
                    case EntityPropertyType.Boolean:
                    case EntityPropertyType.Byte:
                    case EntityPropertyType.Char:
                    case EntityPropertyType.Decimal:
                    case EntityPropertyType.Double:
                    case EntityPropertyType.Int16:
                    case EntityPropertyType.Int32:
                    case EntityPropertyType.Int64:
                    case EntityPropertyType.Single:
                    case EntityPropertyType.Type:
                    case EntityPropertyType.Uri:
                        return Convert.ChangeType(value, targetType, CultureInfo.InvariantCulture);

                    case EntityPropertyType.Blob:
                        return Convert.FromBase64String(value);

                    case EntityPropertyType.Guid:
                        return new Guid(value);

                    case EntityPropertyType.DateTime:
                        return DateTime.ParseExact(value, "o", CultureInfo.InvariantCulture,
                            DateTimeStyles.AdjustToUniversal);

                    case EntityPropertyType.Null:
                        return value;

                    default:
                        throw new InvalidOperationException(string.Format("Unsupported property type {0}", columnType));
                }
            }

            private void EndColumn(XmlReader reader)
            {
                if (string.CompareOrdinal(reader.LocalName, this.columns[this.currentColumnOrdinal].ElementName) != 0)
                    throw new InvalidOperationException(string.Format("Expecting </{0}> but encountered {1}",
                        this.columns[this.currentColumnOrdinal].ElementName, reader.LocalName));

                this.currentColumnOrdinal = -1;

                this.state = ParserState.Row;
            }

            private void EndArrayColumn()
            {
                if (string.CompareOrdinal(reader.LocalName, this.columns[this.currentColumnOrdinal].ElementName) != 0)
                    throw new InvalidOperationException(string.Format("Expecting </{0}> but encountered {1}",
                        this.columns[this.currentColumnOrdinal].ElementName, reader.LocalName));

                ColumnInfo column = this.columns[this.currentColumnOrdinal];
                Array values = Array.CreateInstance(column.Type.GetElementType(), this.arrayColumnValues.Count);
                for (int i = 0; i < values.Length; i++)
                    values.SetValue(this.arrayColumnValues[i], i);

                this.values[this.currentColumnOrdinal] = values;

                this.arrayColumnValues.Clear();

                this.currentColumnOrdinal = -1;

                this.state = ParserState.Row;
            }

            private void BuildSchemaTable()
            {
                this.schemaTable = new DataTable("SchemaTable");
                this.schemaTable.MinimumCapacity = this.columns.Count;

                DataColumn nameColumn = new DataColumn("ColumnName", typeof(string));
                this.schemaTable.Columns.Add(nameColumn);
                DataColumn ordinalColumn = new DataColumn("ColumnOrdinal", typeof(int));
                this.schemaTable.Columns.Add(ordinalColumn);
                DataColumn typeColumn = new DataColumn("ColumnType", typeof(Type));
                this.schemaTable.Columns.Add(typeColumn);

                foreach (ColumnInfo columnInfo in this.columns)
                {
                    DataRow row = this.schemaTable.NewRow();
                    row["ColumnName"] = columnInfo.Name;
                    row["ColumnOrdinal"] = columnInfo.Ordinal;
                    row["ColumnType"] = columnInfo.Type;

                    this.schemaTable.Rows.Add(row);
                }
            }

            private class ColumnInfo : EntityPropertyInfo
            {
                private readonly int ordinal;
                private readonly string elementName;

                public ColumnInfo(string name, string typeName, int ordinal)
                    : base(name, typeName)
                {
                    this.ordinal = ordinal;
                    this.elementName = "c" + ordinal.ToString(System.Globalization.CultureInfo.InvariantCulture);
                }

                public int Ordinal
                {
                    get { return this.ordinal; }
                }

                public string ElementName
                {
                    get { return this.elementName; }
                }
            }
        }

        private class ResultsDataAdapter : DbDataAdapter
        {
            public int FillData(DataTable dataTable, IDataReader dataReader)
            {
                return base.Fill(dataTable, dataReader);
            }
        }
    }
}
