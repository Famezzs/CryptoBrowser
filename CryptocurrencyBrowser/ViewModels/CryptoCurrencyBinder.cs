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
        public double Price => _cryptoCurrency.PriceUsd ?? 0;
        public double ChangePercent24Hr => _cryptoCurrency.ChangePercent24Hr ?? 0;
        public double VolumeUsd24Hr => _cryptoCurrency.VolumeUsd24Hr ?? 0;

        public CryptoCurrencyBinder(CryptoCurrency cryptoCurrency)
        {
            _cryptoCurrency = cryptoCurrency;
        }
    }
}
