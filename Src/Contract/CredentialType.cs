
using System.Runtime.Serialization;

namespace SolarWinds.InformationService.Contract2
{
    [DataContract(Name="CredentialType", Namespace = "http://schema.solarwinds.com/2007/08/IS")]
    public enum CredentialType
    {
        [EnumMember(Value = "None")]
        None = 0,

        [EnumMember(Value = "Windows")]
        Windows,

        [EnumMember(Value = "Certificate")]
        Certificate,

        [EnumMember(Value = "Username")]
        Username
    }
}
