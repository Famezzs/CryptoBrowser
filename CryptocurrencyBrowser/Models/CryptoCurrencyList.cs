using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

using CryptocurrencyBrowser.Constants;
using CryptocurrencyBrowser.ViewModels;

using Newtonsoft.Json;

namespace CryptocurrencyBrowser.Models
{
    public class CryptoCurrencyList
    {
        public CryptoCurrency[] Data { get; set; } = Array.Empty<CryptoCurrency>();
    }
}
