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
        public string Price => FormatNumber.FancyFormat(_cryptoMarket.PriceUsd ?? 0);
        public string VolumeUsd24Hr => FormatNumber.FancyFormat(_cryptoMarket.VolumeUsd24Hr ?? 0);
        public string VolumePercent => FormatNumber.RoundDouble(_cryptoMarket.VolumePercent ?? 0);

        public CryptoMarketBinder(CryptoMarket cryptoMarket)
        {
            _cryptoMarket = cryptoMarket;
        }
    }
}
