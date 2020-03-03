using System.ComponentModel.DataAnnotations;

namespace H5ProjectChatAPI
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
