using System;
using System.Runtime.Serialization;

namespace SolarWinds.InformationService.Contract2
{
    [DataContract(Name = Constants.SwisSettingsHeaderName, Namespace = Constants.Namespace)]
    public class SwisSettings
    {
        [DataMember(Name = Constants.DataProviderTimeoutMessageProperty)]
        public TimeSpan DataProviderTimeout { get; set; }

        [DataMember(Name = Constants.ApplicationTagMessageProperty)]
        public string ApplicationTag { get; set; }

        [DataMember(Name = Constants.AppendErrorsMessageProperty)]
        public bool AppendErrors { get; set; }
    }
}
