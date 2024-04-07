using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using wiFind.Server.Controllers;
using wiFind.Server.AuthModels;
using wiFind.Server.ControlModels;

namespace wiFind.Server.UnitTest
{

    [TestFixture]
    public class FeedbackTests
    {
        [Test]
        public void FeedbackSubmitTest()
        {
            wfc = new WiFindContext();
            FeedbackControl = new FeedbackController(wfc);

            var Feedback = new FeedbackReg
            {
                user_id = null,
                subject = "Website Down",
                description = "Your website is down right now.",
                rating = 2
            };

            var response = FeedbackControl.SubmitFeedback(FeedbackControl);

            Assert.AreEqual(response, "Feedback Submitted Successfully");
        }

        [Test]
        public void FeedbackGetTest()
        {
            wfc = new WiFindContext();
            FeedbackControl = new FeedbackController(wfc);

            var Feedback = new FeedbackReg
            {
                user_id = null,
                subject = "Website Down",
                description = "Your website is down right now.",
                rating = 2
            };

            var response = FeedbackControl.SubmitFeedback(FeedbackControl);

            var response = FeedbackControl.GetFeedbacks();

            Assert.IsNotNull(response);
        }

    }
}