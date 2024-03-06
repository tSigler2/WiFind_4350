using System;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using wiFind.Server;

namespace wiFind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly WiFindContext server;

        public TicketController(WiFindContext s)
        {
            server = s;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitTicket(Ticket ticket)
        {
            if(!ModelState.IsValid) return BadRequest("Invalid Ticket Submission");

            ticket.UniqueIdentifier = Guid.NewGuid().ToString();

            ticket.Status = TicketStatus.Open;
            ticket.TimeStamp = DateTime.UtcNow;

            server.Tickets.Add(ticket);
            await server.SaveChangesAsync();

            return Ok(new { ticketId = ticket.UniqueIdentifier});
        }

        private void SendEmailConfirmation(Ticket ticket)
        {

        }
    }

}