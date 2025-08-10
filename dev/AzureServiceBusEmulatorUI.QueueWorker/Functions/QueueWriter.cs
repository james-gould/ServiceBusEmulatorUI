using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AzureServiceBusEmulatorUI.Shared.Constants;
using AzureServiceBusEmulatorUI.Shared.Utilities;

namespace AzureServiceBusEmulatorUI.QueueWorker.Functions;

public class QueueWriter(
    ILogger<QueueWriter> logger,
    IHostApplicationLifetime lifetime,
    ServiceBusClient busClient)
{
    [Function(nameof(QueueWriter))]
    public async Task Run([ServiceBusTrigger(AspireResources.Queues.TyreKicker)]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        logger.LogInformation("Starting {name} on an infinite loop.", nameof(QueueWriter));

        var queueSender = busClient.CreateSender(AspireResources.Queues.DebugQueue);

        while (!lifetime.ApplicationStopping.IsCancellationRequested)
        {
            var msg = new ServiceBusMessage(Guid.NewGuid().ToString("n"));

            await queueSender.SendMessageAsync(msg);

            await RandomUtils.DelayAsync();
        }

        await messageActions.CompleteMessageAsync(message);
    }
}
