using System;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using wiFind.Server.Helpers;
using wiFind.Server.ControlModels;
using wiFind.Server.Services;
using wiFind.Server.AuthModels;
using System.Net.Sockets;

namespace wiFind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly WiFindContext _wiFindContext;
        private IUserService _userService;
        public UserController(WiFindContext wiFindContext, IUserService userService)
        {
            _wiFindContext = wiFindContext;
            _userService = userService;
        }

        // User Registration
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserReg newUser)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Registration");
            var accountExists = await Queries.hasExistingAccount(newUser, _wiFindContext);
            if (accountExists) { return BadRequest("Username or Email has already been taken."); }
            newUser.user_role = UserRole.User;

            var resNoToken = await _userService.userRegistration(newUser);
            var getAccountInfo = await Queries.getAccountInfoByUsernameOrEmail(resNoToken, _wiFindContext);
            var accountToValidate = getAccountInfo.First();
            var resWithToken = _userService.Authenticate(resNoToken, accountToValidate);
            return Ok(resWithToken);
        }

        // Admin Registration, another admin is required to create an admin account, user_role is needed in UserReg.
        [Authorize]
        [HttpPost("adminregister")]
        public async Task<IActionResult> AdminRegister(UserReg newUser)
        {
            var context = (AccountInfo)HttpContext.Items["User"];
            if (context.user_role.ToString() == "AdminTicketUser" || context.user_role.ToString() == "AdminTicket" || context.user_role.ToString() == "AdminUser")
            {
                if (!ModelState.IsValid) return BadRequest("Invalid Registration");
                if (newUser.user_role == null) return BadRequest("Please designate the user role.");

                var accountExists = await Queries.hasExistingAccount(newUser, _wiFindContext);
                if (accountExists) return BadRequest("Username or Email has already been taken");
                 
                var resNoToken = await _userService.userRegistration(newUser);
                var getAccountInfo = await Queries.getAccountInfoByUsernameOrEmail(resNoToken, _wiFindContext);
                var accountToValidate = getAccountInfo.First();
                var resWithToken = _userService.Authenticate(resNoToken, accountToValidate);
                return Ok(resWithToken);
            }
            return Unauthorized("Another Admin is required to register new Admins.");
        }

        // Login Verification
        // Requires: User submitted a (username OR email) AND a password
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequest credentials)
        {
            var getAccountInfo = await Queries.getAccountInfoByUsernameOrEmail(credentials, _wiFindContext);
            var accountToValidate = getAccountInfo.First();
            var response = _userService.Authenticate(credentials, accountToValidate);
            if (response == null) return BadRequest(new { message = "Login Credentials is incorrect." });
            return Ok(response);
        }

        // Update User Profile
        // Input should have same user_id and not let db generate one
        // Authorization checK: in header do: 'Authorization' then Paste the token 
        [Authorize]
        [HttpPost("updateprofile")]
        public async Task<IActionResult> UpdateUserProfile(UserUpdate update)
        {
            // Change this to query and edit user matching guid
            var query = from u in _wiFindContext.Set<User>() where u.user_id == update.user_id select u;
            var user = query.First();
            user.first_name = update.first_name;
            user.last_name = update.last_name;
            user.phone_number = update.phone_number;

            _wiFindContext.Users.Update(user);
            await _wiFindContext.SaveChangesAsync();

            return Ok("Successful update for user profile");
        }

        // Below is for admins only. TODO: Figure out how to do admin token validations and roles

        // Returns Users who have been inactive for more than 3 months, only used by admins
        [Authorize]
        [HttpGet("inactiveusers")]
        public async Task<IActionResult> GetInactiveUsers()
        {
            var context = (AccountInfo)HttpContext.Items["User"];
            if (context.user_role.ToString() == "AdminTicketUser" || context.user_role.ToString() == "AdminUser")
            {
                var inactiveTime = DateTime.UtcNow.AddMonths(-3);
                var query = from user in _wiFindContext.Set<AccountInfo>() where user.last_login < inactiveTime select user;
                var listings = await query.ToListAsync();
                return Ok(listings);
            }
            return Unauthorized("Unauthorized");
        }

        [Authorize]
        [HttpDelete("removeusers")]
        public async Task<IActionResult> RemoveInactiveUser(string username)
        {
            var context = (AccountInfo)HttpContext.Items["User"];
            if (context.user_role.ToString() == "AdminTicketUser" || context.user_role.ToString() == "AdminUser")
            {
                var query = from u in _wiFindContext.Set<AccountInfo>() where u.username == username select u;
                _wiFindContext.Remove(query);
                await _wiFindContext.SaveChangesAsync();
                return Ok("User Removed");
            }
            return Unauthorized("Unauthorized");
        }
    }
}