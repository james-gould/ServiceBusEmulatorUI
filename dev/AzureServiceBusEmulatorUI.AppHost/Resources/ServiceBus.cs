using Aspire.Hosting.Azure;
using AzureServiceBusEmulatorUI.Shared.Constants;

namespace AzureServiceBusEmulatorUI.AppHost.Resources;

internal static class ServiceBus
{
    internal static IResourceBuilder<AzureServiceBusResource> AddServiceBusWithQueues(this IDistributedApplicationBuilder builder)
    {
        var bus = builder
            .AddAzureServiceBus(AspireResources.ServiceBus)
            .RunAsEmulator();

        bus.AddServiceBusQueue(AspireResources.Queues.DebugQueue);
        bus.AddServiceBusQueue(AspireResources.Queues.TyreKicker);

        return bus;
    }
}
