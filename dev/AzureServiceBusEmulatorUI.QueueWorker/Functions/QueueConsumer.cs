using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using AzureServiceBusEmulatorUI.Shared.Constants;
using AzureServiceBusEmulatorUI.Shared.Utilities;

namespace AzureServiceBusEmulatorUI.QueueWorker.Functions;

public class QueueConsumer(ILogger<QueueConsumer> logger)
{
    [Function(nameof(QueueConsumer))]
    public async Task Run(
        [ServiceBusTrigger(AspireResources.Queues.DebugQueue)]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        logger.LogInformation("Message Body: {body}", message.Body);

        if (RandomUtils.FlexibleFlag())
            await messageActions.AbandonMessageAsync(message);
        else
            await messageActions.CompleteMessageAsync(message);
    }
}
