using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H5ProjectChatAPI
{
    public class ChatItem
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string message { get; set; }
        public DateTime postTime { get; set; }
    }
}
