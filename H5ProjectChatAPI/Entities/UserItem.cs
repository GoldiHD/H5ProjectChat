﻿using System;

namespace H5ProjectChatAPI
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
