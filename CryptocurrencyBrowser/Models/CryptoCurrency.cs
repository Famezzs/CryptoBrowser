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
        public string Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public decimal VolumeUsd24h { get; }
        public double ChangePercent24h { get; }
            
        public CryptoCurrency(string id, string name, decimal price, decimal volumeUsd24h, double changePercent24h)
        {
            Id = id;
            Name = name;
            Price = price;
            VolumeUsd24h = volumeUsd24h;
            ChangePercent24h = changePercent24h;
        }
    }
}
