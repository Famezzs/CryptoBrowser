using CryptocurrencyBrowser.Services;
using CryptocurrencyBrowser.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptocurrencyBrowser.Actions.Currency
{
    public class ViewReload
    {
        public static async void Execute(ViewModelBase viewModel)
        {
            if (viewModel is CurrencyViewModel model)
            {
                try
                {
                    model.ShowError = Visibility.Hidden;

                    model.ShowList = Visibility.Hidden;

                    model.ShowLoading = Visibility.Visible;

                    var result = await new CryptoCurrencyService().GetTopTenCurrency();

                    model.CryptoCurrencies = result;

                    model.ShowLoading = Visibility.Hidden;

                    model.ShowList = Visibility.Visible;
                }
                catch
                {
                    model.ShowList = Visibility.Hidden;

                    model.ShowError = Visibility.Visible;
                }
            }
        }
    }
}
