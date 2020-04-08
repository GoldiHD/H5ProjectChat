using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5ProjectChatDesktop.Entities
{
    class ChatItem
    {
        public int id { get; set; }
        public string PosterName { get; set; }
        public string message { get; set; }
        public DateTime postTime { get; set; }

    }
}
