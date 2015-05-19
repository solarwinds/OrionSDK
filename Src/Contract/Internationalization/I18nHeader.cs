using System.Runtime.Serialization;

namespace SolarWinds.InformationService.Contract2.Internationalization
{
    [DataContract(Name = Constants.HeaderName, Namespace = Constants.Namespace)]
    class I18nHeader
    {
        [DataMember]
        public string Culture { get; set; }
    }
}
