using System;
using System.Runtime.Serialization;

namespace SolarWinds.InformationService.Contract2
{
    [DataContract(Name = "InformationServiceFaultContract", Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
    public class InfoServiceFaultContract
    {
        [DataMember(Name = "UserMessage", Order = 3, IsRequired = false, EmitDefaultValue = false)]
        private string _userMessage;

        public virtual void SetFaultDetails(Exception ex)
        {
            Message = ex.Message;
        }

        [field: DataMember(Name = "Message", Order = 1, IsRequired = true)]
        public string Message { get; private set; }

        [field: DataMember(Name = "ErrorCode", Order = 2, IsRequired = false, EmitDefaultValue = false)]
        public int ErrorCode { get; private set; }

        public string UserMessage
        {
            get { return _userMessage ?? Message; }
            private set { _userMessage = value; }
        }
    }
}
