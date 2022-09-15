using CryptocurrencyBrowser.ViewModels;

using System.Windows;

namespace CryptocurrencyBrowser.Actions.CurrencySearch
{
    public class CancelSearch
    {
        public static void Execute(ViewModelBase viewModel)
        {
            if (viewModel is CurrencySearchViewModel model)
            {
                model.SearchResult = null;

                model.CoinName = string.Empty;

                model.ShowResult = Visibility.Hidden;

                model.ShowError = Visibility.Hidden;
            }
        }
    }
}
