using NUnit.Framework.Legacy;
using wiFind.Server.AuthModels;
using wiFind.Server.Services;
using wiFind.Server.Helpers;

using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Data.Entity.Infrastructure;
using System.Linq;
using wiFindServerTest;
using System.Data.Entity;

namespace wiFind.Server.UnitTest
{
    [TestFixture]
    public class UserTests
    {
        IOptions<AppSettings> appSettings = Options.Create(new AppSettings());

        [Test]
        public async Task RegisterTestSuccessful()
        {
            var users = Utils.generateDummyUsers();
            var userData = users.AsQueryable();

            var accounts = Utils.generateDummyAccountInfo();
            var accountInfoData = accounts.AsQueryable();

            var mockUserDbSet = new Mock<Microsoft.EntityFrameworkCore.DbSet<User>>();
            mockUserDbSet.As<IDbAsyncEnumerable<User>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<User>(userData.GetEnumerator()));

            mockUserDbSet.As<IQueryable<User>>().Setup(m=>m.Provider).Returns(new TestDbAsyncQueryProvider<User>(userData.Provider));
            mockUserDbSet.As<IQueryable<User>>().Setup(m=>m.Expression).Returns(userData.Expression);
            mockUserDbSet.As<IQueryable<User>>().Setup(m=>m.ElementType).Returns(userData.ElementType);
            mockUserDbSet.As<IQueryable<User>>().Setup(m=>m.GetEnumerator()).Returns(userData.GetEnumerator());
            mockUserDbSet.Setup(d => d.Add(It.IsAny<User>())).Callback<User>((s) => users.Add(s));

