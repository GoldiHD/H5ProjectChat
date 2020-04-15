using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using H5ProjectChatDesktop.Models;
using H5ProjectChatDesktop.Tools;
using H5ProjectChatDesktop.ViewModels.Commands;
using H5ProjectChatDesktop.Views;

namespace H5ProjectChatDesktop.ViewModels
{
    class RegistrationViewModel
    {
        private Registration _page;

        public RegistrationViewModel(Registration page)
        {
            _page = page;
            _reg = new RegistrationController();
            BackCommand = new RegistrationBackCommand(this);
            CreateAccountCommand = new RegistrationCreateAccountCommand(this);
        }

        private RegistrationController _reg;

        public RegistrationController Reg
        {
            get
            {
                return _reg;
            }
        }

        public ICommand BackCommand
        {
            get; private set;
        }

        public ICommand CreateAccountCommand
        {
            get; private set;
        }

        public void OpenLoginPage()
        {
            MainWindow.WVM.ChangeWindow(ApplicationPage.Login);
        }

        public void CreateAccount()
        {
            if(SingleTon.GetAPIAccess().CreateAccount(_reg.Username, _reg.Password, _reg.IP).Result)
            {
                //say something if it succeds or fails
                //throw new NotImplementedException();
            }
        }
    }
}
