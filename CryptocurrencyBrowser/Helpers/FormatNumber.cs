using CryptocurrencyBrowser.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptocurrencyBrowser.Helpers
{
    public class FormatNumber
    {
        public static string FancyFormat(double value)
        {
            var result = (long) value;

            if (result == 0)
            {
                return ConstantValues._informationUnavailableMessage;
            }

            result = MaximumThreeSignificantDigits(result);

            var resultPrefix = '$';

            if (result >= 1000000000)
            {
                return resultPrefix + (result / 1000000000D).ToString("0.##") + "B";
            }

            if (result >= 1000000)
            {
                return resultPrefix + (result / 1000000D).ToString("0.##") + "M";
            }
                
            if (result >= 1000)
            {
                return resultPrefix + (result / 1000D).ToString("0.##") + "K";
            }

            return resultPrefix + result.ToString("#,0");
        }

        public static string RoundDouble(double value)
        {
            if (value.Equals(0))
            {
                return ConstantValues._informationUnavailableMessage;
            }

            return Math.Round(value, 2).ToString() + "%";
        }

        public static long MaximumThreeSignificantDigits(long number)
        {
            var significantDigits = (int) Math.Log10(number);

            significantDigits = Math.Max(0, significantDigits - 2);

            var mostSignificantDigit = (int)Math.Pow(10, significantDigits);

            return number / mostSignificantDigit * mostSignificantDigit;
        }
    }
}
