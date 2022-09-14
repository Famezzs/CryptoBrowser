using CryptocurrencyBrowser.Commands;
using CryptocurrencyBrowser.Models;
using System.Windows.Input;

namespace CryptocurrencyBrowser.ViewModels
{
    public class CurrencySearchViewModel : ViewModelBase
    {
        public CryptoCurrencySearch? SearchResult { get; set; }

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

        public CurrencySearchSubmitCommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public CurrencySearchViewModel()
        {
            SubmitCommand = new CurrencySearchSubmitCommand(this);
        }
    }
}
