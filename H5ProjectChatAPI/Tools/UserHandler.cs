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
                if(element.Username == username && BCrypt.Net.BCrypt.Verify(password, element.Password))
                {
                    return element;
                }
            }
            return null;
        }

        public bool CreateUser(UserItem user)
        {
            if (!access.AccessUser().Exists(x => x.Username == user.Username))
            {
                access.CreateUser(user);
                return true;
            }
            return false;
        }
    }
}
