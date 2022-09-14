using CryptocurrencyBrowser.ViewModels;

namespace CryptocurrencyBrowser.Commands
{
    public class CurrencySearchCancelCommand : CommandBase
    {
        private readonly CurrencySearchViewModel _currencySearchViewModel;

        public CurrencySearchCancelCommand(CurrencySearchViewModel currencySearchViewModel)
        {
            _currencySearchViewModel = currencySearchViewModel;
        }

        public override void Execute(object? parameter)
        {
            _currencySearchViewModel.SearchResult = null;
        }
    }
}
