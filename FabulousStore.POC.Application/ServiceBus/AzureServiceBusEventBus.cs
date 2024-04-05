using FabulousStore.POC.Core.Abstractions.EventBus;
using FabulousStore.POC.Core.Abstractions.IntegrationEventHandlers;
using FabulousStore.POC.Core.Abstractions.IntegrationEvents;

namespace FabulousStore.POC.Core.ServiceBus
{
    internal class AzureServiceBusEventBus : IEventBus
    {
        public Task PublishAsync(IntegrationEvent @event)
        {
            // Send Message into Topic
            return Task.CompletedTask;
        }

        public Task SetupAsync()
        {
            // Setup Service Bus
            return Task.CompletedTask;
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent, new()
            where TH : IntegrationEventHandler<T>
        {
            // Do Subscribe All Event into Topics & Invoke Integration Event Handlers
        }

        public void Unsubscribe<T, TH>()
            where T : IntegrationEvent, new()
            where TH : IntegrationEventHandler<T>
        {
            // Do Unsubscribe all Events into Topics
        }
    }
}
