using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace H5ProjectChatDesktop.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private MainWindow _window;
        public Login()
        {
            InitializeComponent();
            _window = (MainWindow)Application.Current.MainWindow;
            if(_window != null)
            {
                _window.Width = 540;
                _window.Height = 420;
                _window.MinHeight = 540;
                _window.MinWidth = 420;
                _window.MaxHeight = 540;
                _window.MaxWidth = 420;
            }
        }
    }
}
