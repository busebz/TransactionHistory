using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TransactionHistory.Models;

namespace TransactionHistory.Services
{
    public class JsonData
    {
        public async Task<TransactionResponse> GetTransactionHistoryFromJsonAsync()
        {
            var filePath = "C:\\Users\\Busenur Boz\\Desktop\\TransactionHistoryGipDataDto.json";
            var json = await File.ReadAllTextAsync(filePath);

            // JSON verisini TransactionResponse tipine dönüştürüyoruz (Deserialize işlemi)
            var transactionResponse = JsonConvert.DeserializeObject<TransactionResponse>(json);

            return transactionResponse;
        }

    }
}
