using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyBrowser.Constants
{
    public class ConstantValues
    {
        public static readonly string _coinRequestUrl = "https://api.coincap.io/v2/assets?limit=10";
        public static readonly string _assetSearchUrl = "https://api.coincap.io/v2/assets/";
        public static readonly string _marketSearchSubUrl = "/markets?limit=3";
    }
}
