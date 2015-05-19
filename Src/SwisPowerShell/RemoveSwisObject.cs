using System.Collections.Generic;
using System.Management.Automation;

namespace SwisPowerShell
{
    [Cmdlet(VerbsCommon.Remove, "SwisObject")]
    public class RemoveSwisObject : BaseSwisCmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = true, Position = 1)]
        public string Uri { get; set; }

        private readonly List<string> uris = new List<string>();

        protected override void InternalProcessRecord()
        {
            uris.Add(Uri);
        }

        protected override void EndProcessing()
        {
            CheckConnection();
            DoWithExceptionReporting(() => SwisConnection.BulkDelete(uris.ToArray()));
        }
    }
}
