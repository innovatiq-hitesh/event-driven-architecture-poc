using FabulousStore.POC.Core.Abstractions.IntegrationEvents;
using FabulousStore.POC.Core.DomainTransferObjects;

namespace FabulousStore.POC.Core.IntegrationEvents
{
    internal class NewTransactionCreatedIntegrationEvent : IntegrationEvent
    {
        public string CorrelationId { get; set; }
        public string TenantId { get; set; }
        public string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Direction { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public Account Sourceaccount { get; set; }
        public Account Destinationaccount { get; set; }
    }
}
