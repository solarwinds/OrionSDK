using System.ServiceModel.Channels;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    class OrionInfoServiceCompressed : InfoServiceBase
    {
        public OrionInfoServiceCompressed(string username, string password, bool v3 = false)
        {
            _endpoint = v3 ? Settings.Default.OrionV3EndpointPathCompressed : Settings.Default.OrionEndpointPathCompressed;
            _endpointConfigName = "OrionTcpBindingCompressed";
            _binding = new CustomBinding("CompressedUserName");
            _credentials = new UsernameCredentials(username, password);
        }

        public override string ServiceType
        {
            get { return "Orion Compressed"; }
        }
    }
}
