using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using wiFind.Server.AuthModels;
using wiFind.Server.Helpers;
using Microsoft.EntityFrameworkCore;

namespace wiFind.Server.Services
{
    public interface IUserService
    {
        AuthResponse Authenticate(AuthRequest request);
        AccountInfo GetById(string id);

        Task<AuthResponse> userRegistration(UserReg newUser);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly WiFindContext _wiFindContext; 

        public UserService(IOptions<AppSettings> appSettings, WiFindContext wiFindContext)
        {
            _appSettings = appSettings.Value;
            _wiFindContext = wiFindContext;
        }

        public async Task<AuthResponse> userRegistration(UserReg newUser)
        {
            if (await _wiFindContext.AccountInfos.AnyAsync(a => (a.email == newUser.email || a.username == newUser.username)))
                return null;

            var (pHash, pSalt) = CreatePasswordHash(newUser.password);
            var user = new User
            {
                user_id = Guid.NewGuid().ToString(),
                first_name = newUser.first_name,
                last_name = newUser.last_name,
                dob = newUser.dob,
                phone_number = newUser.phone_number,
            };
            _wiFindContext.Users.Add(user);

            var acct = new AccountInfo
            {
                username = newUser.username,
                email = newUser.email,
                passwordHash = pHash,
                passwordSalt = pSalt,
                last_login = DateTime.UtcNow,
            };

            acct.user_id = user.user_id;
            _wiFindContext.AccountInfos.Add(acct);
            await _wiFindContext.SaveChangesAsync();

            var res = Authenticate(new AuthRequest { username = newUser.username, password = newUser.password });
            return res;
        }

        public AuthResponse Authenticate(AuthRequest request)
        {
            var user = from accountLogin in _wiFindContext.Set<AccountInfo>() 
                       where (accountLogin.username == request.username || accountLogin.email == request.username)
                       select accountLogin;

            if (user != null)
            {
                // check if login credentials are valid, then generate a token for the user
                var check = user.First();
                bool isValid = VerifyPassword(check.passwordHash, check.passwordSalt, request.password);

                if (isValid)
                {
                    var token = generateJwtToken(check);
                    // for the sake of ease on front end development, user role returned in the request.
                    // otherwise, user_role should inside of the token
                    return new AuthResponse(check.username, check.user_role.ToString(), token);
                }
            }
            return null;
        }

        public AccountInfo GetById(string id)
        {
            return _wiFindContext.AccountInfos.FirstOrDefault(x => x.user_id == id);
        }
        
        // Going to need to refactor authorization to consider different roles (admin and each admin's role)
        private string generateJwtToken(AccountInfo user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new [] { 
                    new Claim("id", user.user_id),
                    //new Claim(ClaimTypes.Role, user.user_role + ""),
                }),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
