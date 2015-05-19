using System.ServiceModel;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    class NCMForwarderInfoService : InfoServiceBase
    {
        public NCMForwarderInfoService(string username, string password)
        {
            _endpoint = Settings.Default.NCMForwarderEndpointPath;
            _endpointConfigName = "OrionTcpBinding_InformationServicev2";
            _binding = new NetTcpBinding("TransportMessage");
            _credentials = new UsernameCredentials(username, password);
        }

        public override string ServiceType
        {
            get { return "NCM Integration"; }
        }
    }
}
