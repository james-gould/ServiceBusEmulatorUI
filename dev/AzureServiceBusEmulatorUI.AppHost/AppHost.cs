using AzureServiceBusEmulatorUI.AppHost.Resources;
using AzureServiceBusEmulatorUI.Shared.Constants;

var builder = DistributedApplication.CreateBuilder(args);

var bus = builder.AddServiceBusWithQueues();

var func = builder
    .AddAzureFunctionsProject<Projects.AzureServiceBusEmulatorUI_QueueWorker>(AspireResources.QueueWorker)
    .WithEnvironment(AspireResources.ServiceBus, bus)
    .WithEnvironment("AzureWebJobsServiceBus", bus)
    .WaitFor(bus);

builder.Build().Run();
