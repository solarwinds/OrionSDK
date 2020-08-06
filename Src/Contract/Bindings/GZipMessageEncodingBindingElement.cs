
using System;
using System.Xml;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace SolarWinds.InformationService.Contract2.Bindings
{
    //This is the binding element that, when plugged into a custom binding, will enable the GZip encoder
    public sealed class GZipMessageEncodingBindingElement
                        : MessageEncodingBindingElement //BindingElement
                        , IPolicyExportExtension
    {

        //We will use an inner binding element to store information required for the inner encoder

        //By default, use the default text encoder as the inner encoder
        public GZipMessageEncodingBindingElement()
            : this(new TextMessageEncodingBindingElement())
        {
            var textMessageEncodingBindingElement = InnerMessageEncodingBindingElement as TextMessageEncodingBindingElement;
            ReaderQuotaHelper.SetReaderQuotas(textMessageEncodingBindingElement.ReaderQuotas);
        }

        public GZipMessageEncodingBindingElement(MessageEncodingBindingElement messageEncoderBindingElement)
        {
            InnerMessageEncodingBindingElement = messageEncoderBindingElement;
        }

        public MessageEncodingBindingElement InnerMessageEncodingBindingElement { get; set; }

        //Main entry point into the encoder binding element. Called by WCF to get the factory that will create the
        //message encoder
        public override MessageEncoderFactory CreateMessageEncoderFactory()
        {
            return new GZipMessageEncoderFactory(InnerMessageEncodingBindingElement.CreateMessageEncoderFactory());
        }

        public override MessageVersion MessageVersion
        {
            get { return InnerMessageEncodingBindingElement.MessageVersion; }
            set { InnerMessageEncodingBindingElement.MessageVersion = value; }
        }

        public override BindingElement Clone()
        {
            return new GZipMessageEncodingBindingElement(InnerMessageEncodingBindingElement);
        }

        public override T GetProperty<T>(BindingContext context)
        {
            if (typeof(T) == typeof(XmlDictionaryReaderQuotas))
            {
                return InnerMessageEncodingBindingElement.GetProperty<T>(context);
            }
            else
            {
                return base.GetProperty<T>(context);
            }
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.BindingParameters.Add(this);
            return context.BuildInnerChannelFactory<TChannel>();
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.BindingParameters.Add(this);
            return context.BuildInnerChannelListener<TChannel>();
        }

        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.BindingParameters.Add(this);
            return context.CanBuildInnerChannelListener<TChannel>();
        }

        void IPolicyExportExtension.ExportPolicy(MetadataExporter exporter, PolicyConversionContext policyContext)
        {
            if (policyContext == null)
            {
                throw new ArgumentNullException("policyContext");
            }
            XmlDocument document = new XmlDocument();
            policyContext.GetBindingAssertions().Add(document.CreateElement(
                GZipMessageEncodingPolicyConstants.GZipEncodingPrefix,
                GZipMessageEncodingPolicyConstants.GZipEncodingName,
                GZipMessageEncodingPolicyConstants.GZipEncodingNamespace));
        }
    }
}
