using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace wiFind.Server.ControlModels
{

    public class Cart
    {
        [Required]
        public List<string> cart { get; set; }
    }

}