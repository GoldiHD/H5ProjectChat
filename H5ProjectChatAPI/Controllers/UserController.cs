using System;
using H5ProjectChatAPI.Tools;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace H5ProjectChatAPI.Controllers
{
    [Route("api/User/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserHandler UH = new UserHandler();

        // GET: api/User/
        [HttpPost()]
        [Route("Login")]
        public ActionResult<UserItem> Login([FromBody] UserItem value)
        {
            UserItem user = UH.GetUserByCreditals(value.Username, value.Password);
            if (user != null)
            {
                Claim[] claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
                };
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.Secret));
                string algorithm = SecurityAlgorithms.HmacSha256;

                SigningCredentials signingcreadentials = new SigningCredentials(key, algorithm);

                JwtSecurityToken token = new JwtSecurityToken(
                    Constants.Issuer,
                    Constants.Audiance,
                    claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddHours(2),
                    signingcreadentials
                    );


                var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new UserItem() { Token = tokenJson });
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("create")]
        public IActionResult CreateUser([FromBody] UserItem value)
        {
            if (UH.CreateUser(value))
            {
                return Ok();
            }
            return Forbid();
        }
    }
}
