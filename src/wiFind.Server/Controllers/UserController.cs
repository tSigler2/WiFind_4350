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
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid) return BadRequest("Invalid Registration");

            if(await server.Users.AnyAsync(u => u.email == model.email)) return BadRequest("Email already Taken");

            var (pHash, pSalt) = CreatePasswordHash(model.password);

            var user = new User
            {
                email = model.email,
                passwordHash = pHash,
                passwordSalt = pSalt,
                amtMade = model.amtMade,
                dob = model.dob,
                fName = model.fName,
                lName = model.lName,
                nickname = model.nickname,
                phoneNumber = model.phoneNumber,
                lastLogin = DateTime.UtcNow
            };

            server.Users.Add(user);
            await server.SaveChangesAsync();

            return Ok("Registration Successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(!ModelState.IsValid) return BadRequest("Invalid Login");

            var user = await server.Users.FirstOrDefaultAsync(u => u.email == model.email);

            if(user == null) return BadRequest("Invalid Email or Password");

            if(!VerifyPassword(user.passwordHash, user.passwordSalt, model.password)) return BadRequest("Invalid Email or Password");

            return Ok("Login Successful");
        }

        private (byte[] pHash, byte[] pSalt) CreatePasswordHash(string password)
        {   

            byte[] salt;
            byte[] hash;

            using(var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            return (hash, salt);
        }

        private static bool VerifyPassword(byte[] storedHash, byte[] storedSalt, string password)
        {
            using(var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}