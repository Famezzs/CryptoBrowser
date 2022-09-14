using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyBrowser.Models
{
    public class CryptoMarket
    {
        public String? ExchangeId { get; set; }
        public String? BaseId { get; set; }
        public String? QuoteId { get; set; }
        public String? BaseSymbol { get; set; }
        public String? QuoteSymbol { get; set; }
        public Double? VolumeUsd24Hr { get; set; }
        public Double? PriceUsd { get; set; }
        public Double? VolumePercent { get; set; }
    }
}
