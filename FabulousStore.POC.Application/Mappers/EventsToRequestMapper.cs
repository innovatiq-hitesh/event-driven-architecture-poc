using AutoMapper;
using FabulousStore.POC.Core.DomainTransferObjects;
using FabulousStore.POC.Core.IntegrationEvents;

namespace FabulousStore.POC.Core.Mappers
{
    internal class EventsToRequestMapper : Profile
    {
        public EventsToRequestMapper()
        {
            CreateMap<NewTransactionCreatedIntegrationEvent, TransactionRequestDTO>();
        }
    }
}
