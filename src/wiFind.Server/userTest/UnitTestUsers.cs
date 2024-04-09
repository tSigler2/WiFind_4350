using NUnit.Framework;
using NUnit.Framework.Legacy;

using Microsoft.AspNetCore.Mvc;
using wiFind.Server.Controllers;
using wiFind.Server.AuthModels;
using wiFind.Server.ControlModels;
using wiFind.Server.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using wiFind.Server.Helpers;

namespace wiFind.Server.UnitTest
{
    [TestFixture]
    public class UserTests
    {
        private readonly WiFindContext _wifFindContext = null; // Use Moq.EntityFramework for testing.
        private IUserService _userService;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void RegisterTest()
        {
            var UserControllerTest = new UserController(_wifFindContext, _userService);
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
                phone_number = "111-657-8309"
            };

            // TODO: change this to a better method--
            // referencing to https://stackoverflow.com/questions/43267763/proper-way-to-test-authenticated-methods-using-bearer-tokens-in-c-sharp-web-a
            
            var dumbTok = generateDummyJwtToken();
            UserControllerTest.Request.Headers["token"] = dumbTok;

            var result = UserControllerTest.Register(testReg);

            ClassicAssert.IsNotNull(result);

            // not sure how to get the body of the request from this
            ClassicAssert.IsTrue(result.GetType() == typeof(OkObjectResult));
            //ClassicAssert.AreEqual(200, result);
            
            //ClassicAssert.AreEqual("dummy-token", result);
        }

        [Test]
        public void LoginTest()
        {
            var UserControllerTest = new UserController(_wifFindContext, _userService);
            //var testUser = new User
            //        {
            //            user_id = "35ced7de-6cde-4d80-abc7-fb5d86179912",
            //            first_name = "user2",
            //            last_name = "teser",
            //            dob = DateOnly.FromDateTime(new DateTime()),
            //            phone_number = "211-1111-1111",
            //        };
            var testReg = new UserReg
            {
                username = "toenail57",
                password = "yum",
                email = "ex@ex.org",
                first_name = "toe",
                last_name = "fungus",
                dob = DateOnly.FromDateTime(new DateTime()),
                phone_number = "111-657-8309"
            };
            var testLogin1 = new AuthRequest { username = "toenail57", password = "yum" };
            var testLogin2 = new AuthRequest { username = "joyfuljoye", password = "yum" };
            var testLogin3 = new AuthRequest { username = "toenail57", password = "cheezyYUM" };
            
            // make sure the entry is created (might fail if the entry already exists though)
            UserControllerTest.Register(testReg);

            UserControllerTest.Request.Headers["token"] = generateDummyJwtToken();

            var response = UserControllerTest.Login(testLogin1);
            ClassicAssert.IsTrue(response.GetType() == typeof(OkObjectResult));

            response = UserControllerTest.Login(testLogin2);
            ClassicAssert.IsFalse(response.GetType() == typeof(OkObjectResult));

            response = UserControllerTest.Login(testLogin3);
            ClassicAssert.IsFalse(response.GetType() == typeof(OkObjectResult));
        }

        [Test]
        public void UpdateTest()
        {
            var UserControllerTest = new UserController(_wifFindContext, _userService);
            UserControllerTest.Request.Headers["token"] = generateDummyJwtToken();

            //var testUser = new User
            //        {
            //            user_id = "35ced7de-6cde-4d80-abc7-fb5d86179912",
            //            first_name = "user2",
            //            last_name = "teser",
            //            dob = DateOnly.FromDateTime(new DateTime()),
            //            phone_number = "211-1111-1111",
            //        };
            //var testReg = new UserReg
            //{
            //    username = "toenail57",
            //    password = "yum",
            //    email = "ex@ex.org",
            //    first_name = "toe",
            //    last_name = "fungus",
            //    dob = DateOnly.FromDateTime(new DateTime()),
            //    phone_number = "657-8309"
            //};

            var newUpdate = new UserUpdate
                    {
                        user_id = "f4140a29-60b3-4e84-a8d6-0274432509a5",
                        first_name = "user10:)",
                        last_name = "UNITtester",
                        phone_number = "000-000-0000",
                    };

            var response = UserControllerTest.UpdateUserProfile(newUpdate);
            //ClassicAssert.AreEqual("Successful update for user profile", response);
            ClassicAssert.IsTrue(response.GetType() == typeof(OkObjectResult));
        }

        // caveats of this test: 1) account info must exist. 2) User Role: AdminUser OR AdminTicketUser is required which involves the HTTPContext.
        // currently, this test is underconstruction and will not work as of yet.
        //[Test]
        //public void RemoveUserTest()
        //{
        //    var UserControllerTest = new UserController(_wifFindContext, _userService);
        //    var testUser = new User
        //            {
        //                user_id = "35ced7de-6cde-4d80-abc7-fb5d86179912",
        //                first_name = "user2",
        //                last_name = "teser",
        //                dob = DateOnly.FromDateTime(new DateTime()),
        //                phone_number = "211-1111-1111",
        //            };
        //    var testReg = new UserReg
        //    {
        //        username = "toenail57",
        //        password = "yum",
        //        email = "ex@ex.org",
        //        first_name = "toe",
        //        last_name = "fungus",
        //        dob = DateOnly.FromDateTime(new DateTime()),
        //        phone_number = "657-8309"
        //    };

        //    var response = UserControllerTest.RemoveInactiveUser("toenail57");

        //    ClassicAssert.AreEqual(response, "Placeholder for remove");
        //}

        // currently, this test will not work, refer to removeusertest() Reason #2
        //[Test]
        //public void GetInactiveUsersTest()
        //{
        //    var UserControllerTest = new UserController(_wifFindContext, _userService);
        //    var testUser = new User
        //            {
        //                user_id = "35ced7de-6cde-4d80-abc7-fb5d86179912",
        //                first_name = "user2",
        //                last_name = "teser",
        //                dob = DateOnly.FromDateTime(new DateTime()),
        //                phone_number = "211-1111-1111",
        //            };
        //    var testReg = new UserReg
        //    {
        //        username = "toenail57",
        //        password = "yum",
        //        email = "ex@ex.org",
        //        first_name = "toe",
        //        last_name = "fungus",
        //        dob = DateOnly.FromDateTime(new DateTime()),
        //        phone_number = "657-8309"
        //    };

        //    var response = UserControllerTest.GetInactiveUsers();

        //    ClassicAssert.NotNull(response);
        //}

        private string generateDummyJwtToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Sometimes,IStare@DScreen4Hours.");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", "00000000-0000-0000-0000-000000000000"),
                }),
                Expires = DateTime.UtcNow.AddDays(365),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}