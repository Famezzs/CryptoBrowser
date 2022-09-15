using CryptocurrencyBrowser.Constants;
using CryptocurrencyBrowser.Helpers;
using CryptocurrencyBrowser.Models;

namespace CryptocurrencyBrowser.ViewModels
{
    public class CryptoCurrencyBinder : ViewModelBase
    {
        private readonly CryptoCurrency _cryptoCurrency;

        public string Coin => _cryptoCurrency.Name ?? ConstantValues._informationUnavailableMessage;
        public string Price => FormatNumber.FancyFormat(_cryptoCurrency.PriceUsd ?? 0);
        public string ChangePercent24Hr => FormatNumber.RoundPercent(_cryptoCurrency.ChangePercent24Hr ?? 0);
        public string VolumeUsd24Hr => FormatNumber.FancyFormat(_cryptoCurrency.VolumeUsd24Hr ?? 0);

        public CryptoCurrencyBinder(CryptoCurrency cryptoCurrency)
        {
            _cryptoCurrency = cryptoCurrency;
        }
    }
}
