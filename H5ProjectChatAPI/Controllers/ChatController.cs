﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace H5ProjectChatAPI.Controllers
{
    [Authorize]
    [Route("api/ChatController")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<string>> Get(int id)
        {
            return Ok(DummyData);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        private static List<string> DummyData = new List<string>()
        {
            new string("Test1"),
            new string("Test2"),
            new string("Test3"),
            new string("Test4"),
            new string("Test5")
        };

    }
}