using System;
using System.Runtime.Serialization;

namespace SolarWinds.InformationService.Contract2
{
    [Serializable]
    public class OAuthSessionExpiredException : Exception
    {
        public OAuthSessionExpiredException()
            : base("OAuth session expired. Please re-authenticate to continue.")
        {
        }

        protected OAuthSessionExpiredException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
