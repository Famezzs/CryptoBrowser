using CryptocurrencyBrowser.Stores;
using CryptocurrencyBrowser.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyBrowser.Commands
{
    public class CurrencySearchRedirectCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public CurrencySearchRedirectCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new CurrencySearchViewModel();
        }
    }
}
