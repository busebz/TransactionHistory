using Microsoft.AspNetCore.Mvc.RazorPages;
using TransactionHistory.Models;
using TransactionHistory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionHistory.Pages
{
    public class IndexModel : PageModel
    {
        private readonly JsonData _jsonData;
  
        public IndexModel(JsonData jsonData)
        {
            _jsonData = jsonData;
        }

        // ContractSummaries, sayfada gösterilecek özet verileri tutar
        public List<ContractSummary> ContractSummaries { get; set; }

        // OnGetAsync metodu, sayfa ilk yüklendiğinde çalışacak ve asenkron olarak veri çekecektir
        public async Task OnGetAsync()
        {
            // JSON dosyasından verileri alıyoruz
            var response = await _jsonData.GetTransactionHistoryFromJsonAsync();
            var transactionHistoryList = response.Items;

            // Eğer işlem listesi boşsa, ContractSummaries boş bir liste olarak döndürülür
            if (transactionHistoryList == null || !transactionHistoryList.Any())
            {
                ContractSummaries = new List<ContractSummary>();
                return;
            }

            // Burada işlem listelerini ContractName'e göre grupluyoruz ve her grup için özet hesaplamaları yapıyoruz
            ContractSummaries = transactionHistoryList
                .GroupBy(x => x.ContractName) 
                .Select(g => new ContractSummary
                {
                    ContractName = g.Key,  
                    TotalTransactionAmount = g.Sum(item => (item.Price * item.Quantity) / 10),  // Toplam işlem tutarı
                    TotalTransactionQuantity = g.Sum(item => item.Quantity / 10),  // Toplam işlem miktarı
                    WeightedAveragePrice = g.Sum(item => (item.Price * item.Quantity) / 10) / g.Sum(item => item.Quantity / 10),  // Ağırlıklı ortalama fiyat
                    Date = ParseContractDate(g.Key)  // ContractName'den tarihi çıkarıyoruz
                })
                .ToList();  
        }

        // ContractName'den tarihi çıkaran yardımcı metod
        private DateTime ParseContractDate(string contractName)
        {
            // ContractName'in ilk 2 basamağını yıl olarak alıyoruz, "20" ekliyoruz
            var year = int.Parse("20" + contractName.Substring(2, 2));
            var month = int.Parse(contractName.Substring(4, 2));
            var day = int.Parse(contractName.Substring(6, 2));
            var hour = int.Parse(contractName.Substring(8, 2));

            return new DateTime(year, month, day, hour, 0, 0); 
        }
    }
}
