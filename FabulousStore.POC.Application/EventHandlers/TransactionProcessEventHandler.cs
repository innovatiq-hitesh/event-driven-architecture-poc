using FabulousStore.POC.Core.Abstractions.EventHandlers;
using FabulousStore.POC.Core.Events;
using Microsoft.Extensions.Logging;

namespace FabulousStore.POC.Core.EventHandlers
{
    internal class TransactionProcessEventHandler(ILogger<TransactionProcessEventHandler> logger) : NotificationEventHandler<TransactionProcessEvent>(logger)
    {
        protected override async Task HandleAsync(TransactionProcessEvent notification, CancellationToken cancellationToken)
        {
            // Process Transaction & Push message into queue
            await Task.CompletedTask;
        }
    }
}
