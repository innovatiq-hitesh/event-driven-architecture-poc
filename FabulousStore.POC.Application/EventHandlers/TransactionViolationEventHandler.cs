using FabulousStore.POC.Core.Abstractions.EventHandlers;
using FabulousStore.POC.Core.Events;
using Microsoft.Extensions.Logging;

namespace FabulousStore.POC.Core.EventHandlers
{
    internal class TransactionViolationEventHandler(ILogger<TransactionViolationEventHandler> logger) : NotificationEventHandler<TransactionViolationEvent>(logger)
    {
        protected override async Task HandleAsync(TransactionViolationEvent notification, CancellationToken cancellationToken)
        {
            //
            await Task.CompletedTask;
        }
    }
}
