using CryptocurrencyBrowser.Constants;
using CryptocurrencyBrowser.Models;
using CryptocurrencyBrowser.ViewModels;

using Newtonsoft.Json;

using System;
using System.Net.Http;
using System.Windows;

namespace CryptocurrencyBrowser.Commands
{
    public class CurrencySearchSubmitCommand : CommandBase
    {
        private readonly CurrencySearchViewModel _currencySearchViewModel;

        private string? _currencyId;
        public string? CurrencyId
        {
            get
            {
                return _currencyId;
            }
            set
            {
                _currencyId = value?.ToLower().Replace(' ', '-');
            }
        }

        public CurrencySearchSubmitCommand(CurrencySearchViewModel currencySearchViewModel)
        {
            _currencySearchViewModel = currencySearchViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (String.IsNullOrEmpty(CurrencyId))
            {
                return;
            }

            try
            {
                var httpClient = new HttpClient();

                var response = httpClient.GetStringAsync(ConstantValues._assetSearchUrl + CurrencyId)
                    .GetAwaiter()
                    .GetResult();

                var resultCoin = JsonConvert.DeserializeObject<CryptoCurrencySearch>(response);

                response = httpClient.GetStringAsync(ConstantValues._assetSearchUrl +
                    CurrencyId + ConstantValues._marketSearchSubUrl)
                    .GetAwaiter()
                    .GetResult();

                var resultMarkets = JsonConvert.DeserializeObject<CryptoMarketSearch>(response);

                var searchResult = new CryptoCurrencySearchBinder(resultCoin!.Data!, resultMarkets!.Data!);

                _currencySearchViewModel.SearchResult = searchResult;

                _currencySearchViewModel.ShowResult = Visibility.Visible;
            }
            catch
            {
                _currencySearchViewModel.SearchResult = null;

                _currencySearchViewModel.ShowResult = Visibility.Hidden;
            }
        }
    }
}
