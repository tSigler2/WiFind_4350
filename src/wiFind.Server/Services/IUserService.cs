﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using wiFind.Server.AuthModels;
using wiFind.Server.Helpers;

namespace wiFind.Server.Services
{
    public interface IUserService
    {
        AuthResponse Authenticate(AuthRequest request);
        User GetById(string id);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly WiFindContext _wifFindContext; // Not sure if this should be allowed in this file

        public UserService(IOptions<AppSettings> appSettings, WiFindContext wiFindContext)
        {
            _appSettings = appSettings.Value;
            _wifFindContext = wiFindContext;
        }

        public AuthResponse Authenticate(AuthRequest request)
        {
            var user = from accountLogin in _wifFindContext.Set<UserAccountInfo>() 
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
                    return new AuthResponse(check.user_id, token);
                }
            }
            return null;
        }

        public User GetById(string id)
        {
            return _wifFindContext.Users.FirstOrDefault(x => x.user_id == id);
        }
        
        // Going to need to refactor authorization to consider different roles (admin and each admin's role)
        private string generateJwtToken(UserAccountInfo user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.user_id) }),
                Expires = DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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
