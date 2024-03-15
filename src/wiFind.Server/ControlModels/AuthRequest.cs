using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.AuthModels
{
    public class AuthRequest
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}
