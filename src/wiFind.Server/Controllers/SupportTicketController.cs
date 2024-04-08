using System;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wiFind.Server.ControlModels;
using wiFind.Server.Helpers;

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

        [Authorize]
        [HttpGet("alltickets")]
        public async Task<IActionResult> GetTickets()
        {
            var context = (AccountInfo)HttpContext.Items["User"];
            if (context.user_role.ToString() == "AdminTicketUser" || context.user_role.ToString() == "AdminTicket")
            {
                var ticketList = await _wifFindContext.SupportTickets.ToListAsync();
                return Ok(ticketList);
            }
            return Unauthorized("Unauthorized");

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

        [Authorize]
        [HttpDelete("removeticket")]
        public async Task<IActionResult> RemoveTicket(SupportTicket ticket)
        {
            var context = (AccountInfo)HttpContext.Items["User"];
            if (context.user_role.ToString() == "AdminTicketUser" || context.user_role.ToString() == "AdminTicket")
            {
                var query = from t in _wifFindContext.Set<SupportTicket>() where t.ticket_id == ticket.ticket_id select t;
                _wifFindContext.Remove(query);
                await _wifFindContext.SaveChangesAsync();
                return Ok("Ticket Removed.");
            }
            return Unauthorized("Unauthorized");
        }

        // Sends user email of ticket submission receipt
        private void SendEmailConfirmation(SupportTicket ticket)
        {
            // Join ticket with accountInfo to get email.
            var query = from acctLogin in _wifFindContext.Set<AccountInfo>() join suppTicket in _wifFindContext.Set<SupportTicket>() on acctLogin.username equals ticket.username select acctLogin;
            var email = query.First();

            // TODO: Rest of email logic
        }
    }

}