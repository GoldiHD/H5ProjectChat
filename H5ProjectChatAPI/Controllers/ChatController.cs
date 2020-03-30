using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            return Ok();
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
    }
}
