using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyBrowser.Models
{
    public class CryptoCurrency
    {
        public String? Id { get; set; }
        public Int16? Rank { get; set; }
        public String? Name { get; set; }
        public Double? Supply { get; set; }
        public Double? MaxSupply { get; set; }
        public Double? MarketCapUsd { get; set; }
        public Double? VolumeUsd24Hr { get; set; }
        public Double? PriceUsd { get; set; }
        public Double? ChangePercent24Hr { get; set; }
        public Double? Vwap24Hr { get; set; }
        public String? Explorer { get; set; }
    }
}
