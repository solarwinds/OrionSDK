using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Management.Automation;

namespace SwisPowerShell
{
    public class DataReaderObjectFactory : IEnumerable
    {
        private readonly IDataReader _dataReader;

        public DataReaderObjectFactory(IDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public IEnumerator GetEnumerator()
        {
            if (_dataReader.FieldCount == 1)
            {
                while (_dataReader.Read())
                {
                    yield return _dataReader[0];
                }
            }
            else
            {
                int fieldCount = _dataReader.FieldCount;

                var columns = new List<string>();
                for (int i = 0; i < fieldCount; i++)
                {
                    string name = _dataReader.GetName(i);
                    if (string.IsNullOrEmpty(name)) // Workaround for FB258920
                        name = "_Field" + i;

                    columns.Add(name);
                }

                while (_dataReader.Read())
                {
                    var target = new PSObject();
                    for (int i = 0; i < fieldCount; i++)
                    {
                        target.Properties.Add(new PSNoteProperty(columns[i], _dataReader[i]));
                    }
                    yield return target;
                }
            }
        }
    }
}
