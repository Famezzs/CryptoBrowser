using System;
using System.Windows;
using System.Windows.Input;

using CryptocurrencyBrowser.Actions.CurrencyConvert;
using CryptocurrencyBrowser.Commands;
using CryptocurrencyBrowser.Stores;

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

        private double? _fromAmount;
        public double? FromAmount
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

        private string? _result;
        public string? Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
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

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand GoBackCommand { get; }

        public CurrencyConvertViewModel(NavigationStore navigationStore, Func<CurrencyViewModel> createViewModel)
        {
            SubmitCommand = new ViewCommand(SubmitConvert.Execute, this);

            CancelCommand = new ViewCommand(CancelConvert.Execute, this);

            GoBackCommand = new RedirectCommand(navigationStore, createViewModel);
        }
    }
}
