using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceBusEmulatorUI.QueueWorker.Services;
using ServiceBusEmulatorUI.Shared.Constants;
using ServiceBusEmulatorUI.Shared.Utilities;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.AddServiceDefaults();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

var busConnectionString = EnvUtils.GetEnvVar(AspireResources.ServiceBus);

builder.Services.AddSingleton(() => new ServiceBusClient(busConnectionString));
builder.Services.AddHostedService<TyreKickingService>();

builder.Build().Run();
