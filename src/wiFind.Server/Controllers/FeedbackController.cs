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
            if (!ModelState.IsValid) return BadRequest("Invalid Feedback Data");

            // not sure if theres a better way to get date only but this soln works for now
            feedback.date_stamp = DateOnly.FromDateTime(DateTime.UtcNow);

            server.Feedbacks.Add(feedback);
            await server.SaveChangesAsync();

            return Ok("Feedback Submitted Successfully");
        }
    }
}