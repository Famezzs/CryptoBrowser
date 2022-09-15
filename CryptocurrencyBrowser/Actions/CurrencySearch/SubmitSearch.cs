using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using CryptocurrencyBrowser.Services;
using CryptocurrencyBrowser.ViewModels;

namespace CryptocurrencyBrowser.Actions.CurrencySearch
{
    public class SubmitSearch
    {
        public static async void Execute(ViewModelBase viewModel)
        {
            if (viewModel is not CurrencySearchViewModel model)
            {
                return;
            }

            var currencyId = model.CoinName;

            if (String.IsNullOrEmpty(currencyId))
            {
                return;
            }

            currencyId = currencyId.ToLower().Replace(' ', '-');

            try
            {
                var searchResult = await new CryptoCurrencyService().FindCoinWithMarketsById(currencyId);
                
                DisplayResult(model, searchResult);
            }
            catch
            {
                DisplayError(model);
            }
        }

        private static void DisplayResult(CurrencySearchViewModel model, CryptoCurrencySearchBinder? searchResult)
        {
            model.SearchResult = searchResult;

            model.ShowResult = Visibility.Visible;

            model.ShowError = Visibility.Hidden;
        }
        private static void DisplayError(CurrencySearchViewModel model)
        {
            model.SearchResult = null;

            model.ShowResult = Visibility.Hidden;

            model.ShowError = Visibility.Visible;
        }
    }
}
