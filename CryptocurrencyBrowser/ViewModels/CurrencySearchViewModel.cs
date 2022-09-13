using CryptocurrencyBrowser.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptocurrencyBrowser.ViewModels
{
    public class CurrencySearchViewModel : ViewModelBase
    {
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
                OnPropertyChanged(nameof(CoinName));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CurrencySearchViewModel()
        {
            SubmitCommand = new CurrencySearchSubmitCommand();
        }
    }
}
