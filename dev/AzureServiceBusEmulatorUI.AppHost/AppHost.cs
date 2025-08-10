using ServiceBusEmulatorUI.AppHost.Resources;
using ServiceBusEmulatorUI.Shared.Constants;

var builder = DistributedApplication.CreateBuilder(args);

var bus = builder.AddServiceBusWithQueues();

var func = builder
    .AddAzureFunctionsProject<Projects.ServiceBusEmulatorUI_QueueWorker>(AspireResources.QueueWorker)
    .WithEnvironment(AspireResources.ServiceBus, bus)
    .WithEnvironment("AzureWebJobsServiceBus", bus);

builder.Build().Run();
