using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using wiFind.Server.ControlModels.WifiReg;

namespace wiFind.Server.ControlModels
{

    class Cart
    {
        [Required]
        public List<string> cart { get; set; }
    }

}