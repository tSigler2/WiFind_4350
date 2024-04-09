using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace wiFind.Server.ControlModels
{
    // use this later for Get request for listings of rented wifi
    // customers should see multiple wifi's for the same user id, sellers should see multiple users for one wifi id
    public class RentDTO
    {   
        [Required]
        public string rentID { get; set; }

        [Required]
        public string? userID { get; set; }

        [Required]
        public string wifiID { get; set; }

        [Required]
        public DateTime start { get; set; }

        public DateTime? end { get; set; }

        [Required, DataType(DataType.Currency)]
        public decimal locked_rate {  get; set; }

        // Renter is accountable for making guest account on renter's wifi.
        // Currently, attribute is not in use
        [DataType(DataType.Password), MaxLength(70)]
        public string? guest_password {  get; set; }
    }
}