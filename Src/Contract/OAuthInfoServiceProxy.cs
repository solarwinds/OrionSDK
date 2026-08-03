using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace SolarWinds.InformationService.Contract2
{
    public class OAuthInfoServiceProxy : InfoServiceProxy
    {
        private readonly OAuthTokenManager _tokenManager;

        public OAuthInfoServiceProxy(Uri address, Binding binding, OAuthTokenManager tokenManager)
            : base(address, binding, new BearerTokenCredentials(() => tokenManager.GetCurrentToken()))
        {
            _tokenManager = tokenManager ?? throw new ArgumentNullException(nameof(tokenManager));
        }

        private void ReAuthenticate()
        {
            // Task.Run escapes any captured SynchronizationContext (e.g. WinForms message loop)
            // so the async continuations inside AcquireTokenAsync are not posted back to the
            // calling thread, preventing a deadlock when GetResult() is called.
            Task.Run(() => _tokenManager.AcquireTokenAsync(CancellationToken.None)).GetAwaiter().GetResult();
            try { Close(); }
            catch (CommunicationException) { Abort(); }
            Open();
        }

        private T WithReAuth<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (OAuthSessionExpiredException)
            {
                ReAuthenticate();
                return action();
            }
        }

        private void WithReAuth(Action action)
        {
            WithReAuth<int>(() => { action(); return 0; });
        }

        public override Message Query(QueryXmlRequest query)
        {
            return WithReAuth(() => base.Query(query));
        }

        public override XmlElement Invoke(string entity, string verb, params XmlElement[] parameters)
        {
            return WithReAuth(() => base.Invoke(entity, verb, parameters));
        }

        public override string Create(string entityType, PropertyBag properties)
        {
            return WithReAuth(() => base.Create(entityType, properties));
        }

        public override PropertyBag Read(string uri)
        {
            return WithReAuth(() => base.Read(uri));
        }

        public override void Update(string uri, PropertyBag propertiesToUpdate)
        {
            WithReAuth(() => base.Update(uri, propertiesToUpdate));
        }

        public override void BulkUpdate(string[] uris, PropertyBag propertiesToUpdate)
        {
            WithReAuth(() => base.BulkUpdate(uris, propertiesToUpdate));
        }

        public override void Delete(string uri)
        {
            WithReAuth(() => base.Delete(uri));
        }

        public override void BulkDelete(string[] uris)
        {
            WithReAuth(() => base.BulkDelete(uris));
        }
    }
}
