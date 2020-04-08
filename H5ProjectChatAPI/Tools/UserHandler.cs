using System.Collections.Generic;

namespace H5ProjectChatAPI.Tools
{
    public class UserHandler
    {
        private SQLiteAccess access = SingleTon.GetSQL();
        public UserItem GetUserByCreditals(string username, string password)
        {
            List<UserItem> users = access.AccessUser();
            foreach( UserItem element in users)
            {
                if(element.Username == username && element.Password == password)
                {
                    return element;
                }
            }
            return null;
        }

        public void CreateUser(UserItem user)
        {
            access.CreateUser(user);
        }
    }
}
