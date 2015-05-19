using System;

namespace SolarWinds.InformationService.Contract2
{
    public class InformationServiceContext : IDisposable
    {
        private bool disposed = false;
        private InfoServiceProxy proxy = null;
        private IInformationService service = null;

        public InformationServiceContext(IInformationService service)
        {
            this.service = service;
        }

        public InformationServiceContext(string endpointName)
        {
            if (endpointName == null)
                throw new ArgumentNullException("endpointName");
            if (endpointName.Length == 0)
                throw new ArgumentException("endpoint name is empty", "endpointName");

            this.proxy = new InfoServiceProxy(endpointName);
            this.proxy.Open();
        }

        public InformationServiceContext(string endpointName, string remoteAddress)
        {
            if (endpointName == null)
                throw new ArgumentNullException("endpointName");
            if (endpointName.Length == 0)
                throw new ArgumentException("endpoint name is empty", "endpointName");
            if (remoteAddress == null)
                throw new ArgumentNullException("remoteAddress");

            this.proxy = new InfoServiceProxy(endpointName, remoteAddress);
            this.proxy.Open();
        }

        public InformationServiceContext(string endpointName, ServiceCredentials credentials)
        {
            if (endpointName == null)
                throw new ArgumentNullException("endpointName");
            if (endpointName.Length == 0)
                throw new ArgumentException("endpoint name is empty", "endpointName");
            if (credentials == null)
                throw new ArgumentNullException("credentials");

            this.proxy = new InfoServiceProxy(endpointName, credentials);
            this.proxy.Open();
        }

        public InformationServiceContext(string endpointName, string remoteAddress, ServiceCredentials credentials)
        {
            if (endpointName == null)
                throw new ArgumentNullException("endpointName");
            if (endpointName.Length == 0)
                throw new ArgumentException("endpoint name is empty", "endpointName");
            if (remoteAddress == null)
                throw new ArgumentNullException("remoteAddress");
            if (credentials == null)
                throw new ArgumentNullException("credentials");

            this.proxy = new InfoServiceProxy(endpointName, remoteAddress, credentials);
            this.proxy.Open();
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
                throw new ArgumentNullException("queryString");
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
                throw new ArgumentNullException("queryString");
            if (disposed)
                throw new InvalidOperationException("context disposed");

            return new InformationServiceQuery<T>(this, queryString, parameters);
        }
        
        public InfoServiceProxy Proxy
        {
            get
            {
                return this.proxy;
            }
        }

        public IInformationService Service
        {
            get
            {
                return this.proxy ?? this.service;
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
                    if (proxy != null)
                    {
                        proxy.Dispose();
                        proxy = null;
                    }
                }

                disposed = true;
            }
        }

        #endregion
    }
}
