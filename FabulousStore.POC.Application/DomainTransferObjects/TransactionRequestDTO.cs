namespace FabulousStore.POC.Core.DomainTransferObjects
{
    public class TransactionRequestDTO
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

    public class Account
    {
        public long Accountno { get; set; }
        public string Sortcode { get; set; }
        public string Countrycode { get; set; }
    }
}
