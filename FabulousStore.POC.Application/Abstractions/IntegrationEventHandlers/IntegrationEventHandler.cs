using FabulousStore.POC.Core.Abstractions.IntegrationEvents;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FabulousStore.POC.Core.Abstractions.IntegrationEventHandlers
{
    internal abstract class IntegrationEventHandler<T>(ILogger logger) : INotificationHandler<T>
        where T : IntegrationEvent, new()
    {
        protected readonly ILogger Logger = logger;

        public async Task Handle(T notification, CancellationToken cancellationToken)
        {
            Logger.LogDebug($"Integration Event {typeof(T).FullName} Data : {JsonSerializer.Serialize(notification)}");

            await HandleAsync(notification, cancellationToken);
        }

        protected abstract Task HandleAsync(T notification, CancellationToken cancellationToken);
    }
}
