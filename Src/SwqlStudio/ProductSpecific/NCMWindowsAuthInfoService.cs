using System.ServiceModel;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    internal class NCMWindowsAuthInfoService : InfoServiceBase
    {
        public NCMWindowsAuthInfoService(string username, string password)
        {
            _endpoint = Settings.Default.NCMWindowsEndpointPath;
            _endpointConfigName = "NCMWindowsTcpBinding_InformationServicev2";
            _binding = new NetTcpBinding("Windows");
            _credentials = new WindowsCredential(username, password);
        }

        public override string ServiceType
        {
            get { return "NCM (Windows Authentication)"; }
        }
    }
}
