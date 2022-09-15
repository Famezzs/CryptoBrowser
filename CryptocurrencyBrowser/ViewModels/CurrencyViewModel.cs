using CryptocurrencyBrowser.Actions.Currency;
using CryptocurrencyBrowser.Commands;
using CryptocurrencyBrowser.Models;
using CryptocurrencyBrowser.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CryptocurrencyBrowser.ViewModels
{
    public class CurrencyViewModel : ViewModelBase
    {
        private ObservableCollection<CryptoCurrencyBinder> _cryptoCurrency = new();
        public ObservableCollection<CryptoCurrencyBinder> CryptoCurrencies
        {
            get => _cryptoCurrency;
            set
            {
                _cryptoCurrency = value;
                OnPropertyChanged(nameof(CryptoCurrencies));
            }
        }

        private string? _loadMessage = "Loading...";
        public string? LoadMessage
        {
            get => _loadMessage;
            set
            {
                _loadMessage = value;
                OnPropertyChanged(nameof(LoadMessage));
            }
        }

        private Visibility _showList = Visibility.Hidden;
        public Visibility ShowList
        {
            get => _showList;
            set
            {
                _showList = value;
                OnPropertyChanged(nameof(ShowList));
            }
        }

        private Visibility _showLoading = Visibility.Hidden;
        public Visibility ShowLoading
        {
            get => _showLoading;
            set
            {
                _showLoading = value;
                OnPropertyChanged(nameof(ShowLoading));
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

        public ICommand ReloadCommand { get; }
        public ICommand CoinSearchCommand { get; }
        public ICommand CurrencyConvertCommand { get; }

        public CurrencyViewModel(NavigationStore navigationStore, 
            Func<CurrencySearchViewModel> createSearchViewModel,
            Func<CurrencyConvertViewModel> createConvertViewModel)
        {
            ReloadCommand = new ViewCommand(ViewReload.Execute, this);

            ReloadCommand.Execute(null);

            CoinSearchCommand = new RedirectCommand(navigationStore, createSearchViewModel);

            CurrencyConvertCommand = new RedirectCommand(navigationStore, createConvertViewModel);
        }
    }
}
