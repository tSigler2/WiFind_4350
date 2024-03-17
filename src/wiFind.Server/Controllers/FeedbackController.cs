using System;
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
    public class FeedbackController : ControllerBase
    {
        private readonly WiFindContext _wifFindContext;

        public FeedbackController(WiFindContext wifFindContext)
        {
            _wifFindContext = wifFindContext;
        }

        // Adds User Feedback
        [Authorize]
        [HttpPost("submitfeedback")]
        public async Task<IActionResult> SubmitFeedback(FeedbackReg feedback)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Feedback Data");

            _wifFindContext.Feedbacks.Add(new Feedback
            {
                feedback_id = Guid.NewGuid().ToString(),
                // user_id = get user id from jwt token
                subject = feedback.subject,
                description = feedback.description,
                rating = feedback.rating,
                date_stamp = DateOnly.FromDateTime(DateTime.UtcNow),
            });
            await _wifFindContext.SaveChangesAsync();

            return Ok("Feedback Submitted Successfully");
        }

        // Returns All Feedbacks
        [HttpGet("allfeedbacks")]
        public async Task<IActionResult> GetFeedbacks()
        {
            var feedbacks = await _wifFindContext.Feedbacks.ToListAsync();
            return Ok(feedbacks);
        }
    }
}