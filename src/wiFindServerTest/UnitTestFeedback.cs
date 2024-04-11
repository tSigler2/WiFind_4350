using NUnit.Framework;
using NUnit.Framework.Legacy;

using wiFind.Server;
using Microsoft.AspNetCore.Mvc;
using wiFind.Server.Controllers;
using wiFind.Server.AuthModels;
using wiFind.Server.ControlModels;
using Microsoft.EntityFrameworkCore;

namespace wiFind.Server.UnitTest
{

    [TestFixture]
    public class FeedbackTests
    {
        private readonly WiFindContext _wifFindContext = null; // Use Moq.EntityFramework for testing.
        [Test]
        public void FeedbackSubmitTest()
        {
            var FeedbackControl = new FeedbackController(_wifFindContext);

            var feedback = new FeedbackReg
            {
                // adjusted feedbacks to be anonymous
                subject = "Website Down",
                description = "Your website is down right now.",
                rating = 2
            };

            var response = FeedbackControl.SubmitFeedback(feedback);

            ClassicAssert.AreEqual(response, "Feedback Submitted Successfully");
        }

        [Test]
        public void FeedbackGetTest()
        {
            var FeedbackControl = new FeedbackController(_wifFindContext);

            var response = FeedbackControl.GetFeedbacks();

            ClassicAssert.NotNull(response);
        }
    }
}