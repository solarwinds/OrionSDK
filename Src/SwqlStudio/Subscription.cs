using System;
using SolarWinds.InformationService.Contract2;

namespace SwqlStudio
{
    class Subscription : IDisposable
    {
        private const string systemSubscription = "System.Subscription";

        private readonly InfoServiceProxy swis;

        public string SubscriptionUri { get; private set; }

        public Subscription(InfoServiceProxy swis, string endpointAddress, string query, string binding = "NetTcp", string dataFormat = "Xml", CredentialType credentialType = CredentialType.Certificate, string username = null, string password = null)
        {
            this.swis = swis;

            PropertyBag propertyBag = new PropertyBag
                {
                    {"Query", query},
                    {"EndpointAddress", endpointAddress},
                    {"Description", "SWQL Studio"},
                    {"DataFormat", dataFormat},
                    {"CredentialType", credentialType.ToString()}
                };

            if (!string.IsNullOrEmpty(binding))
                propertyBag["Binding"] = binding;

            if (credentialType == CredentialType.Username)
            {
                propertyBag.Add("Username", username);
                propertyBag.Add("Password", password);
            }

            SubscriptionUri = swis.Create(systemSubscription, propertyBag);
        }

        public void Dispose()
        {
            swis.Delete(SubscriptionUri);
        }
    }
}
