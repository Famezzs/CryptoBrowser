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
        public static readonly string _invalidFirstCoinMessage = "First coin name provided is invalid.";
        public static readonly string _invalidSecondCoinMessage = "Second coin name provided is invalid.";
        public static readonly string _coinDoesNotExistMessage = "No information is available about coin/coins specified.";
        public static readonly double _smallestNumberForRounding = 0.0001;
        public static readonly double _largestNumberBeforeRounding = 1000;
        public static readonly double _largestNumberAcceptable = 1000000;
        public static readonly double _smallestNumberAcceptable = 0.00001;
        public static readonly string _amountExceedsAcceptable = $"Amount should be less than {_largestNumberAcceptable} and more than {_smallestNumberAcceptable}";
    }
}
