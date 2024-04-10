using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.ControlModels
{
    public class UsernameInput
    {
        [Required]
        public string Username { get; set;}
    }
}
