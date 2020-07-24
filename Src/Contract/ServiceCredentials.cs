using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace SolarWinds.InformationService.Contract2
{
    [DataContract(Namespace = "http://schema.solarwinds.com/2007/08/IS")]
    public abstract class ServiceCredentials : IDisposable
    {
        private readonly static EmptyCredentials _emptyCredentials = new EmptyCredentials();

        #region EmptyCredentials class

        private class EmptyCredentials : ServiceCredentials
        {
            public override CredentialType CredentialType
            {
                get { return CredentialType.None; }
            }

            public override void ApplyTo(ChannelFactory channelFactory)
            {
            }
        }

        #endregion

        public static ServiceCredentials None
        {
            get { return _emptyCredentials; }
        }

        public abstract CredentialType CredentialType { get; }

        public abstract void ApplyTo(ChannelFactory channelFactory);

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ServiceCredentials()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        #endregion
    }
}
