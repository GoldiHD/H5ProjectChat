using H5ProjectChatDesktop.Tools;
using H5ProjectChatDesktop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace H5ProjectChatDesktop.Tools
{
    class SingleTon
    {
        private static UserItem userInstance;
        private static APIMessenger APIMessengerInstance;
        private static Thread MessageThreadInstance;
        private static List<ChatItem> MessagesInstance;
        private static Object Key;
        public static void SetUser(UserItem user)
        {
            userInstance = user;
        }


        public static UserItem GetUser()
        {
            return userInstance;
        }

        public static APIMessenger GetAPIAccess()
        {
            if (APIMessengerInstance == null)
            {
                APIMessengerInstance = new APIMessenger();
            }
            return APIMessengerInstance;
        }

        public static Thread GetMessageThreadUpdater()
        {
            if(MessageThreadInstance == null)
            {
                MessageThreadInstance = new Thread(new ThreadStart(new MessageUpdater().MessageUpdaterStart));
            }
            return MessageThreadInstance;
        }

        public static List<ChatItem> GetMessages()
        {
            if(Key ==null)
            {
                Key = new object();
            }

            lock (Key)
            {
                if (MessagesInstance == null)
                {
                    MessagesInstance = new List<ChatItem>();
                }

                return MessagesInstance;
            }
        }
    }
}
