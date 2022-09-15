using CryptocurrencyBrowser.ViewModels;
using System.Windows;

namespace CryptocurrencyBrowser.Commands
{
    public class CurrencySearchCancelCommand : BaseCommand
    {
        private readonly CurrencySearchViewModel _currencySearchViewModel;

        public CurrencySearchCancelCommand(CurrencySearchViewModel currencySearchViewModel)
        {
            _currencySearchViewModel = currencySearchViewModel;
        }

        public override void Execute(object? parameter)
        {
            _currencySearchViewModel.SearchResult = null;

            _currencySearchViewModel.CoinName = string.Empty;

            _currencySearchViewModel.ShowResult = Visibility.Hidden;

            _currencySearchViewModel.ShowError = Visibility.Hidden;
        }
    }
}
