using System;

namespace SolarWinds.InformationService.Contract2
{
    public class InformationServiceContext : IDisposable
    {
        private bool disposed = false;
        private IInformationService service = null;

        public InformationServiceContext(IInformationService service)
        {
            this.service = service;
        }

        public InformationServiceContext(string endpointName)
        {
            if (endpointName == null)
                throw new ArgumentNullException(nameof(endpointName));
            if (endpointName.Length == 0)
                throw new ArgumentException("endpoint name is empty", nameof(endpointName));

            Proxy = new InfoServiceProxy(endpointName);
            Proxy.Open();
        }

        public InformationServiceContext(string endpointName, string remoteAddress)
        {
            if (endpointName == null)
                throw new ArgumentNullException(nameof(endpointName));
            if (endpointName.Length == 0)
                throw new ArgumentException("endpoint name is empty", nameof(endpointName));
            if (remoteAddress == null)
                throw new ArgumentNullException(nameof(remoteAddress));

            Proxy = new InfoServiceProxy(endpointName, remoteAddress);
            Proxy.Open();
        }

        public InformationServiceContext(string endpointName, ServiceCredentials credentials)
        {
            if (endpointName == null)
                throw new ArgumentNullException(nameof(endpointName));
            if (endpointName.Length == 0)
                throw new ArgumentException("endpoint name is empty", nameof(endpointName));
            if (credentials == null)
                throw new ArgumentNullException(nameof(credentials));

            Proxy = new InfoServiceProxy(endpointName, credentials);
            Proxy.Open();
        }

        public InformationServiceContext(string endpointName, string remoteAddress, ServiceCredentials credentials)
        {
            if (endpointName == null)
                throw new ArgumentNullException(nameof(endpointName));
            if (endpointName.Length == 0)
                throw new ArgumentException("endpoint name is empty", nameof(endpointName));
            if (remoteAddress == null)
                throw new ArgumentNullException(nameof(remoteAddress));
            if (credentials == null)
                throw new ArgumentNullException(nameof(credentials));

            Proxy = new InfoServiceProxy(endpointName, remoteAddress, credentials);
            Proxy.Open();
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

            return new InformationServiceQuery<T>(this, queryString);
        }

        /// <summary>
        /// Creates query against SWIS.
        /// If <typeparamref name="T"/> has method Add(string,object) you can use <see cref="IEntityPropertySetter"/> interface to improve performance.
        /// </summary>
        /// <typeparam name="T">type of returned entity</typeparam>
        /// <param name="queryString">query in SWQL</param>
        /// <param name="parameters">query parameters</param>
        /// <returns>result of query execution</returns>
        public InformationServiceQuery<T> CreateQuery<T>(string queryString, PropertyBag parameters) where T : new()
        {
            if (queryString == null)
                throw new ArgumentNullException(nameof(queryString));
            if (disposed)
                throw new InvalidOperationException("context disposed");

            return new InformationServiceQuery<T>(this, queryString, parameters);
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
