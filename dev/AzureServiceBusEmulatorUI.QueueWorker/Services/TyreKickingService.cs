using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AzureServiceBusEmulatorUI.Shared.Constants;

namespace AzureServiceBusEmulatorUI.QueueWorker.Services;

public class TyreKickingService(
    ILogger<TyreKickingService> logger,
    ServiceBusClient busClient)
    : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting {service} to generate and consume queue data.", nameof(TyreKickingService));

        var sender = busClient.CreateSender(AspireResources.Queues.TyreKicker);

        await sender.SendMessageAsync(new ServiceBusMessage($"start"), cancellationToken);

        logger.LogInformation("Finished sending startup queue message");
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}
