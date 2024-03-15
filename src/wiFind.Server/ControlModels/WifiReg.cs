using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.ControlModels
{
    public class WifiReg
    {
        [Required, MaxLength(50)]
        public string wifi_name { get; set; } = "My Wifi";

        [Required, MaxLength(100)]
        public string security { get; set; } = "Unknown";

        [Required]
        public float wifi_latitude { get; set; }

        [Required]
        public float wifi_longitude { get; set; }

        [Required]
        public float radius { get; set; }

        [Required, MaxLength(50)]
        public string wifi_source { get; set; } = "Unknown";

        [Required]
        public string owned_by { get; set; }

        [Required, Range(1, 250)]
        public int max_users { get; set; }
    }
}
