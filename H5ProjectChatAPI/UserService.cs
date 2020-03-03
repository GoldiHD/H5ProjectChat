using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace H5ProjectChatAPI
{
    public interface IUserService
    {
        UserItem Authenticate(string username, string password);
        IEnumerable<UserItem> GetAll();
    }

    public class UserService : IUserService
    {
        private List<UserItem> _users;


        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _users = new SQLiteAccess().AccessUser();
            _appSettings = appSettings.Value;
        }

        public UserItem Authenticate(string username, string password)
        {
            UserItem user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            if(user == null)
            {
                return null;
            }

            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = TokenHandler.CreateToken(tokenDescriptor);
            user.Token = TokenHandler.WriteToken(token);
            return user.WithoutPassword();


        }

        public IEnumerable<UserItem> GetAll()
        {
            return _users.WithoutPasswords();
        }
    }
}
