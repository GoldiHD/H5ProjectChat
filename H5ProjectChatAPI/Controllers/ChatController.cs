using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace H5ProjectChatAPI.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        // GET: api/Chat/5
        [HttpGet]
        public ActionResult<List<string>> Get(int id)
        {
            return Ok(DummyData);
        }

        // POST: api/Chat
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
