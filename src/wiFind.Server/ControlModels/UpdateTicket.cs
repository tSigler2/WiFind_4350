using System.ComponentModel.DataAnnotations;

namespace wiFind.Server.ControlModels
{
    public class UpdateTicket
    {
        [Required]
        public string ticket_id { get; set; }
        [Required]
        public TicketStatus ticketStatus { get; set; }
        [Required]
        public string assigned_to { get; set; }
    }
}
