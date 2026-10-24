using System;
using System.ServiceModel;

namespace SolarWinds.InformationService.Contract2
{
    public class BearerTokenCredentials : ServiceCredentials
    {
        private readonly Func<string> _tokenProvider;

        public BearerTokenCredentials(Func<string> tokenProvider)
        {
            _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
        }

        public override CredentialType CredentialType => CredentialType.Bearer;

        public override void ApplyTo(ChannelFactory channelFactory)
        {
            // Strip DnsEndpointIdentity so WCF does not attempt Kerberos/SPNEGO
            // identity verification against the server certificate CN.
            channelFactory.Endpoint.Address = new EndpointAddress(channelFactory.Endpoint.Address.Uri);

            // Inject the Bearer token via a message inspector — do NOT set
            // channelFactory.Credentials.UserName, which would cause WCF to require
            // a username and send a Basic Authorization header on top of ours.
            channelFactory.Endpoint.EndpointBehaviors.Add(new BearerTokenBehavior(_tokenProvider));
        }
    }
}
