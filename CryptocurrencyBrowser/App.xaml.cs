﻿using CryptocurrencyBrowser.Stores;
using CryptocurrencyBrowser.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CryptocurrencyBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new();
        }

        protected override void OnStartup(StartupEventArgs eventArguments)
        {
            _navigationStore.CurrentViewModel = new CryptoCurrencyViewModel(_navigationStore, CreateCurrencySearchViewModel);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(eventArguments);
        }

        private CurrencySearchViewModel CreateCurrencySearchViewModel()
        {
            return new CurrencySearchViewModel(_navigationStore, CreateCryptoCurrencyViewModel);
        }

        private CryptoCurrencyViewModel CreateCryptoCurrencyViewModel()
        {
            return new CryptoCurrencyViewModel(_navigationStore, CreateCurrencySearchViewModel);
        }
    }
}
