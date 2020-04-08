using System.Collections.Generic;
using H5ProjectChatAPI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace H5ProjectChatAPI.Controllers
{
    [Authorize]
    [Route("api/Chat")]
    //[ApiController]
    public class ChatController : ControllerBase
    {
        MessageHandler MH = new MessageHandler();

        [HttpGet]
        public ActionResult<List<ChatItem>> GetMessages([FromBody] int lastId, [FromBody] int amount)
        {
            return MH.LoadMessages(lastId, amount);
        }

        [HttpPost]
        public IActionResult PostMessage([FromBody] ChatItem value)
        {
            MH.AddMessage(value);
            return Ok();
        }

        public ActionResult<int> CheckLatestMessageId()
        {
            return MH.LastID();
        }
    }
}
