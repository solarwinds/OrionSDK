using System;
using System.Runtime.Serialization;

namespace SolarWinds.InformationService.Contract2
{
    [DataContract(Name = "InformationServiceFaultContract", Namespace = "http://schemas.solarwinds.com/2007/08/informationservice")]
    public class InfoServiceFaultContract
    {
        [DataMember(Name = "Message", Order = 1, IsRequired = true)]
        private string _message;

        [DataMember(Name = "ErrorCode", Order = 2, IsRequired = false, EmitDefaultValue = false)]
        private int _errorCode;

        [DataMember(Name = "UserMessage", Order = 3, IsRequired = false, EmitDefaultValue = false)]
        private string _userMessage;

        public virtual void SetFaultDetails(Exception ex)
        {
            _message = ex.Message;
        }

        public string Message
        {
            get
            {
                return _message;
            }
        }

        public int ErrorCode
        {
            get { return _errorCode; }
            private set { _errorCode = value; }
        }

        public string UserMessage
        {
            get { return _userMessage ?? Message; }
            private set { _userMessage = value; }
        }
    }
}
