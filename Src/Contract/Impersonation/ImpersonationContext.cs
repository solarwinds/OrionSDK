using System;

namespace SolarWinds.InformationService.Contract2.Impersonation
{
    public class ImpersonationContext : IDisposable
    {
        [ThreadStatic]
        private static ImpersonationContext current;

        private bool active = true;

        public string TargetUsername { get; set; }

        public ImpersonationContext(string targetUsername)
        {
            if (targetUsername == null)
                throw new ArgumentNullException("targetUsername");

            TargetUsername = targetUsername;
            current = this;
        }

        public static ImpersonationContext GetCurrentContext()
        {
            if (current != null && current.active)
                return current;
            else
                return null;
        }

        public void Dispose()
        {
            active = false;
        }
    }
}
