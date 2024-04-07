using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace wiFind.Server.ControlModels
{
    public class RentReg
    {   
        [Required]
        public int rentID { get; set; }

        [Required]
        public string? userID { get; set; }

        [Required]
        public User user { get; set; }

        [Required]
        public string wifiID { get; set; }

        [Required]
        public Wifi wifi { get; set; }

        [Required]
        public DateTime start { get; set; }

        [Required]
        public DateTime end { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal locked_rate {  get; set; }

        // Renter is accountable for making guest account on renter's wifi.
        [DataType(DataType.Password), MaxLength(70)]
        public string? guest_password {  get; set; }
    }
}