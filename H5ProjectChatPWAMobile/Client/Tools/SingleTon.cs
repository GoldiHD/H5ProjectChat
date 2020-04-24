using H5ProjectChatPWAMobile.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H5ProjectChatPWAMobile.Client.Tools
{
    public class SingleTon
    {
        private static APIAccess APIAccessInstance;
        private static UserItem userInstance;
        public static void SetUser(UserItem user)
        {
            userInstance = user;
        }


        public static UserItem GetUser()
        {
            return userInstance;
        }

        public static APIAccess GetAPIAccess()
        {
            if (APIAccessInstance == null)
            {
                APIAccessInstance = new APIAccess();
            }
            return APIAccessInstance;
        }
    }
}
