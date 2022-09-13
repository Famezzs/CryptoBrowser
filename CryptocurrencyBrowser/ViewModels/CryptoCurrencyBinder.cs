using CryptocurrencyBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyBrowser.ViewModels
{
    public class CryptoCurrencyBinder : ViewModelBase
    {
        private readonly CryptoCurrency _cryptoCurrency;

        public string Coin => _cryptoCurrency.Name ?? string.Empty;
        public string Price => "$" + _cryptoCurrency.PriceUsd ?? string.Empty;
        public string ChangePercent24Hr => _cryptoCurrency.ChangePercent24Hr + "%" ?? string.Empty;
        public string VolumeUsd24Hr => "$" + _cryptoCurrency.VolumeUsd24Hr ?? string.Empty;

        public CryptoCurrencyBinder(CryptoCurrency cryptoCurrency)
        {
            _cryptoCurrency = cryptoCurrency;
        }
    }
}
