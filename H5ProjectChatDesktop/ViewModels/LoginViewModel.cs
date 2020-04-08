using H5ProjectChatDesktop.Models;
using H5ProjectChatDesktop.Tools;
using H5ProjectChatDesktop.Views;
using System.Windows.Input;

namespace H5ProjectChatDesktop.ViewModels
{
    class LoginViewModel
    {
        private Login _Page; 
        public LoginViewModel(Login page)
        {
            _Page = page;
            _login = new UserController();
            LoginCommand = new LoginPageCommands(this);
            RegistraCommand = new LoginPageRegitraCommand(this);
        }

        private UserController _login;

        public UserController Login
        {
            get
            {
                return _login;
            }
        }

        public ICommand LoginCommand
        {
            get; private set;
        }

        public ICommand RegistraCommand
        {
            get; private set;
        }

        public void LoginCheck()
        {
            
            if(SingleTon.GetAPIAccess().Login(_login.Username, _Page.GetPassword(), _login.IP).Result)
            {
               MainWindow.WVM.ChangeWindow(ApplicationPage.Chat);
            }

        }

        public void OpenRegitrationPage()
        {
            MainWindow.WVM.ChangeWindow(ApplicationPage.Registra);
        }
    }
}
