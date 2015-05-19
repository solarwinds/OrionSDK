using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SolarWinds.InformationService.Contract2.Impersonation
{
    [DataContract(Name = Constants.HeaderName, Namespace = Constants.Namespace)]
    public class ImpersonationHeader
    {
        [DataMember]
        public string TargetUsername { get; set; }

        public static ImpersonationHeader GetHeaderFromIncomingMessage()
        {
            MessageHeaders headers = OperationContext.Current.IncomingMessageHeaders;

            return (from uheader in headers
                    where uheader.Name == Constants.HeaderName && uheader.Namespace == Constants.Namespace
                    select headers.GetHeader<ImpersonationHeader>(uheader.Name, uheader.Namespace)).FirstOrDefault();
        }
    }
}
