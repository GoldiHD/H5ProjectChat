﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H5ProjectChatPWAMobile.Client.Entities
{
    public class UserItem
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime lastLogin { get; set; }
    }
}
