using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;

namespace SwisPowerShell
{
    [Cmdlet(VerbsCommon.Set, "SwisObject")]
    public class SetSwisObject : BaseSwisCmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = true, Position = 1)]
        public string Uri { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public Hashtable Properties { get; set; }

        private readonly List<string> uris = new List<string>();

        protected override void InternalProcessRecord()
        {
            uris.Add(Uri);
        }

        protected override void EndProcessing()
        {
            CheckConnection();
            DoWithExceptionReporting(() => SwisConnection.BulkUpdate(uris.ToArray(), PropertyBagFromHashtable(Properties)));
        }
    }
}
