using CryptocurrencyBrowser.Helpers;
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
        public string Price => FormatNumber.FancyFormat(_cryptoMarket.PriceUsd);
        public string VolumeUsd24Hr => FormatNumber.FancyFormat(_cryptoMarket.VolumeUsd24Hr);
        public string VolumePercent => FormatNumber.RoundPercent(_cryptoMarket.VolumePercent);

        public CryptoMarketBinder(CryptoMarket cryptoMarket)
        {
            _cryptoMarket = cryptoMarket;
        }
    }
}
