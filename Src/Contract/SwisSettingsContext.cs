using System;

namespace SolarWinds.InformationService.Contract2
{
    public sealed class SwisSettingsContext : IDisposable
    {
        private static readonly TimeSpan DefaultProviderTimeout = TimeSpan.FromSeconds(30);

        [ThreadStatic]
        public static SwisSettingsContext Current;

        public TimeSpan DataProviderTimeout { get; set; }

        public string ApplicationTag { get; set; }

        public bool AppendErrors { get; set; }

        public SwisSettingsContext()
        {
            if (Current != null)
                throw new InvalidOperationException("SwisSettingsContext.Current is already set.");

            DataProviderTimeout = DefaultProviderTimeout;
            Current = this;
        }

        public void Dispose()
        {
            Current = null;
        }
    }
}
