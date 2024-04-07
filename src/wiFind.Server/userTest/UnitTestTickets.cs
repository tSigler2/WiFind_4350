using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using wiFind.Server.Controllers;
using wiFind.Server.AuthModels;
using wiFind.Server.ControlModels;

namespace wiFind.Server.UnitTest;

[TestFixture]
public class TicketTests
{

    [Test]
    public void TicketTest()
    {
        ticketController = new SupportTicketController();

        testTicket = new SupportTicketReg
        {
            username = "testuser",
            subject = "Terrible Service",
            description = "Do Better"
        };

        response = ticketController.SubmitTicket(testTicket);

        Assert.AreEqual("Ticket has been submitted.", response);
    }

}