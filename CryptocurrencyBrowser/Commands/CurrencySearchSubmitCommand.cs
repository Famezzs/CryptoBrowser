using CryptocurrencyBrowser.Constants;
using CryptocurrencyBrowser.Models;
using CryptocurrencyBrowser.ViewModels;

using Newtonsoft.Json;

using System;
using System.Net.Http;

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

            var httpClient = new HttpClient();

            var response = httpClient.GetStringAsync(ConstantValues._coinSearchUrl + CurrencyId).GetAwaiter().GetResult();

            var result = JsonConvert.DeserializeObject<CryptoCurrencySearch>(response);

            _currencySearchViewModel.SearchResult = result;
        }
    }
}
