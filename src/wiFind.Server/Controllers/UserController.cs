using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using wiFind.Server;

namespace wiFind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WiFindContext server;
        public UserController(WiFindContext s)
        {
            server = s;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountInfo acctInfo, User userInfo)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Registration");

            //  Adjust to check AccountInfo to see if entered email exists or see if entered username exists
            //if (await server.Users.AnyAsync(u => u.email == model.email)) return BadRequest("Email already Taken");

            var (pHash, pSalt) = CreatePasswordHash(acctInfo.password);

            var user = new User
            {
                //email = model.email,
                passwordHash = pHash,
                passwordSalt = pSalt,
                amt_made = userInfo.amt_made,
                dob = userInfo.dob,
                first_name = userInfo.first_name,
                last_name = userInfo.last_name,
                phone_number = userInfo.phone_number,
                last_login = DateTime.UtcNow
            };

            server.Users.Add(user);
            await server.SaveChangesAsync();

            return Ok("Registration Successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AccountInfo acctLogin)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Login");

            // use username or email to find user's id 
            // INNER JOIN OR Subquery
            // TODO: update code to do Inner join/subquery
            var user = await server.Users.FirstOrDefaultAsync(u => u.user_id == acctLogin.user_id);

            if (user == null) return BadRequest("Invalid Email or Password");

            if (!VerifyPassword(user.passwordHash, user.passwordSalt, acctLogin.password)) return BadRequest("Invalid Email or Password");

            return Ok("Login Successful");
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
