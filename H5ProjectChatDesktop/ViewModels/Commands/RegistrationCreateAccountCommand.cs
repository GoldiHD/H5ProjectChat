using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace H5ProjectChatDesktop.ViewModels.Commands
{
    class RegistrationCreateAccountCommand : ICommand
    {
        private RegistrationViewModel viewModel;

        public RegistrationCreateAccountCommand(RegistrationViewModel model)
        {
            viewModel = model;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.CreateAccount();
        }
    }
}
