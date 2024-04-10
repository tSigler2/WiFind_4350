using NUnit.Framework;
using NUnit.Framework.Legacy;

using Microsoft.AspNetCore.Mvc;
using wiFind.Server.Controllers;
using wiFind.Server.AuthModels;
using wiFind.Server.ControlModels;

namespace wiFind.Server.UnitTest
{

    [TestFixture]
    public class TicketTests
    {
        private readonly WiFindContext _wifFindContext = null; // Use Moq.EntityFramework for testing.

        [Test]
        public void TicketTest()
        {
            var ticketController = new SupportTicketController(_wifFindContext);

            var testTicket = new SupportTicketReg
            {
                username = "testuser",
                subject = "Terrible Service",
                description = "Do Better"
            };

            var response = ticketController.SubmitTicket(testTicket);

            ClassicAssert.AreEqual("Ticket has been submitted.", response);
        }
    }
}