using FabulousStore.POC.Core.Abstractions.Services;
using FabulousStore.POC.Core.Abstractions.Utils;
using FabulousStore.POC.Core.DomainTransferObjects;
using FabulousStore.POC.Core.Events;
using FluentValidation;

namespace FabulousStore.POC.Core.Services
{
    internal class PaymentService(IDispatcher dispatcher, IValidator<TransactionRequestDTO> validator) : IPaymentService
    {
        private readonly IValidator<TransactionRequestDTO> _transactionRequestValidator = validator;

        private readonly IDispatcher _dispatcher = dispatcher;

        public async Task ExecuteTransactionAsync(TransactionRequestDTO requestDTO)
        {
            try
            {
                var validationResult = await _transactionRequestValidator.ValidateAsync(requestDTO);

                if (validationResult.IsValid)
                {
                    var processPaymentEvent = new TransactionProcessEvent(requestDTO.CorrelationId, requestDTO.TenantId, requestDTO.TransactionId, requestDTO.TransactionDate, requestDTO.Direction, requestDTO.Amount);

                    await _dispatcher.PublishAsync(processPaymentEvent);
                }
                else
                {
                    var transactionViolationEvent = new TransactionViolationEvent(requestDTO.CorrelationId, requestDTO.TenantId, requestDTO.TransactionId, requestDTO.TransactionDate, requestDTO.Direction, requestDTO.Amount, validationResult.Errors.Select(t => t.ErrorMessage).ToArray());
                    var transactionHoldEvent = new TransactionHoldEvent(requestDTO.CorrelationId, requestDTO.TenantId, requestDTO.TransactionId, requestDTO.TransactionDate, requestDTO.Direction, requestDTO.Amount);

                    await _dispatcher.PublishAsync(transactionViolationEvent);
                    await _dispatcher.PublishAsync(transactionHoldEvent);
                }
            }
            catch (Exception ex)
            {
                var transactionFailedEvent = new TransactionFailedEvent(requestDTO.CorrelationId, requestDTO.TenantId, requestDTO.TransactionId, requestDTO.TransactionDate, requestDTO.Direction, requestDTO.Amount);

                await _dispatcher.PublishAsync(transactionFailedEvent);

                throw;
            }
        }
    }
}
