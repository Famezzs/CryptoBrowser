using CryptocurrencyBrowser.ViewModels;
using System;
using System.Threading.Tasks;

namespace CryptocurrencyBrowser.Commands
{
    public class ViewCommand : BaseCommand
    {
        private readonly Action<ViewModelBase> _performAction;
        private readonly ViewModelBase _viewModel;

        public ViewCommand(Action<ViewModelBase> performCancel, ViewModelBase viewModel)
        {
            _performAction = performCancel;
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _performAction(_viewModel);
        }
    }
}
