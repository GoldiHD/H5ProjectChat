using System.ComponentModel;

namespace H5ProjectChatDesktop.Models
{
    class UserController : INotifyPropertyChanged
    {
        private string _IP;
        public string IP
        {
            get
            {
                return _IP;
            }
            set
            {
                _IP = value;
                OnPropertyChanged("IP");
            }
        }

        private string _Username;

        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
                OnPropertyChanged("Username");
            }
        }

        private string _Password;

        public string Password
        {
            get
            {
                return _Password; 
            }
            set
            {
                _Password = value;
                OnPropertyChanged("Password");
            }
        }




        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}