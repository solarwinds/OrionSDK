using System;
using Microsoft.Extensions.Logging;

namespace SolarWinds.InformationService.Contract2
{
    public class InformationServiceContext : IDisposable
    {
        private bool disposed = false;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IInformationService service = null;

        public InformationServiceContext(ILoggerFactory loggerFactory, IInformationService service)
        {
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            this.service = service;
        }

        /// <summary>
        /// Creates query against SWIS.
        /// If <typeparamref name="T"/> has method Add(string,object) you can use <see cref="IEntityPropertySetter"/> interface to improve performance.
        /// </summary>
        /// <typeparam name="T">type of returned entity</typeparam>
        /// <param name="queryString">query in SWQL</param>
        /// <returns>result of query execution</returns>
        public InformationServiceQuery<T> CreateQuery<T>(string queryString) where T : new()
        {
            if (queryString == null)
                throw new ArgumentNullException(nameof(queryString));
            if (disposed)
                throw new InvalidOperationException("context disposed");

            return new InformationServiceQuery<T>(_loggerFactory.CreateLogger<InformationServiceQuery<T>>(), this, queryString);
        }

        public InfoServiceProxy Proxy { get; private set; } = null;

        public IInformationService Service
        {
            get
            {
                return Proxy ?? service;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Proxy != null)
                    {
                        Proxy.Dispose();
                        Proxy = null;
                    }
                }

                disposed = true;
            }
        }

        #endregion
    }
}
