using System;
using System.Data;
using System.Data.Common;

namespace SolarWinds.InformationService.InformationServiceClient
{
    public class InformationServiceParameter : DbParameter
    {
        public override string ParameterName { get; set; }
        public override object Value { get; set; }

        public override void ResetDbType()
        {
            throw new NotImplementedException();
        }

        public override DbType DbType
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override ParameterDirection Direction
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override bool IsNullable
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override string SourceColumn
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override DataRowVersion SourceVersion
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override bool SourceColumnNullMapping
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override int Size
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