            var mockAccountInfoDbSet = new Mock<Microsoft.EntityFrameworkCore.DbSet<AccountInfo>>();
            mockAccountInfoDbSet.As<IDbAsyncEnumerable<AccountInfo>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<AccountInfo>(accountInfoData.GetEnumerator()));
            mockAccountInfoDbSet.As<IQueryable<AccountInfo>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<AccountInfo>(accountInfoData.Provider));
            mockAccountInfoDbSet.As<IQueryable<AccountInfo>>().Setup(m => m.Expression).Returns(accountInfoData.Expression);
            mockAccountInfoDbSet.As<IQueryable<AccountInfo>>().Setup(m => m.ElementType).Returns(accountInfoData.ElementType);
            mockAccountInfoDbSet.As<IQueryable<AccountInfo>>().Setup(m => m.GetEnumerator()).Returns(accountInfoData.GetEnumerator());
            mockAccountInfoDbSet.Setup(d => d.Add(It.IsAny<AccountInfo>())).Callback<AccountInfo>((s) => accounts.Add(s));

            var mockWiFindContext = new Mock<WiFindContext>(new DbContextOptions<WiFindContext>());
            mockWiFindContext.Setup(c => c.Users).Returns(mockUserDbSet.Object);
            mockWiFindContext.Setup(a => a.AccountInfos).Returns(mockAccountInfoDbSet.Object);

            var u = new UserReg()
            {
                first_name = "Test",
                last_name = "Test",
                email = "Test@test.com",
                dob = DateOnly.FromDateTime(DateTime.Now),
                phone_number = "777-111-2222",
                username = "Test",
                password = "Test",
            };

            var _userService = new UserService(appSettings, mockWiFindContext.Object);
            var test = _userService.userRegistration(u);

            var addedAccountInfo = accounts.ElementAt(10);
            var addedUser = users.ElementAt(10);
            
            ClassicAssert.IsNotNull(test);
            ClassicAssert.True(addedAccountInfo.username == "Test");
            ClassicAssert.True(addedUser.user_id == addedAccountInfo.user_id);
        }

        [Test]
        public void LoginTest()
        {
            var users = Utils.generateDummyUsers();
            var userData = users.AsQueryable();

            var accounts = Utils.generateDummyAccountInfo();
            var accountInfoData = accounts.AsQueryable();

            var mockUserDbSet = new Mock<Microsoft.EntityFrameworkCore.DbSet<User>>();
            mockUserDbSet.As<IDbAsyncEnumerable<User>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<User>(userData.GetEnumerator()));

            mockUserDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<User>(userData.Provider));
            mockUserDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockUserDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockUserDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());
            mockUserDbSet.Setup(d => d.Add(It.IsAny<User>())).Callback<User>((s) => users.Add(s));

            var mockAccountInfoDbSet = new Mock<Microsoft.EntityFrameworkCore.DbSet<AccountInfo>>();
            mockAccountInfoDbSet.As<IDbAsyncEnumerable<AccountInfo>>().Setup(m => m.GetAsyncEnumerator()).Returns(new TestDbAsyncEnumerator<AccountInfo>(accountInfoData.GetEnumerator()));
            mockAccountInfoDbSet.As<IQueryable<AccountInfo>>().Setup(m => m.Provider).Returns(new TestDbAsyncQueryProvider<AccountInfo>(accountInfoData.Provider));
            mockAccountInfoDbSet.As<IQueryable<AccountInfo>>().Setup(m => m.Expression).Returns(accountInfoData.Expression);
            mockAccountInfoDbSet.As<IQueryable<AccountInfo>>().Setup(m => m.ElementType).Returns(accountInfoData.ElementType);
            mockAccountInfoDbSet.As<IQueryable<AccountInfo>>().Setup(m => m.GetEnumerator()).Returns(accountInfoData.GetEnumerator());
            mockAccountInfoDbSet.Setup(d => d.Add(It.IsAny<AccountInfo>())).Callback<AccountInfo>((s) => accounts.Add(s));

            var mockWiFindContext = new Mock<WiFindContext>(new DbContextOptions<WiFindContext>());
            mockWiFindContext.Setup(c => c.Users).Returns(mockUserDbSet.Object);
            mockWiFindContext.Setup(a => a.AccountInfos).Returns(mockAccountInfoDbSet.Object);

            var u = new UserReg()
            {
                first_name = "Test",
                last_name = "Test",
                email = "Test@test.com",
                dob = DateOnly.FromDateTime(DateTime.Now),
                phone_number = "777-111-2222",
                username = "Test",
                password = "Test",
            };

            var _userService = new UserService(appSettings, mockWiFindContext.Object);
            var test = _userService.userRegistration(u);

            var addedAccountInfo = accounts.ElementAt(10);
            var addedUser = users.ElementAt(10);

            ClassicAssert.IsNotNull(test);
            ClassicAssert.True(addedAccountInfo.username == "Test");
            ClassicAssert.True(addedUser.user_id == addedAccountInfo.user_id);
        }

        //[Test]
        //public void UpdateTest()
        //{
        //    var UserControllerTest = new UserController(_wifFindContext, _userService);
        //    UserControllerTest.Request.Headers["token"] = generateDummyJwtToken();

        //    //var testUser = new User
        //    //        {
        //    //            user_id = "35ced7de-6cde-4d80-abc7-fb5d86179912",
        //    //            first_name = "user2",
        //    //            last_name = "teser",
        //    //            dob = DateOnly.FromDateTime(new DateTime()),
        //    //            phone_number = "211-1111-1111",
        //    //        };
        //    //var testReg = new UserReg
        //    //{
        //    //    username = "toenail57",
        //    //    password = "yum",
        //    //    email = "ex@ex.org",
        //    //    first_name = "toe",
        //    //    last_name = "fungus",
        //    //    dob = DateOnly.FromDateTime(new DateTime()),
        //    //    phone_number = "657-8309"
        //    //};

        //    var newUpdate = new UserUpdate
        //            {
        //                user_id = "f4140a29-60b3-4e84-a8d6-0274432509a5",
        //                first_name = "user10:)",
        //                last_name = "UNITtester",
        //                phone_number = "000-000-0000",
        //            };

        //    var response = UserControllerTest.UpdateUserProfile(newUpdate);
        //    //ClassicAssert.AreEqual("Successful update for user profile", response);
        //    ClassicAssert.IsTrue(response.GetType() == typeof(OkObjectResult));
        //}

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
    }
}