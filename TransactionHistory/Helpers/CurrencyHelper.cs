namespace TransactionHistory.Helpers
{
    // Para birimi formatlamalarını sağlayan yardımcı sınıf
    public static class CurrencyHelper
    {
        // Sayıyı Türk para birimi formatında döndürür
        public static string FormatCurrency(decimal value)
        {
            return value
                .ToString("#,0.00")  // Binlik ayraç virgül, ondalık nokta
                .Replace(",", "X")   // Virgülü geçici olarak "X" ile değiştir
                .Replace(".", ",")   // Noktayı virgülle değiştir
                .Replace("X", ".");  // "X" karakterini noktaya çevir
        }
    }
}





