using MediatR;

namespace FabulousStore.POC.Core.Events
{
    internal class TransactionViolationEvent : INotification
    {
        public TransactionViolationEvent(string correlationId, string tenantId, string transactionId, DateTime transactionDate, string direction, decimal amount, string[] reasons)
        {
            CorrelationId = correlationId;
            TenantId = tenantId;
            TransactionId = transactionId;
            Direction = direction;
            Amount = amount;
            TransactionDate = transactionDate;
            Reasons = reasons;
        }

        public string CorrelationId { get; }
        public string TenantId { get; }
        public string TransactionId { get; }
        public DateTime TransactionDate { get; }
        public string Direction { get; }
        public decimal Amount { get; }
        public string[] Reasons { get; }

        //Add Other If Required Properties
    }
}
