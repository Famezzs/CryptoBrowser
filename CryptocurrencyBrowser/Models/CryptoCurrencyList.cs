using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using CryptocurrencyBrowser.ViewModels;
using Newtonsoft.Json;

namespace CryptocurrencyBrowser.Models
{
    public class CryptoCurrencyList
    {
        public CryptoCurrency[] Data { get; set; } = Array.Empty<CryptoCurrency>();

        private static readonly string _coinRequestUrl = "https://api.coincap.io/v2/assets?limit=10";

        private static object _lock = new object();

        public static async Task<ObservableCollection<CryptoCurrencyBinder>> GetTopTenCurrency()
        {
            var httpClient = new HttpClient();

            var requestResult = httpClient.GetStringAsync(_coinRequestUrl).GetAwaiter().GetResult();

            var result = JsonConvert.DeserializeObject<CryptoCurrencyList>(requestResult);

            var listResult = new ObservableCollection<CryptoCurrencyBinder>();

            if (result == null)
            {
                return listResult;
            }

            foreach (var currency in result.Data)
            {
                listResult.Add(new CryptoCurrencyBinder(currency));
            }

            return listResult;
        }
    }
}
