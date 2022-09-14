using CryptocurrencyBrowser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyBrowser.ViewModels
{
    public class CryptoCurrencyViewModel : ViewModelBase
    {
        private readonly ObservableCollection<CryptoCurrencyBinder> _cryptoCurrency;

        public IEnumerable<CryptoCurrencyBinder> CryptoCurrencies => _cryptoCurrency;

        public CryptoCurrencyViewModel()
        {
            try
            {
                _cryptoCurrency = CryptoCurrencyList.GetTopTenCurrency();
            }
            catch
            {
                _cryptoCurrency = new();
            }
        }
    }
}
