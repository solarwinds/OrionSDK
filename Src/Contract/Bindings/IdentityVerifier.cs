using System.IdentityModel.Policy;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace SolarWinds.InformationService.Contract2.Bindings
{
    class SWIdentityVerifier : IdentityVerifier
    {
        public override bool CheckAccess(EndpointIdentity identity, AuthorizationContext authContext)
        {
            return true;
        }

        public override bool TryGetIdentity(EndpointAddress reference, out EndpointIdentity identity)
        {
            identity = null;
            return true;
        }
    }

}
