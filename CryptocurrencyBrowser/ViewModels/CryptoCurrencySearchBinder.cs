using CryptocurrencyBrowser.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyBrowser.ViewModels
{
    public class CryptoCurrencySearchBinder : ViewModelBase
    {
        public CryptoCurrencyBinder CryptoCurrency { get; }
        public ObservableCollection<CryptoMarketBinder> CryptoMarkets { get; } = new();

        public CryptoCurrencySearchBinder(CryptoCurrency cryptoCurrency, CryptoMarket[] cryptoMarkets)
        {
            CryptoCurrency = new CryptoCurrencyBinder(cryptoCurrency);
            
            foreach (var market in cryptoMarkets)
            {
                CryptoMarkets.Add(new CryptoMarketBinder(market));
            }
        }
    }
}
