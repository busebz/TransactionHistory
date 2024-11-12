namespace TransactionHistory.Models
{
    public class ContractSummary
    {
        public string ContractName { get; set; }
        public decimal TotalTransactionAmount { get; set; }
        public decimal TotalTransactionQuantity { get; set; }
        public decimal WeightedAveragePrice { get; set; }
        public DateTime Date { get; set; }
    }
}
