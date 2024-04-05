using FabulousStore.POC.Core.DomainTransferObjects;

namespace FabulousStore.POC.Core.Abstractions.Services
{
    public interface IPaymentService
    {
        Task ExecuteTransactionAsync(TransactionRequestDTO requestDTO);
    }
}
