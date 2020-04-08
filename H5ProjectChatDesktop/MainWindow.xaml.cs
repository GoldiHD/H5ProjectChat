using H5ProjectChatDesktop.ViewModels;
using System.Windows;

namespace H5ProjectChatDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static WindowViewModel WVM;
        public MainWindow()
        {
            InitializeComponent();

            WVM = new WindowViewModel(this);
            this.DataContext = WVM;
        }
    }
}
