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
        public static string FancyFormat(double? value)
        {
            if (value == null)
            {
                return ConstantValues._informationUnavailableMessage;
            }

            var resultPrefix = '$';
            
            if (value < 10)
            {
                return resultPrefix + Math.Round((double)value, 3).ToString();
            }

            var result = (long) value;

            result = MaximumThreeSignificantDigits(result);

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

        public static string RoundPercent(double? value)
        {
            if (value == null)
            {
                return ConstantValues._informationUnavailableMessage;
            }

            return Math.Round((double)value, 2).ToString() + "%";
        }

        public static string RoundDouble(double? value)
        {
            if (value == null)
            {
                return ConstantValues._informationUnavailableMessage;
            }

            return Math.Round((double)value, 2).ToString();
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
