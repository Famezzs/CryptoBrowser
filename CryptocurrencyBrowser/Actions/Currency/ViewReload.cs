using CryptocurrencyBrowser.Services;
using CryptocurrencyBrowser.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            if (viewModel is not CurrencyViewModel model)
            {
                return;
            }

            try
            {
                DisplayLoading(model);

                var result = await new CryptoCurrencyService().GetTopTenCurrency();

                DisplayResult(model, result);
            }
            catch
            {
                DisplayError(model);
            }
        }

        private static void DisplayError(CurrencyViewModel model)
        {
            model.ShowLoading = Visibility.Hidden;

            model.ShowList = Visibility.Hidden;

            model.ShowError = Visibility.Visible;
        }

        private static void DisplayResult(CurrencyViewModel model, ObservableCollection<CryptoCurrencyBinder> result)
        {
            model.CryptoCurrencies = result;

            model.ShowLoading = Visibility.Hidden;

            model.ShowError = Visibility.Hidden;

            model.ShowList = Visibility.Visible;
        }

        private static void DisplayLoading(CurrencyViewModel model)
        {
            model.ShowError = Visibility.Hidden;

            model.ShowList = Visibility.Hidden;

            model.ShowLoading = Visibility.Visible;
        }
    }
}
