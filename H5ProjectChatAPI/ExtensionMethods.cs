using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H5ProjectChatAPI
{
    public static class ExtensionMethods
    {
        public static IEnumerable<UserItem> WithoutPasswords(this IEnumerable<UserItem> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static UserItem WithoutPassword(this UserItem user)
        {
            user.Password = null;
            return user;
        }
    }
}
