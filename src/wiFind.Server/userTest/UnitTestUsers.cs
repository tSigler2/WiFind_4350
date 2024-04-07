using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using wiFind.Server.Controllers;
using wiFind.Server.AuthModels;
using wiFind.Server.ControlModels;

namespace wiFind.Server.UnitTest
{

    [TestFixture]
    public class UserTests
    {
        [SetUp]
        public void Setup()
        {
            wfc = new WiFindContext();
            var UserControllerTest = new UserController(wfc);
            var testUser = new User
                    {
                        user_id = "35ced7de-6cde-4d80-abc7-fb5d86179912",
                        first_name = "user2",
                        last_name = "teser",
                        dob = DateOnly.FromDateTime(new DateTime()),
                        phone_number = "211-1111-1111",
                    };
            var testReg = new UserReg
            {
                username = "toenail57",
                password = "yum",
                email = "ex@ex.org",
                first_name = "toe",
                last_name = "fungus",
                dob = DateOnly.FromDateTime(new DateTime()),
                phone_number = "657-8309"
            };
        }

        [Test]
        public void RegisterTest()
        {
            UserControllerTest.Setup(x => x.GenerateToken("username", "password")).Returns("dummy-token");

            var result = UserControllerTest.Register(testReg);

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("dummy-token", result.Value);
        }

        [Test]
        public void LoginTest()
        {
            UserControllerTest.Register(testReg);

            var response = UserControllerTest.Login(testReg.username, testReg.password);
            Assert.AreEqual(200, response.StatusCode);

            var response = UserControllerTest.Login(testReg.username, "joe");
            Assert.NotEqual(200, response.StatusCode);

            var response = UserControllerTest.Login("joe", testReg.password);
            Assert.NotEqual(200, response.StatusCode);
        }

        [Test]
        public void UpdateTest()
        {
            newUpdate = new UserUpdate
                    {
                        user_id = "f4140a29-60b3-4e84-a8d6-0274432509a5",
                        first_name = "user10",
                        last_name = "tester",
                        phone_number = "000-000-0000",
                    };

            var response = UserControllerTest.UpdateUserProfile(newUpdate);
            Assert.AreEqual("Successful update for user profile", response);
        }

        [Test]
        public void RemoveUserTest()
        {
            var response = UserControllerTest.RemoveInactiveUser(testUser);

            Assert.AreEqual(response, "Placeholder for remove");
        }

        [Test]
        public void GetInactiveUsersTest()
        {
            var response = UserControllerTest.GetInactiveUsers();

            Assert.IsNotNull(response);
        }
    }
}