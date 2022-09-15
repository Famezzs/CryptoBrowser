using CryptocurrencyBrowser.Commands;
using CryptocurrencyBrowser.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CryptocurrencyBrowser.ViewModels
{
    public class CurrencyConvertViewModel : ViewModelBase
    {
        private string? _fromName;
        public string? FromName
        {
            get => _fromName;
            set
            {
                _fromName = value;
                OnPropertyChanged(nameof(FromName));
            }
        }

        private double _fromAmount;
        public double FromAmount
        {
            get => _fromAmount;
            set
            {
                _fromAmount = value;
                OnPropertyChanged(nameof(FromAmount));
            }
        }

        private string? _toName;
        public string? ToName
        {
            get => _toName;
            set
            {
                _toName = value;
                OnPropertyChanged(nameof(ToName));
            }
        }

        private double _toAmout;
        private double ToAmount
        {
            get => _toAmout;
            set
            {
                _toAmout = value;
                OnPropertyChanged(nameof(ToAmount));
            }
        }

        private Visibility _showResult = Visibility.Hidden;
        public Visibility ShowResult
        {
            get => _showResult;
            set
            {
                _showResult = value;
                OnPropertyChanged(nameof(ShowResult));
            }
        }

        private Visibility _showError = Visibility.Hidden;
        public Visibility ShowError
        {
            get => _showError;
            set
            {
                _showError = value;
                OnPropertyChanged(nameof(ShowError));
            }
        }

        public ICommand SubmitCommand;
        public ICommand CancelCommand;
        public ICommand GoBackCommand;

        public CurrencyConvertViewModel(NavigationStore navigationStore, Func<CurrencyViewModel> createViewModel)
        {
            GoBackCommand = new RedirectCommand(navigationStore, createViewModel);
        }
    }
}
