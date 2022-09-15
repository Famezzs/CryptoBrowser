﻿using CryptocurrencyBrowser.Stores;
using CryptocurrencyBrowser.ViewModels;
using System;

namespace CryptocurrencyBrowser.Commands
{
    public class RedirectCommand : BaseCommand
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _createViewModel;

        public RedirectCommand(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
