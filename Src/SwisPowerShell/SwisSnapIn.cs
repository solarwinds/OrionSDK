using System.ComponentModel;
using System.Management.Automation;

namespace SwisPowerShell
{
    [RunInstaller(true)]
    public class SwisSnapIn : PSSnapIn
    {
        public override string Description
        {
            get { return "PowerShell Snap-in for the SolarWinds Information Service"; }
        }

        public override string Name
        {
            get { return "SwisSnapIn"; }
        }

        public override string Vendor
        {
            get { return "SolarWinds, Inc."; }
        }
    }
}
