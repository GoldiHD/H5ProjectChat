using System;
using System.Collections.Generic;
using H5ProjectChatAPI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace H5ProjectChatAPI.Controllers
{
    [Authorize]
    [Route("api/Chat/")]
    //[ApiController]
    public class ChatController : ControllerBase
    {
        MessageHandler MH = new MessageHandler();

        [HttpPost]
        [Route("GetMessages")]
        public ActionResult<List<ChatItem>> GetMessages([FromBody] ChatItem lastId)
        {
            return MH.LoadMessages(lastId.id, 30);
        }

        [HttpPost]
        [Route("PostMessages")]
        public IActionResult PostMessage([FromBody] ChatItem value)
        {
            value.postTime = DateTime.Now;
            MH.AddMessage(value);
            return Ok();
        }

        [HttpGet]
        [Route("GetMessagesLastID")]
        public ActionResult<int> CheckLatestMessageId()
        {
            int id = MH.LastID();
            return id;
        }
    }
}
