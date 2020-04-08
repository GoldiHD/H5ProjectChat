using H5ProjectChatDesktop.ViewModels;
using System.Windows.Controls;

namespace H5ProjectChatDesktop.Views
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
            DataContext = new RegistrationViewModel(this);
        }
    }
}
