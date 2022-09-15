using CryptocurrencyBrowser.Actions.CurrencySearch;
using CryptocurrencyBrowser.Commands;

using System;
using System.Windows;
using System.Windows.Input;

namespace CryptocurrencyBrowser.ViewModels
{
    public class CurrencySearchViewModel : ViewModelBase
    {
        public CryptoCurrencySearchBinder? _searchResult;
        public CryptoCurrencySearchBinder? SearchResult
        {
            get => _searchResult;
            set
            {
                _searchResult = value;
                OnPropertyChanged(nameof(SearchResult));
            }
        }

        private string _coinName = string.Empty;
        public string CoinName
        {
            get => _coinName;
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
            get => _showResult;
            set
            {
                _showResult = value;
                OnPropertyChanged(nameof(ShowResult));
            }
        }

        private Visibility _showError = Visibility.Hidden;
        public Visibility ShowError
        {
            get => _showError;
            set
            {
                _showError = value;
                OnPropertyChanged(nameof(ShowError));
            }
        }

        public CurrencySearchSubmitCommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand GoBackCommand { get; }

        public CurrencySearchViewModel(Stores.NavigationStore navigationStore, Func<CurrencyViewModel> createViewModel)
        {
            SubmitCommand = new CurrencySearchSubmitCommand(this);

            CancelCommand = new ViewCommand(CancelSearch.Execute, this);

            GoBackCommand = new RedirectCommand(navigationStore, createViewModel);
        }
    }
}
