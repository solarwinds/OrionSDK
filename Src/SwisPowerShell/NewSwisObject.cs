using System.Collections;
using System.Management.Automation;

namespace SwisPowerShell
{
    [Cmdlet(VerbsCommon.New, "SwisObject")]
    public class NewSwisObject : BaseSwisCmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string EntityType { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public Hashtable Properties { get; set; }

        protected override void InternalProcessRecord()
        {
            CheckConnection();
            string uri = null;
            DoWithExceptionReporting(() => uri = SwisConnection.Create(EntityType, PropertyBagFromHashtable(Properties)));
            if (uri != null)
                WriteObject(uri);
        }
    }
}
