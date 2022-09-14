using CryptocurrencyBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyBrowser.ViewModels
{
    public class CryptoMarketBinder : ViewModelBase
    {
        private readonly CryptoMarket _cryptoMarket;

        public string ExchangeName => _cryptoMarket.ExchangeId ?? string.Empty;
        public string Price => "$" + _cryptoMarket.PriceUsd ?? string.Empty;
        public string VolumeUsd24Hr => "$" + _cryptoMarket.VolumeUsd24Hr ?? string.Empty;
        public string VolumePercent => _cryptoMarket.VolumePercent + "%" ?? string.Empty;

        public CryptoMarketBinder(CryptoMarket cryptoMarket)
        {
            _cryptoMarket = cryptoMarket;
        }
    }
}
