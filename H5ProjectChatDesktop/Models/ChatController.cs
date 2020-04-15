using H5ProjectChatDesktop.Entities;
using H5ProjectChatDesktop.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5ProjectChatDesktop.Models
{
    class ChatController : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        public delegate void UpdateRTB();
        public static UpdateRTB Updater;

        public ChatController()
        {
            Updater = UpdateChatData;
        }

        private string _SendMessageText;

        public string SendMessageText
        {
            get
            {
                return _SendMessageText;
            }
            set
            {
                _SendMessageText = value;
                OnPropertyChanged("SendMessageText");
            }
        }

        public void UpdateChatData()
        {
            string text = "";
            foreach (ChatItem item in SingleTon.GetMessages())
            {
                text += item.PosterName + ": [" + item.postTime.ToString("hh:mm") +"]"+ "\n" + item.message + "\n";
            }
            ChatData = text;
        }

        private string _ChatData;
        public string ChatData
        {
            get 
            {
                return _ChatData;
            }
            set
            {
                _ChatData = value;
                OnPropertyChanged("ChatData");
            }
        }

    }
}
