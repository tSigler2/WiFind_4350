using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using wiFind.Server.Controllers;
using wiFind.Server.AuthModels;
using wiFind.Server.ControlModels;

namespace wiFind.Server.UnitTest
{

[TestFixture]
public class TicketTests
{
    [Test]
    public void FeedbackSubmitTest()
    {
        FeedbackControl = new FeedbackController(new WifindContext);

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
        FeedbackControl = new FeedbackController(new WifindContext);

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