//---------------------------------------------------------------------
// Author: Harley Green
//
// Description: Cmdlet to get data from Sql Server databases
//
// Creation Date: 2008/8/20
//---------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SwisPowerShell
{
    public class DataReaderIndexer : IIndexedByName
    {
        private readonly IDataReader _reader;
        private readonly string[] _columns;

        public DataReaderIndexer(IDataReader reader, IEnumerable<string> columns)
        {
            _reader = reader;
            _columns = columns.ToArray();
        }

        public bool TryGetValue(string name, out object value, bool ignoreCase)
        {
            int ordinal = Array.FindIndex(_columns,
                s => s.Equals(name, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture));
            if (ordinal > -1)
            {
                value = _reader[ordinal];
                return true;
            }
            value = null;
            return false;
        }
    }
}
