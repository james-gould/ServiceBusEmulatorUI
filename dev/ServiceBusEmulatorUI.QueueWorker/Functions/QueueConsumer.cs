using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using ServiceBusEmulatorUI.Shared.Constants;
using ServiceBusEmulatorUI.Shared.Utilities;

namespace ServiceBusEmulatorUI.QueueWorker.Functions;

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
            throw new InvalidOperationException($"Force threw to generate DLQ message");

        await messageActions.CompleteMessageAsync(message);
    }
}
