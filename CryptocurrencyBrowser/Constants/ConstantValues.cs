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
        public static readonly string _informationUnavailableMessage = "Unavailable";
        public static readonly string _connectionErrorMessage = "Unable to retrieve any information. Please verify your Internet connection before proceeding.";
        public static readonly string _invalidFirstAmountMessage = "First amount provided is invalid.";
        public static readonly string _invalidFirstCoinMessage = "Unable to retrieve information about first coin specified.";
        public static readonly string _invalidSecondAmountMessage = "Second amount provided is invalid.";
        public static readonly string _invalidSecondCoinMessage = "Unable to retrieve information about second coin specified.";
    }
}
