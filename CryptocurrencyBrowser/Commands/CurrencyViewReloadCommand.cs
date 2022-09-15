using CryptocurrencyBrowser.Models;
using CryptocurrencyBrowser.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptocurrencyBrowser.Commands
{
    public class CurrencyViewReloadCommand : CommandBase
    {
        private readonly CryptoCurrencyViewModel _cryptoCurrencyViewModel;
        public CurrencyViewReloadCommand(CryptoCurrencyViewModel cryptoCurrencyViewModel)
        {
            _cryptoCurrencyViewModel = cryptoCurrencyViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _cryptoCurrencyViewModel.CryptoCurrencies = CryptoCurrencyList.GetTopTenCurrency();

                _cryptoCurrencyViewModel.ShowList = Visibility.Visible;

                _cryptoCurrencyViewModel.ShowError = Visibility.Hidden;
            }
            catch
            {
                _cryptoCurrencyViewModel.ShowList = Visibility.Hidden;

                _cryptoCurrencyViewModel.ShowError = Visibility.Visible;
            }
        }
    }
}
