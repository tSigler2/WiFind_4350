using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.ControlModels
{
    public class AddPaymentInfoDTO
    {
        [Required]
        public string payment_type { get; set; }
        [Required]
        public string name_on_card { get; set; }
        [Required]
        public string card_number { get; set; }
        [Required]
        public string exp_date { get; set; }
    }
}
