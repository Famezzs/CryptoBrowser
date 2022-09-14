using CryptocurrencyBrowser.Commands;
using CryptocurrencyBrowser.Models;
using System.Windows;
using System.Windows.Input;

namespace CryptocurrencyBrowser.ViewModels
{
    public class CurrencySearchViewModel : ViewModelBase
    {
        public CryptoCurrencySearchBinder? _searchResult;
        public CryptoCurrencySearchBinder? SearchResult
        {
            get
            {
                return _searchResult;
            }
            set
            {
                _searchResult = value;
                OnPropertyChanged(nameof(SearchResult));
            }
        }

        private string _coinName = string.Empty;
        public string CoinName
        {
            get 
            { 
                return _coinName;
            }
            set
            {
                _coinName = value;
                SubmitCommand.CurrencyId = value;
                OnPropertyChanged(nameof(CoinName));
            }
        }

        private Visibility _showResult = Visibility.Hidden;
        public Visibility ShowResult
        {
            get
            {
                return _showResult;
            }
            set
            {
                _showResult = value;
                OnPropertyChanged(nameof(ShowResult));
            }
        }

        public CurrencySearchSubmitCommand SubmitCommand { get; }
        public CurrencySearchCancelCommand CancelCommand { get; }

        public CurrencySearchViewModel()
        {
            SubmitCommand = new CurrencySearchSubmitCommand(this);

            CancelCommand = new CurrencySearchCancelCommand(this);
        }
    }
}
