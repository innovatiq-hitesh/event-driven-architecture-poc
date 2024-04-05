using FabulousStore.POC.Core.Abstractions.EventHandlers;
using FabulousStore.POC.Core.Events;
using Microsoft.Extensions.Logging;

namespace FabulousStore.POC.Core.EventHandlers
{
    internal class TransactionFailedEventHandler(ILogger<TransactionFailedEventHandler> logger) : NotificationEventHandler<TransactionFailedEvent>(logger)
    {
        protected override async Task HandleAsync(TransactionFailedEvent notification, CancellationToken cancellationToken)
        {
            //Push Message into Operation Queue and do other stuff
            await Task.CompletedTask;
        }
    }
}
