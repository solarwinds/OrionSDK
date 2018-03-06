using SolarWinds.InformationService.Contract2;
using SwqlStudio.Subscriptions;

namespace SwqlStudio
{
    public interface IApplicationService
    {
        PropertyBag QueryParameters { get; set; }

        SubscriptionManager SubscriptionManager { get; }

        void RefreshDynamiConnections();
    }
}
