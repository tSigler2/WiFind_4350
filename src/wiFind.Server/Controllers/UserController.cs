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

namespace wiFind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly WiFindContext _wiFindContext;
        private IUserService _userService;
        public UserController(ILogger<UserController> logger, WiFindContext wiFindContext, IUserService userService)
        {
            _logger = logger;
            _wiFindContext = wiFindContext;
            _userService = userService;
        }

        // User Registration
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserReg newUser)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Registration");

            if (await _wiFindContext.UserAccountInfos.AnyAsync(a => (a.email == newUser.email || a.username == newUser.username)))
                return BadRequest("Email OR Username already Taken");

            var (pHash, pSalt) = CreatePasswordHash(newUser.password);
            var user = new User
            {
                user_id = Guid.NewGuid().ToString(),
                first_name = newUser.first_name,
                last_name = newUser.last_name,
                dob = newUser.dob,
                phone_number = newUser.phone_number,
                last_login = DateTime.UtcNow,
            };
            _wiFindContext.Users.Add(user);

            var acct = new UserAccountInfo
            {
                username = newUser.username,
                email = newUser.email,
                passwordHash = pHash,
                passwordSalt = pSalt
            };

            acct.user_id = user.user_id;
            _wiFindContext.UserAccountInfos.Add(acct);
            await _wiFindContext.SaveChangesAsync();
            
            var authToken = _userService.Authenticate(new AuthRequest { username = newUser.username, password =  newUser.password });

            return Ok(authToken);
        }


        // Login Verification
        // Requires: User submitted a (username OR email) AND a password
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequest credentials)
        {
            var response = _userService.Authenticate(credentials);
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
        [HttpGet("inactiveusers")]
        public async Task<IEnumerable<User>> GetInactiveUsers()
        {
            var inactiveTime = DateTime.UtcNow.AddMonths(-3);
            var query = from user in _wiFindContext.Set<User>() where user.last_login < inactiveTime select user;
            return query.AsEnumerable();
        }

        // Remove Users, only used by admins
        [HttpDelete("removeusers")]
        public async Task<IActionResult> RemoveInactiveUser(User user)
        {
            //TODO: function for token validation. if wrong, return Unauthorized.
            // Optional: could add extra check to ensure user is truly inactive for over 3 months
            var query = from u in _wiFindContext.Set<User>() where u.user_id == user.user_id select u;
            _wiFindContext.Remove(query);
            await _wiFindContext.SaveChangesAsync(); 
            return Ok("Placeholder for remove");
        }

        private (byte[] pHash, byte[] pSalt) CreatePasswordHash(string password)
        {   

            byte[] salt;
            byte[] hash;

            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            return (hash, salt);
        }
    }
}