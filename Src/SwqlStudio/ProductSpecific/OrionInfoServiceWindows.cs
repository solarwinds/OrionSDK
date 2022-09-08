using System.ServiceModel;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    internal class OrionInfoServiceWindows : InfoServiceBase
    {
        public OrionInfoServiceWindows(string username, string password)
        {
            _endpoint = Settings.Default.OrionV3EndpointPathAD;
            _endpointConfigName = "OrionWindowsTcpBinding";
            _binding = new NetTcpBinding("Windows");
            _credentials = new WindowsCredential(username, password);
        }

        public override string ServiceType
        {
            get { return "Orion AD"; }
        }
    }
}
