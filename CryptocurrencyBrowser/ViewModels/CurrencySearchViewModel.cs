using CryptocurrencyBrowser.Commands;
using CryptocurrencyBrowser.Models;
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

        private Visibility _showError = Visibility.Hidden;
        public Visibility ShowError
        {
            get
            {
                return _showError;
            }
            set
            {
                _showError = value;
                OnPropertyChanged(nameof(ShowError));
            }
        }

        public CurrencySearchSubmitCommand SubmitCommand { get; }
        public CurrencySearchCancelCommand CancelCommand { get; }
        public ICommand GoBackCommand { get; }

        public CurrencySearchViewModel(Stores.NavigationStore navigationStore, Func<CryptoCurrencyViewModel> createViewModel)
        {
            SubmitCommand = new CurrencySearchSubmitCommand(this);

            CancelCommand = new CurrencySearchCancelCommand(this);

            GoBackCommand = new RedirectCommand(navigationStore, createViewModel);
        }
    }
}
