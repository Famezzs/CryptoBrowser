using System;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace CryptocurrencyBrowser.Models
{
    public class CryptoCurrencyList
    {
        public CryptoCurrency[] cryptoCurrencies { get; set; } = Array.Empty<CryptoCurrency>();

        private static readonly string _coinRequestUrl = "https://api.coincap.io/v2/assets?limit=10";

        public static async Task<CryptoCurrencyList> GetTopTenCurrency()
        {
            var httpClient = new HttpClient();

            var requestResult = await httpClient.GetStringAsync(_coinRequestUrl);

            var result = JsonConvert.DeserializeObject<CryptoCurrencyList>(requestResult);

            return result ?? new CryptoCurrencyList();
        }
    }
}
