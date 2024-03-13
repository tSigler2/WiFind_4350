using System;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace wiFind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly WiFindContext _wifFindContext;

        public FeedbackController(WiFindContext wifFindContext)
        {
            _wifFindContext = wifFindContext;
        }

        // TODO: Add Client token verification
        // Adds User Feedback
        [HttpPost]
        public async Task<IActionResult> SubmitFeedback(Feedback feedback)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Feedback Data");

            feedback.date_stamp = DateOnly.FromDateTime(DateTime.UtcNow);

            _wifFindContext.Feedbacks.Add(feedback);
            await _wifFindContext.SaveChangesAsync();

            return Ok("Feedback Submitted Successfully");
        }

        // Returns All Feedbacks
        [HttpGet]
        public async Task<IActionResult> GetFeedbacks()
        {
            var feedbacks = await _wifFindContext.Feedbacks.ToListAsync();
            return Ok(feedbacks);
        }
    }
}