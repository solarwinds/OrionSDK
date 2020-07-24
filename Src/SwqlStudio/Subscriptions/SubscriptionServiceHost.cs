using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Security.Cryptography;
using Security.Cryptography.X509Certificates;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.Contract2.PubSub;
using SolarWinds.Logging;

namespace SwqlStudio.Subscriptions
{
    class SubscriptionServiceHost
    {
        private readonly static Log log = new Log();
        private readonly List<ServiceHost> subscriberHosts = new List<ServiceHost>();
        private readonly INotificationSubscriber subscriber;
        private readonly string httpAddress;
        private readonly string netTcpAddress;

        public event Action ListenerOpened;

        public event Action ListenerClosed;

        public SubscriptionServiceHost(INotificationSubscriber subscriber)
        {
            this.subscriber = subscriber;

            var processId = Process.GetCurrentProcess().Id;
            netTcpAddress = string.Format("net.tcp://{0}:17777/SolarWinds/SwqlStudio/{1}", ResolveLocalIPAddress(), processId);

            httpAddress = string.Format("https://{0}:17778/SolarWinds/SwqlStudio/{1}", Utility.GetFqdn(), processId);
        }

        public bool IsListening()
        {
            return subscriberHosts.Any();
        }

        public string GetAddressForBinding(Binding binding)
        {
            if (binding.Scheme.Equals("net.tcp", StringComparison.OrdinalIgnoreCase))
                return netTcpAddress + "/Subscriber";

            if (binding.Scheme.Equals("http", StringComparison.OrdinalIgnoreCase))
                return httpAddress + "/Subscriber";

            throw new ArgumentException($"No address for binding of scheme '{binding.Scheme}'");
        }

        public string GetCredentialTypeForBinding(Binding binding)
        {
            if (binding.Scheme.Equals("http", StringComparison.OrdinalIgnoreCase))
                return "Username";

            return "Certificate";
        }

        public string GetBindingForBinding(Binding binding)
        {
            if (binding.Scheme.Equals("http", StringComparison.OrdinalIgnoreCase))
                return "Soap1_1";

            return "NetTcp";
        }

        /// <summary>
        /// Resolves local system IPv4 Address.
        /// </summary>
        /// <returns>String containing local system's IPv4 Address.</returns>
        private static string ResolveLocalIPAddress()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = hostEntry.AddressList.FirstOrDefault(x => (x.AddressFamily == AddressFamily.InterNetwork))
                                        // In case of unavailable IPv4 try to resolve IPv6
                                        ?? hostEntry.AddressList.FirstOrDefault(x => (x.AddressFamily == AddressFamily.InterNetworkV6));

            if (ipAddress == null)
            {
                throw new InvalidOperationException("Could not resolve local IP Address");
            }

            return ipAddress.ToString();
        }

        public void OpenSubscriber()
        {
            try
            {

                if (IsListening())
                    return;

                log.InfoFormat("Opening subscriber endpoint at {0}", netTcpAddress);

                log.InfoFormat("Opening http subscriber endpoint at {0}", httpAddress);

                NotificationSubscriber notificationSubscriber = new NotificationSubscriber();
                notificationSubscriber.IndicationReceived += OnIndication;

                CngKeyCreationParameters keyCreationParameters = new CngKeyCreationParameters();
                keyCreationParameters.ExportPolicy = CngExportPolicies.AllowExport | CngExportPolicies.AllowPlaintextExport | CngExportPolicies.AllowPlaintextArchiving | CngExportPolicies.AllowArchiving;
                keyCreationParameters.KeyUsage = CngKeyUsages.AllUsages;

                X509CertificateCreationParameters configCreate = new X509CertificateCreationParameters(new X500DistinguishedName("CN=SolarWinds-SwqlStudio"));
                configCreate.EndTime = DateTime.Now.AddYears(1);
                configCreate.StartTime = DateTime.Now;

                using (CngKey cngKey = CngKey.Create(CngAlgorithm2.Rsa))
                {
                    X509Certificate2 certificate = cngKey.CreateSelfSignedCertificate(configCreate);
                    ServiceHost host = new ServiceHost(notificationSubscriber, new Uri(netTcpAddress), new Uri(httpAddress));
                    host.Credentials.ServiceCertificate.Certificate = certificate;
                    // SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectDistinguishedName, "CN=SolarWinds-Orion");
                    host.Open();
                    subscriberHosts.Add(host);
                }

                log.Info("Http Subscriber endpoint opened");
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception opening subscriber host with address {0}.\n{1}", httpAddress, ex);
            }

            foreach (ServiceHost serviceHost in subscriberHosts)
            {
                foreach (ChannelDispatcherBase channelDispatcher in serviceHost.ChannelDispatchers)
                {
                    log.InfoFormat("Listening on {0}", channelDispatcher.Listener.Uri.AbsoluteUri);
                }
            }

            ListenerOpened?.Invoke();
        }

        void OnIndication(string subscriptionId, string indicationType, PropertyBag indicationProperties, PropertyBag sourceInstanceProperties)
        {
            subscriber.OnIndication(subscriptionId, indicationType, indicationProperties, sourceInstanceProperties);
        }

        public void CloseSubscriber()
        {
            using (log.Block())
            {
                subscriberHosts.ForEach(host => host.Close());
                subscriberHosts.Clear();
            }

            ListenerClosed?.Invoke();
        }
    }
}
