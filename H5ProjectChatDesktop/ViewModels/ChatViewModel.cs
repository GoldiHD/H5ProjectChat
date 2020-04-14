using H5ProjectChatDesktop.Models;
using H5ProjectChatDesktop.Tools;
using H5ProjectChatDesktop.ViewModels.Commands;
using H5ProjectChatDesktop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace H5ProjectChatDesktop.ViewModels
{
    class ChatViewModel
    {
        private Chat _Page;

        public ChatViewModel(Chat page)
        {
            _Page = page;
            SendMessageText = new ChatCommandSendMessage(this);
            Logout = new ChatLogoutCommand(this);
            _ChatControl = new ChatController();
        }

        private ChatController _ChatControl;

        public ChatController ChatControl
        {
            get
            {
                return _ChatControl;
            }
        }

        public ICommand SendMessageText
        {
            get; private set;
        }

        public ICommand Logout
        {
            get; private set;
        }

        public void SendMessage()
        {
            if (_ChatControl.SendMessageText != "")
            {
                SingleTon.GetAPIAccess().PostMessage(new Entities.ChatItem() { message = _ChatControl.SendMessageText, PosterName = SingleTon.GetUser().Username });
                _ChatControl.SendMessageText = "";
            }
        }

        public void LogOutMethod()
        {
            SingleTon.SetUser(null);
            SingleTon.GetMessageThreadUpdater().Suspend();
            MainWindow.WVM.ChangeWindow(ApplicationPage.Login);
        }
    }
}
