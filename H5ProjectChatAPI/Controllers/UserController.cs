using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H5ProjectChatAPI.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace H5ProjectChatAPI.Controllers
{
    [Route("api/UserController")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserHandler UH = new UserHandler();

        // GET: api/UserController/
        [HttpGet()]
        public bool Login(string username, string password)
        {
            UserItem user = UH.GetUserByCreditals(username, password);
            if (user != null)
            {
                Claim[] claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

                JwtSecurityToken token = new JwtSecurityToken();
                return true;
            }
            else 
            {
                return false;
            }
        }

        
        [HttpPost]
        public void CreateUser([FromBody] UserItem value)
        {
            UH.CreateUser(value);
        }
    }
}
