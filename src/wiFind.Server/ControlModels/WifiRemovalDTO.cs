using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.ControlModels
{
    public class WifiRemovalDTO
    {
        [Required]
        public string wifi_id {  get; set; }
    }
}
