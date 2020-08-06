using System.ServiceModel;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    class NCMInfoService : InfoServiceBase
    {
        public NCMInfoService(string username, string password)
        {
            _endpoint = Settings.Default.NCMEndpointPath;
            _endpointConfigName = "NCMTcpBinding_InformationServicev2";
            _binding = new NetTcpBinding("TransportMessage");
            _credentials = new UsernameCredentials(username, password);
        }

        public override string ServiceType
        {
            get { return "NCM"; }
        }
    }
}
