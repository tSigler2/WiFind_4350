using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.ControlModels
{
    public class CartDTO
    {
        [Required]
        public IList<string> wifis_id_in_cart { get; set; }
    }
}
