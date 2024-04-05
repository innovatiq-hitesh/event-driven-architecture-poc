using FabulousStore.POC.Core.Abstractions.IntegrationEventHandlers;
using FabulousStore.POC.Core.Abstractions.IntegrationEvents;

namespace FabulousStore.POC.Core.Abstractions.EventBus
{
    internal interface IEventBus
    {
        Task PublishAsync(IntegrationEvent @event);

        void Subscribe<T, TH>()
            where T : IntegrationEvent, new()
            where TH : IntegrationEventHandler<T>;

        void Unsubscribe<T, TH>()
            where T : IntegrationEvent, new()
            where TH : IntegrationEventHandler<T>;

        Task SetupAsync();
    }
}
