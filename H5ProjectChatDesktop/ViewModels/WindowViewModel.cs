using H5ProjectChatDesktop.Models;
using System.Windows;
using System.ComponentModel;

namespace H5ProjectChatDesktop.ViewModels
{
    public class WindowViewModel : INotifyPropertyChanged
    {

        private Window myWindow;
        
        public ApplicationPage CurrntPage { get; set; } = ApplicationPage.Login;

        public WindowViewModel(Window window)
        {
            myWindow = window;
        }

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public void ChangeWindow(ApplicationPage page)
        {
            CurrntPage = page;
            OnPropertyChanged("CurrntPage");
        }
    }
}
