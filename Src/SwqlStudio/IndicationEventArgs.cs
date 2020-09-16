using System;
using SolarWinds.InformationService.Contract2;

namespace SwqlStudio
{
    public class IndicationEventArgs : EventArgs
    {
        public string SubscriptionID { get; set; }
        public string IndicationType { get; set; }
        public PropertyBag IndicationProperties { get; set; }
        public PropertyBag SourceInstanceProperties { get; set; }
    }
}
