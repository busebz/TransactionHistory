using Newtonsoft.Json;

namespace TransactionHistory.Models
{
    public class Transaction
    {
        public string ContractName { get; set; }  
        public decimal Price { get; set; }        
        public decimal Quantity { get; set; }     
    }
}
