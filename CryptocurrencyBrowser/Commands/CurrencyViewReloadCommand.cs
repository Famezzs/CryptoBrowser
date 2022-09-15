using System.Windows;

using CryptocurrencyBrowser.Services;
using CryptocurrencyBrowser.ViewModels;

namespace CryptocurrencyBrowser.Commands
{
    public class CurrencyViewReloadCommand : BaseCommand
    {
        private readonly CurrencyViewModel _cryptoCurrencyViewModel;
        public CurrencyViewReloadCommand(CurrencyViewModel cryptoCurrencyViewModel)
        {
            _cryptoCurrencyViewModel = cryptoCurrencyViewModel;
        }

        public override async void Execute(object? parameter)
        {
            try
            {
                _cryptoCurrencyViewModel.CryptoCurrencies = await new CryptoCurrencyService().GetTopTenCurrency();
                
                DisplayResult();
            }
            catch
            {
                DisplayError();
            }
        }

        private void DisplayResult()
        {
            _cryptoCurrencyViewModel.ShowList = Visibility.Visible;

            _cryptoCurrencyViewModel.ShowError = Visibility.Hidden;
        }

        private void DisplayError()
        {
            _cryptoCurrencyViewModel.ShowList = Visibility.Hidden;

            _cryptoCurrencyViewModel.ShowError = Visibility.Visible;
        }
    }
}
