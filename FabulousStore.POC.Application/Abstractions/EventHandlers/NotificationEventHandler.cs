using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FabulousStore.POC.Core.Abstractions.EventHandlers
{
    internal abstract class NotificationEventHandler<T>(ILogger logger) : INotificationHandler<T>
        where T : INotification
    {
        protected readonly ILogger Logger = logger;

        public async Task Handle(T notification, CancellationToken cancellationToken)
        {
            Logger.LogDebug($"Event {typeof(T).FullName} Data : {JsonSerializer.Serialize(notification)}");

            await HandleAsync(notification, cancellationToken);
        }

        protected abstract Task HandleAsync(T notification, CancellationToken cancellationToken);
    }
}
