using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using SolarWinds.InformationService.Contract2;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    class EOCInfoService : InfoServiceBase
    {
        public EOCInfoService(string username, string password)
        {
            _endpoint = Settings.Default.EOCEndpointPath;
            _endpointConfigName = "EOCTcpBinding_InformationServicev2";
            _binding = new NetTcpBinding("Windows");
            _credentials = new WindowsCredential(username, password);
        }

        public override string ServiceType
        {
            get { return "EOC"; }
        }
    }

}
