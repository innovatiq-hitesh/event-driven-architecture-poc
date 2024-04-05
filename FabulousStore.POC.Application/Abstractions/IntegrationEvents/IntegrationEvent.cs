using MediatR;

namespace FabulousStore.POC.Core.Abstractions.IntegrationEvents
{
    internal abstract class IntegrationEvent : INotification
    {
        public DateTime CreatedAt { get; set; }

        //Other Common Properties
    }
}
