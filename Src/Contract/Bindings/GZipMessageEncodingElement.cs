using System;
using System.Configuration;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;

namespace SolarWinds.InformationService.Contract2.Bindings
{
    //This class is necessary to be able to plug in the GZip encoder binding element through
    //a configuration file
    public class GZipMessageEncodingElement : BindingElementExtensionElement
    {
        public GZipMessageEncodingElement()
        {
        }

        //Called by the WCF to discover the type of binding element this config section enables
        public override Type BindingElementType
        {
            get { return typeof(GZipMessageEncodingBindingElement); }
        }

        //The only property we need to configure for our binding element is the type of
        //inner encoder to use. Here, we support text and binary.
        [ConfigurationProperty("innerMessageEncoding", DefaultValue = "textMessageEncoding")]
        public string InnerMessageEncoding
        {
            get { return (string)base["innerMessageEncoding"]; }
            set { base["innerMessageEncoding"] = value; }
        }

        //Called by the WCF to apply the configuration settings (the property above) to the binding element
        public override void ApplyConfiguration(BindingElement bindingElement)
        {
            GZipMessageEncodingBindingElement binding = (GZipMessageEncodingBindingElement)bindingElement;
            PropertyInformationCollection propertyInfo = ElementInformation.Properties;
            if (propertyInfo["innerMessageEncoding"].ValueOrigin != PropertyValueOrigin.Default)
            {
                switch (InnerMessageEncoding)
                {
                    case "textMessageEncoding":
                        var innerMessageEncodingBindingElement = new TextMessageEncodingBindingElement();
                        ReaderQuotaHelper.SetReaderQuotas(innerMessageEncodingBindingElement.ReaderQuotas);
                        binding.InnerMessageEncodingBindingElement = innerMessageEncodingBindingElement;
                        break;

                    case "binaryMessageEncoding":
                        var binaryMessageEncodingBindingElement = new BinaryMessageEncodingBindingElement();
                        ReaderQuotaHelper.SetReaderQuotas(binaryMessageEncodingBindingElement.ReaderQuotas);
                        binding.InnerMessageEncodingBindingElement = binaryMessageEncodingBindingElement;
                        break;
                }
            }
        }

        //Called by the WCF to create the binding element
        protected override BindingElement CreateBindingElement()
        {
            GZipMessageEncodingBindingElement bindingElement = new GZipMessageEncodingBindingElement();
            ApplyConfiguration(bindingElement);
            return bindingElement;
        }
    }
}