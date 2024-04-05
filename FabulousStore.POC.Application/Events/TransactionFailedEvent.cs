using MediatR;

namespace FabulousStore.POC.Core.Events
{
    internal class TransactionFailedEvent : INotification
    {
        public TransactionFailedEvent(string correlationId, string tenantId, string transactionId, DateTime transactionDate, string direction, decimal amount)
        {
            CorrelationId = correlationId;
            TenantId = tenantId;
            TransactionId = transactionId;
            Direction = direction;
            Amount = amount;
            TransactionDate = transactionDate;
        }

        public string CorrelationId { get; }
        public string TenantId { get; }
        public string TransactionId { get; }
        public DateTime TransactionDate { get; }
        public string Direction { get; }
        public decimal Amount { get; }

        //Add Other If Required Properties
    }
}
