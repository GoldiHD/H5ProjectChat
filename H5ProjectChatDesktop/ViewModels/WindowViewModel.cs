using H5ProjectChatDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace H5ProjectChatDesktop.ViewModels
{
    class WindowViewModel : BaseViewModel
    {

        private Window myWindow;
        
        public ApplicationPage CurrntPage { get; set; } = ApplicationPage.Login;


        public WindowViewModel(Window window)
        {
            myWindow = window;
        }
    }
}
