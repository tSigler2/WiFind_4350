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
    public class FeedbackController : ControllerBase
    {
        private readonly WiFindContext server;

        public FeedbackController(WiFindContext s)
        {
            server = s;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitFeedback(Feedback feedback)
        {
            if(!ModelState.IsValid) return BadRequest("Invalid Feedback Data");

            feedback.Timestamp = DateTime.UtcNow;

            server.Feedback.Add(feedback);
            await server.SaveChangesAsync();

            return Ok("Feedback Submitted Successfully");
        }
    }
}