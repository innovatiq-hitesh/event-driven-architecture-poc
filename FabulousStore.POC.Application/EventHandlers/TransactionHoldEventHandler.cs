using FabulousStore.POC.Core.Abstractions.EventHandlers;
using FabulousStore.POC.Core.Events;
using Microsoft.Extensions.Logging;

namespace FabulousStore.POC.Core.EventHandlers
{
    internal class TransactionHoldEventHandler(ILogger<TransactionHoldEventHandler> logger) : NotificationEventHandler<TransactionHoldEvent>(logger)
    {
        protected override async Task HandleAsync(TransactionHoldEvent notification, CancellationToken cancellationToken)
        {
            //Add Logic to Add Into Queue

            await Task.CompletedTask;
        }
    }
}
