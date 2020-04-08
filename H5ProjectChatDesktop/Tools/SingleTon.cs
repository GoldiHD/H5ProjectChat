using H5ProjectChatDesktop.Tools;
using H5ProjectChatDesktop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5ProjectChatDesktop.Tools
{
    class SingleTon
    {
        private static UserItem userInstance;
        private static APIMessenger APIMessengerInstance;
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
    }
}
