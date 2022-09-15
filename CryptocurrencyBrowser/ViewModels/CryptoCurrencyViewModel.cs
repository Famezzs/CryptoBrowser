﻿using CryptocurrencyBrowser.Commands;
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
    public class CryptoCurrencyViewModel : ViewModelBase
    {
        private ObservableCollection<CryptoCurrencyBinder> _cryptoCurrency = new();
        public ObservableCollection<CryptoCurrencyBinder> CryptoCurrencies
        {
            get
            {
                return _cryptoCurrency;
            }
            set
            {
                _cryptoCurrency = value;
                OnPropertyChanged(nameof(CryptoCurrencies));
            }
        }

        private Visibility _showList = Visibility.Visible;
        public Visibility ShowList
        {
            get
            {
                return _showList;
            }
            set
            {
                _showList = value;
                OnPropertyChanged(nameof(ShowList));
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

        public ICommand ReloadCommand { get; }
        public ICommand CoinSearchCommand { get; }

        public CryptoCurrencyViewModel(NavigationStore navigationStore, Func<CurrencySearchViewModel> createSearchViewModel)
        {
            ReloadCommand = new CurrencyViewReloadCommand(this);

            ReloadCommand.Execute(null);

            CoinSearchCommand = new RedirectCommand(navigationStore, createSearchViewModel);
        }
    }
}
