﻿using System;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> SubmitFeedback(Feedback feedback)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Feedback Data");

            feedback.date_stamp = DateOnly.FromDateTime(DateTime.UtcNow);

            _wifFindContext.Feedbacks.Add(feedback);
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