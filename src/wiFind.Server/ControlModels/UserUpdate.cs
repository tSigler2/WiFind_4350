using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.ControlModels
{
    // Unchanged User Info should be sent as well on client side
    public class UserUpdate
    {
        [Required]
        public string user_id { get; set; }

        [Required, MaxLength(100)]
        public string first_name { get; set; }

        [Required, MaxLength(100)]
        public string last_name { get; set; }

        [Required, DataType(DataType.PhoneNumber), MaxLength(20)]
        public string phone_number { get; set; }

    }
}
