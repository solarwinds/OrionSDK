
using System;
using System.Xml;
using System.ServiceModel.Description;
using System.Collections.Generic;

namespace SolarWinds.InformationService.Contract2.Bindings
{
    public class GZipMessageEncodingBindingElementImporter : IPolicyImportExtension
    {
        public GZipMessageEncodingBindingElementImporter()
        {
        }

        void IPolicyImportExtension.ImportPolicy(MetadataImporter importer, PolicyConversionContext context)
        {
            if (importer == null)
            {
                throw new ArgumentNullException("importer");
            }

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            ICollection<XmlElement> assertions = context.GetBindingAssertions();
            foreach (XmlElement assertion in assertions)
            {
                if ((assertion.NamespaceURI == GZipMessageEncodingPolicyConstants.GZipEncodingNamespace) &&
                    (assertion.LocalName == GZipMessageEncodingPolicyConstants.GZipEncodingName)
                    )
                {
                    assertions.Remove(assertion);
                    context.BindingElements.Add(new GZipMessageEncodingBindingElement());
                    break;
                }
            }
        }
    }
}

