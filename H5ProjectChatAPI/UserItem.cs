using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H5ProjectChatAPI
{
    public class UserItem
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime lastLogin { get; set; }
    }
}
