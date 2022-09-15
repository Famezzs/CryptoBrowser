using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using CryptocurrencyBrowser.Constants;
using CryptocurrencyBrowser.Models;
using CryptocurrencyBrowser.ViewModels;
using System;

namespace CryptocurrencyBrowser.Services
{
    public class CryptoCurrencyService
    {
        public async Task<ObservableCollection<CryptoCurrencyBinder>> GetTopTenCurrency()
        {
            var httpClient = new HttpClient();

            var requestResult = await httpClient.GetStringAsync(ConstantValues._coinRequestUrl);

            var result = JsonConvert.DeserializeObject<CryptoCurrencyList>(requestResult);

            var listResult = new ObservableCollection<CryptoCurrencyBinder>();

            if (result != null)
            {
                foreach (var currency in result.Data)
                {
                    listResult.Add(new CryptoCurrencyBinder(currency));
                }
            }

            return listResult;
        }

        public async Task<CryptoCurrencySearchBinder> FindCoinWithMarketsById(string currencyId)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(ConstantValues._assetSearchUrl +
                currencyId);

            var resultCoin = JsonConvert.DeserializeObject<CryptoCurrencySearch>(response);

            response = await httpClient.GetStringAsync(ConstantValues._assetSearchUrl +
                currencyId + ConstantValues._marketSearchSubUrl);

            var resultMarkets = JsonConvert.DeserializeObject<CryptoMarketSearch>(response);

            var searchResult = new CryptoCurrencySearchBinder(resultCoin!.Data!, resultMarkets!.Data!);

            return searchResult;
        }

        public async Task<CryptoCurrency?> FindCoinById(string currencyId)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(ConstantValues._assetSearchUrl +
                currencyId);

            var resultCoin = JsonConvert.DeserializeObject<CryptoCurrencySearch>(response);

            return resultCoin!.Data;
        }
    }
}
