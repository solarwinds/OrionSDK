using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace SolarWinds.InformationService.InformationServiceClient
{
    public class InformationServiceParameterCollection : DbParameterCollection, IEnumerable<InformationServiceParameter>
    {
        private readonly List<InformationServiceParameter> parameters = new List<InformationServiceParameter>();
        private readonly object syncRoot = new object();

        public override int Add(object value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            if (!(value is InformationServiceParameter))
                throw new InvalidOperationException("value is not InformationServiceParameter");

            parameters.Add((InformationServiceParameter)value);
            return parameters.Count - 1;
        }

        public void AddWithValue(string parameterName, object value)
        {
            parameters.Add(new InformationServiceParameter {ParameterName = parameterName, Value = value});
        }

        public override bool Contains(object value)
        {
            return parameters.Contains(value as InformationServiceParameter);
        }

        public override void Clear()
        {
            parameters.Clear();
        }

        public override int IndexOf(object value)
        {
            return parameters.IndexOf(value as InformationServiceParameter);
        }

        public override void Insert(int index, object value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            if (!(value is InformationServiceParameter))
                throw new InvalidOperationException("value is not InformationServiceParameter");

            parameters.Insert(index, (InformationServiceParameter)value);
        }

        public override void Remove(object value)
        {
            parameters.Remove(value as InformationServiceParameter);
        }

        public override void RemoveAt(int index)
        {
            parameters.RemoveAt(index);
        }

        public override void RemoveAt(string parameterName)
        {
            parameters.RemoveAll(p => p.ParameterName.Equals(parameterName));
        }

        protected override void SetParameter(int index, DbParameter value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            if (!(value is InformationServiceParameter))
                throw new InvalidOperationException("value is not InformationServiceParameter");

            parameters[index] = (InformationServiceParameter)value;
        }

        protected override void SetParameter(string parameterName, DbParameter value)
        {
            SetParameter(IndexOf(parameterName), value);
        }

        public override int Count
        {
            get { return parameters.Count; }
        }

        public override object SyncRoot
        {
            get { return syncRoot; }
        }

        public override bool IsFixedSize
        {
            get { return false; }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override bool IsSynchronized
        {
            get { return false; }
        }

        public override int IndexOf(string parameterName)
        {
            if (parameterName == null)
                throw new ArgumentNullException("parameterName");

            return parameters.FindIndex(p => p.ParameterName.Equals(parameterName));
        }

        IEnumerator<InformationServiceParameter> IEnumerable<InformationServiceParameter>.GetEnumerator()
        {
            return parameters.GetEnumerator();
        }

        public override IEnumerator GetEnumerator()
        {
            return parameters.GetEnumerator();
        }

        protected override DbParameter GetParameter(int index)
        {
            return parameters[index];
        }

        protected override DbParameter GetParameter(string parameterName)
        {
            return parameters.Find(p => p.ParameterName.Equals(parameterName));
        }

        public override bool Contains(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            return parameters.Any(p => p.ParameterName.Equals(value));
        }

        public override void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            
            parameters.CopyTo((InformationServiceParameter[])array, index);
        }

        public override void AddRange(Array values)
        {
            foreach (InformationServiceParameter param in values)
                Add(param);
        }
    }
}
