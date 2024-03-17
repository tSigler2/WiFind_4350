using System;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wiFind.Server.ControlModels;

namespace wiFind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketController : ControllerBase
    {
        private readonly WiFindContext _wifFindContext;

        public SupportTicketController(WiFindContext wifFindContext)
        {
            _wifFindContext = wifFindContext;
        }

        // Gets all tickets, only used by admins
        // TODO: Admin token validation
        [HttpGet("alltickets")]
        public async Task<IActionResult> GetTickets()
        {
            var ticketList = await _wifFindContext.SupportTickets.ToListAsync();
            return Ok(ticketList);
        }

        [Authorize]
        [HttpPost("submitticket")]
        public async Task<IActionResult> SubmitTicket(SupportTicketReg ticket)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Ticket Submission");
            var ticketid = Guid.NewGuid().ToString();
            _wifFindContext.SupportTickets.Add(new SupportTicket
            {
                ticket_id = ticketid,
                username = ticket.username,
                subject = ticket.subject,
                description = ticket.description,
                status = TicketStatus.Open,
                time_stamp = DateTime.UtcNow,
            });
            await _wifFindContext.SaveChangesAsync();

            // SendEmailConfirmation(ticketid, ticket); // send newly generated ticket_id and DTO which contains user input

            return Ok("Ticket has been submitted.");
        }

        // Removes tickets, only used by admins
        // TODO: admin token validation
        // Possibly add check for 'Complete' Status?
        [HttpDelete("removeticket")]
        public async Task<IActionResult> RemoveTicket(SupportTicket ticket)
        {
            var query = from t in _wifFindContext.Set<SupportTicket>() where t.ticket_id == ticket.ticket_id select t;
            _wifFindContext.Remove(query);
            await _wifFindContext.SaveChangesAsync();

            return Ok("Ticket removed");
        }

        // Sends user email of ticket submission receipt
        private void SendEmailConfirmation(SupportTicket ticket)
        {
            // Join ticket with accountInfo to get email.
            var query = from acctLogin in _wifFindContext.Set<UserAccountInfo>() join suppTicket in _wifFindContext.Set<SupportTicket>() on acctLogin.username equals ticket.username select acctLogin;
            var email = query.First();

            // TODO: Rest of email logic
        }
    }

}