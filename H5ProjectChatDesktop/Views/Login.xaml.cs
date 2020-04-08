using H5ProjectChatDesktop.ViewModels;
using System.Windows.Controls;

namespace H5ProjectChatDesktop.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            this.DataContext = new LoginViewModel(this);
        }

        public string GetPassword()
        {
            return PBPassword.Password;
        }
    }
}
