using CryptocurrencyBrowser.Constants;
using CryptocurrencyBrowser.Helpers;
using CryptocurrencyBrowser.Services;
using CryptocurrencyBrowser.ViewModels;
using System;
using System.Windows;

namespace CryptocurrencyBrowser.Actions.CurrencyConvert
{
    public class SubmitConvert
    {
        public static async void Execute(ViewModelBase viewModel)
        {
            if (viewModel is not CurrencyConvertViewModel model)
            {
                return;
            }

            if (!IsFormValid(model))
            {
                return;
            }

            var result = string.Empty;

            try
            {
                var firstCoin = await new CryptoCurrencyService().FindCoinById(model.FromName!.ToLower().Replace(' ', '-'));

                var secondCoin = await new CryptoCurrencyService().FindCoinById(model.ToName!.ToLower().Replace(' ', '-'));

                var amount = (firstCoin!.PriceUsd! * model.FromAmount)/ secondCoin!.PriceUsd!;

                result += FormatNumber.RoundDouble(amount) + " " + model.ToName!;

                DisplayResult(model, result);
            } 
            catch
            {
                DisplayError(model, ConstantValues._coinDoesNotExistMessage);

                return;
            }
        }

        private static void DisplayResult(CurrencyConvertViewModel model, string result)
        {
            model.Result = result;

            model.ShowError = Visibility.Hidden;

            model.ErrorMessage = null;

            model.ShowResult = Visibility.Visible;
        }

        private static void DisplayError(CurrencyConvertViewModel model, string errorMessage)
        {
            model.ShowResult = Visibility.Hidden;

            model.ErrorMessage = errorMessage;

            model.ShowError = Visibility.Visible;
        }

        private static bool IsFormValid(CurrencyConvertViewModel model)
        {
            if (String.IsNullOrWhiteSpace(model.FromName))
            {
                DisplayError(model, ConstantValues._invalidFirstCoinMessage);

                return false;
            }

            if (model.FromAmount == null ||
                model.FromAmount <= 0)
            {
                DisplayError(model, ConstantValues._invalidFirstAmountMessage);

                return false;
            }

            if (model.FromAmount > ConstantValues._largestNumberAcceptable ||
                model.FromAmount < ConstantValues._smallestNumberAcceptable)
            {
                DisplayError(model, ConstantValues._amountExceedsAcceptable);

                return false;
            }

            if (String.IsNullOrWhiteSpace(model.ToName))
            {
                DisplayError(model, ConstantValues._invalidSecondCoinMessage);

                return false;
            }

            return true;
        }
    }
}
