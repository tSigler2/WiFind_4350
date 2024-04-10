using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.AuthModels
{
    public class AuthRequest
    {
        public AuthRequest(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}
