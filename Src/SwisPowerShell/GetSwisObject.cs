using System.Collections.Generic;
using System.Management.Automation;

namespace SwisPowerShell
{
    [Cmdlet(VerbsCommon.Get, "SwisObject")]
    public class GetSwisObject : BaseSwisCmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string Uri { get; set; }

        protected override void InternalProcessRecord()
        {
            CheckConnection();
            Dictionary<string, object> obj = null;
            DoWithExceptionReporting(() => obj = SwisConnection.Read(Uri));
            if (obj != null)
                WriteObject(obj);
        }
    }
}
