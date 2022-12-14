using CryptocurrencyBrowser.Constants;
using CryptocurrencyBrowser.Models;
using CryptocurrencyBrowser.Services;
using CryptocurrencyBrowser.ViewModels;

using System;
using System.Windows;

namespace CryptocurrencyBrowser.Commands
{
    public class CurrencySearchSubmitCommand : BaseCommand
    {
        private readonly CurrencySearchViewModel _currencySearchViewModel;

        private string? _currencyId;
        public string? CurrencyId
        {
            get => _currencyId;
            set
            {
                _currencyId = value?.ToLower().Replace(' ', '-');
            }
        }

        public CurrencySearchSubmitCommand(CurrencySearchViewModel currencySearchViewModel)
        {
            _currencySearchViewModel = currencySearchViewModel;
        }

        public override async void Execute(object? parameter)
        {
            if (String.IsNullOrEmpty(CurrencyId))
            {
                return;
            }

            try
            {
                var searchResult = await new CryptoCurrencyService().FindCoinWithMarketsById(CurrencyId); 

                _currencySearchViewModel.SearchResult = searchResult;

                _currencySearchViewModel.ShowResult = Visibility.Visible;

                _currencySearchViewModel.ShowError = Visibility.Hidden;
            }
            catch
            {
                _currencySearchViewModel.SearchResult = null;

                _currencySearchViewModel.ShowResult = Visibility.Hidden;

                _currencySearchViewModel.ShowError = Visibility.Visible;
            }
        }
    }
}
