using CryptocurrencyBrowser.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptocurrencyBrowser.Actions.CurrencyConvert
{
    public class CancelConvert
    {
        public static void Execute(ViewModelBase viewModel)
        {
            if (viewModel is CurrencyConvertViewModel model)
            {
                model.ShowResult = Visibility.Hidden;

                model.ShowError = Visibility.Hidden;

                model.ErrorMessage = string.Empty;
            }
        }
    }
}
