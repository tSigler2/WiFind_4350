using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.ControlModels
{
    public class SupportTicketReg
    {
        [Required]
        public string username { get; set; }

        [Required, MaxLength(50)]
        public string subject { get; set; }

        [Required, MaxLength(500)]
        public string description { get; set; }
    }
}
