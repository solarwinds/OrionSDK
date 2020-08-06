using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using SolarWinds.Logging;
using SolarWinds.InformationService.Contract2.PubSub;

namespace SolarWinds.InformationService.Contract2
{
    public class IndicationReporterProxy : IIndicationReporter, IDisposable
    {
        private readonly static Log log = new Log();

        private ChannelFactory<IIndicationReporter> channelFactory;

        private IIndicationReporter reporter;

        /// <summary>
        /// Create reporter from given configuration located in configuration file.
        /// </summary>
        /// <param name="endpointName">Valid endpoint name in actual configuration name.</param>
        public static IndicationReporterProxy CreateFromConfiguration(string endpointName)
        {
            return new IndicationReporterProxy(endpointName);
        }

        /// <summary>
        /// Create reporter from given configuration located in configuration file.
        /// </summary>
        /// <param name="endpointName">Valid endpoint name in configuration.</param>
        private IndicationReporterProxy(string endpointName)
        {
            if (endpointName == null)
            {
                throw new ArgumentNullException("endpointName");
            }

            channelFactory = new ChannelFactory<IIndicationReporter>(endpointName);
        }

        /// <summary>
        /// Create reporter for given Uri and client certificate.
        /// </summary>                
        /// <param name="address">Valid target address of service.</param>
        /// <param name="cert">Valid certificate.</param>
        public static IndicationReporterProxy CreateForCertificate(Uri address, X509Certificate2 cert)
        {
            return new IndicationReporterProxy(address, cert);
        }

        /// <summary>
        /// Create reporter connected via given client certificate.
        /// </summary>
        /// <param name="address">Valid target address of service.</param>
        /// <param name="cert">Valid certificate.</param>
        private IndicationReporterProxy(Uri address, X509Certificate2 cert)
        {
            if (address == null)
            {
                throw new ArgumentNullException("address");
            }

            if (cert == null)
            {
                throw new ArgumentNullException("cert");
            }

            var binding = new NetMsmqBinding(NetMsmqSecurityMode.Message);
            binding.Security.Mode = NetMsmqSecurityMode.Message;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;

            var end = new EndpointAddress(address, EndpointIdentity.CreateX509CertificateIdentity(cert));
            channelFactory = new ChannelFactory<IIndicationReporter>(binding, end);
            channelFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
            channelFactory.Credentials.ClientCertificate.Certificate = cert;

            log.DebugFormat("ChannelFactory created - {0}", address.ToString());
        }

        public IndicationReporterProxy(Uri address)
        {
            if (address == null)
                throw new ArgumentNullException("address");

            NetMsmqBinding binding = new NetMsmqBinding(NetMsmqSecurityMode.None);
            //TODO set security mode, provide other constructors like InfoServiceProxy has

            channelFactory = new ChannelFactory<IIndicationReporter>(binding, new EndpointAddress(address));
            log.DebugFormat("ChannelFactory created - {0}", address.ToString());
        }

        #region IIndicationReporter Members

        public void ReportIndication(string indicationType, PropertyBag indicationProperties, PropertyBag sourceInstanceProperties)
        {
            try
            {
                if (reporter == null)
                {
                    reporter = channelFactory.CreateChannel();
                }

                reporter.ReportIndication(indicationType, indicationProperties, sourceInstanceProperties);
                log.DebugFormat("Indication reported - {0}", indicationType);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Error reporting indication: {0}", ex);
                throw;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            try
            {
                channelFactory.Close();
            }
            catch (TimeoutException)
            {
                channelFactory.Abort();
            }
            catch (CommunicationException)
            {
                channelFactory.Abort();
            }
        }

        #endregion
    }
}
