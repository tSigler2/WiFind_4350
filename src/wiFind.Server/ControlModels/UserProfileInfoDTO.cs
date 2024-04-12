using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.ControlModels
{
    public class UserProfileInfoDTO
    {
        [Required]
        public string first_name {  get; set; }
        [Required]
        public string last_name { get; set;}
        [Required]
        public string phone_number { get; set; }
    }
}
