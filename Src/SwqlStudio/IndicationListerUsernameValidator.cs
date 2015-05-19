using System.Diagnostics;
using System.IdentityModel.Selectors;

namespace SwqlStudio
{
    /// <summary>
    /// Right now this class accepts all user authentication
    /// </summary>
    class IndicationListerUsernameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            Trace.TraceInformation("User '{0}' validation for incoming indications.", userName);
        }
    }
}
