using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

using CryptocurrencyBrowser.Constants;
using CryptocurrencyBrowser.ViewModels;

using Newtonsoft.Json;

namespace CryptocurrencyBrowser.Models
{
    public class CryptoCurrencyList
    {
        public CryptoCurrency[] Data { get; set; } = Array.Empty<CryptoCurrency>();

        public static ObservableCollection<CryptoCurrencyBinder> GetTopTenCurrency()
        {
            var httpClient = new HttpClient();

            var requestResult = httpClient.GetStringAsync(ConstantValues._coinRequestUrl).GetAwaiter().GetResult();

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
