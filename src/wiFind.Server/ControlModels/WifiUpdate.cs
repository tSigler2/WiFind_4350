using System.ComponentModel.DataAnnotations;
namespace wiFind.Server.ControlModels
{
    public class WifiUpdate
    {
        // Do not let user update this attribute
        [Required]
        public string wifi_id { get; set; }

        [Required, MaxLength(50)]
        public string wifi_name { get; set; } = "My Wifi";

        [Required, MaxLength(100)]
        public string security { get; set; } = "Unknown";

        [Required, System.ComponentModel.DataAnnotations.RangeAttribute(1, 1000)]
        public int download_speed { get; set; } = 1;

        [Required, System.ComponentModel.DataAnnotations.RangeAttribute(1, 1000)]
        public int upload_speed { get; set; } = 1;

        [Required]
        public float wifi_latitude { get; set; }

        [Required]
        public float wifi_longitude { get; set; }

        [Required]
        public float radius { get; set; }

        [Required, MaxLength(50)]
        public string wifi_source { get; set; } = "Unknown";

        [Required, DataType(DataType.Currency)]
        public decimal curr_rate { get; set; } = 0.0M;

        // Do not let user update this attribute
        [Required]
        public DateTime time_listed { get; set; }

        // Do not let user update this attribute
        [Required]
        public string owned_by { get; set; }

        [Required, System.ComponentModel.DataAnnotations.RangeAttribute(1, 250)]
        public int max_users { get; set; }
    }
}
