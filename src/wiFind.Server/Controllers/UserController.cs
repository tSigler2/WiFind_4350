using System;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace wiFind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // TODO: Add log messages, consider implementing DTO
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly WiFindContext _wifFindContext;
        public UserController(ILogger<UserController> logger, WiFindContext wifFindContext)
        {
            _logger = logger;
            _wifFindContext = wifFindContext;
        }

        // JSON Web Token
        // Client End: Auth token with expiration time, store id in body of token; for every client request, include auth token in header.
        // In Back End: validate token 


        // User Registration
        // Requires AccountInfo(username, email, password) and User(first_name, last_name, dob, phone_number)
        // Step 1 :: Verify username or email does not exist in AccountInfo Table. 
        // Step 2 :: Hash and Salt password
        // Step 3 :: Fill in remaining required user information, add object to wifindcontext
        // Step 4 :: Use temporary id assigned by EF Core to assign AccountInfo id with object's
        // Step 5 :: Connect to DB and save changes to DB

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountInfo acctInfo, User userInfo)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Registration");

            // Checks AccountInfo to see if entered email exists or see if entered username exists
            if (await _wifFindContext.AccountInfos.AnyAsync(a => (a.email == acctInfo.email || a.username == acctInfo.username)))
                return BadRequest("Email OR Username already Taken");

            var (pHash, pSalt) = CreatePasswordHash(acctInfo.password);
            userInfo.passwordHash = pHash;
            userInfo.passwordSalt = pSalt;
            userInfo.last_login = DateTime.UtcNow;

            _wifFindContext.Users.Add(userInfo);

            acctInfo.user_id = userInfo.user_id;
            _wifFindContext.AccountInfos.Add(acctInfo);

            await _wifFindContext.SaveChangesAsync();

            return Ok("Registration Successful");
        }

        // Login Verification
        // Requires: User submitted a (username OR email) AND a password
        // Step 1 :: Query AccountLogin Table filter rows for is_admin is false and for matching username/email (expected: only one row)
        // Step 2 :: Verify password with hash salt
        [HttpPost("login")]
        public async Task<IActionResult> Login(AccountInfo acctLogin)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Login");

            //var user = await server.Users.FirstOrDefaultAsync(u => u.user_id == acctLogin.user_id);
            var query = from user in _wifFindContext.Set<User>() join accountLogin in _wifFindContext.Set<AccountInfo>() on user.user_id equals accountLogin.user_id select user;
            if (query.Count() != 1)
                return BadRequest("Invalid Login Credentials"); // Relies on db correctiveness (only one user for one accountInfo)

            var res = query.GetEnumerator().Current;

            if (!VerifyPassword(res.passwordHash, res.passwordSalt, acctLogin.password)) 
                return BadRequest("Invalid Email or Password");

            return Ok("Login Successful");

            // TODO: Update 'last_login' in User in a different API
        }

        // Update User Profile
        // updateU needs to have the same user_id and not let db generate one
        // Need to check: since user is a dbset, user_id of the same should override existing?
        [HttpPost]
        public async Task<IActionResult> UpdateUserProfile(User updateU)
        {
            _wifFindContext.Users.Add(updateU);
            await _wifFindContext.SaveChangesAsync();

            return Ok("placeholder for update user profile");
        }

        // Returns Users who have been inactive for more than 3 months, only used by admins
        // TODO: Consider DTOs to only get relevant information; Add admin token in parameters.
        // TODO: If this does not work, change to WifiController.GetListing() format
        [HttpGet]
        public async Task<IEnumerable<User>> GetInactiveUsers()
        {
            var inactiveTime = DateTime.UtcNow.AddMonths(-3);
            var query = from user in _wifFindContext.Set<User>() where user.last_login < inactiveTime select user;
            return query.AsEnumerable();
        }

        // Remove Users, only used by admins
        // TODO: admin token validation in parameters
        [HttpDelete]
        public async Task<IActionResult> RemoveInactiveUser(User user)
        {
            //TODO: function for token validation. if wrong, return Unauthorized.
            // Optional: could add extra check to ensure user is truly inactive for over 3 months
            var query = from u in _wifFindContext.Set<User>() where u.user_id == user.user_id select u;
            _wifFindContext.Remove(query);
            await _wifFindContext.SaveChangesAsync(); 
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

        private static bool VerifyPassword(byte[] storedHash, byte[] storedSalt, string password)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
