using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace SolarWinds.InformationService.Contract2
{
    public class SwisProtocolVersionAttribute : Attribute, IContractBehavior
    {
        private readonly SwisProtocolVersionMessageInspector messageInspector = new SwisProtocolVersionMessageInspector();

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {

        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint,
                                          DispatchRuntime dispatchRuntime)
        {

        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(messageInspector);
        }

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint,
                                         BindingParameterCollection bindingParameters)
        {

        }
    }
}
