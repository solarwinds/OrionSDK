using System.ServiceModel.Channels;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    class OrionInfoServiceWindowsCompressed : InfoServiceBase
    {
        public OrionInfoServiceWindowsCompressed(string username, string password, bool v3 = false)
        {
            _endpoint = v3 ? Settings.Default.OrionV3EndpointPathADCompressed : Settings.Default.OrionEndpointPathADCompressed;
            _endpointConfigName = "OrionWindowsTcpBindingCompressed";
            _binding = new CustomBinding("CompressedWindows");
            _credentials = new WindowsCredential(username, password);
        }

        public override string ServiceType
        {
            get { return "Orion AD Compressed"; }
        }
    }
}
