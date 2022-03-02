using System.ServiceModel;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    internal class OrionInfoServiceWindows : InfoServiceBase
    {
        public OrionInfoServiceWindows(string username, string password, bool v3 = false)
        {
            _endpoint = v3 ? Settings.Default.OrionV3EndpointPathAD : Settings.Default.OrionEndpointPathAD;
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
