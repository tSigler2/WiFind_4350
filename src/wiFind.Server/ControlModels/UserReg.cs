using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace wiFind.Server.AuthModels
{
    public class UserReg
    {
        [Required, Key, MaxLength(50)]
        public string username { get; set; }

        [Required, DataType(DataType.EmailAddress), MaxLength(200)]
        public string email { get; set; }

        [Required, DataType(DataType.Password)]
        public string password { get; set; }

        [Required, MaxLength(100)]
        public string first_name { get; set; } = "";

        [Required, MaxLength(100)]
        public string last_name { get; set; } = "";

        // date of birth
        [Required, DataType(DataType.Date)]
        public DateOnly dob { get; set; }

        [Required, DataType(DataType.PhoneNumber), MaxLength(20)]
        public string phone_number { get; set; } = "";
    }
}
