using AutoMapper;
using FabulousStore.POC.Core.Abstractions.IntegrationEventHandlers;
using FabulousStore.POC.Core.Abstractions.Services;
using FabulousStore.POC.Core.DomainTransferObjects;
using FabulousStore.POC.Core.IntegrationEvents;
using Microsoft.Extensions.Logging;

namespace FabulousStore.POC.Core.IntegrationEventHandlers
{
    internal class NewTransactionCreatedIntegrationEventHandler(IPaymentService paymentService, IMapper mapper, ILogger<NewTransactionCreatedIntegrationEventHandler> logger) : IntegrationEventHandler<NewTransactionCreatedIntegrationEvent>(logger)
    {
        private readonly IPaymentService _paymentService = paymentService;
        private readonly IMapper _mapper = mapper;

        protected override async Task HandleAsync(NewTransactionCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var request = _mapper.Map<TransactionRequestDTO>(notification);

            await _paymentService.ExecuteTransactionAsync(request);
        }
    }
}
