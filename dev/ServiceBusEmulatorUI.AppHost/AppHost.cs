using ServiceBusEmulatorUI.Shared.Constants;

var builder = DistributedApplication.CreateBuilder(args);

var bus = builder
    .AddAzureServiceBus(AspireResources.ServiceBus)
    .RunAsEmulator();

bus.AddServiceBusQueue(AspireResources.Queues.DebugQueue);

builder.Build().Run();
