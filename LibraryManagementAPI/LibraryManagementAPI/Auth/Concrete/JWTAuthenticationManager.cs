using LibraryManagementAPI.Auth.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Auth.Concrete
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        IDictionary<string, string> users = new Dictionary<string, string>
        {
            { "test1", "password1" },
            { "test2", "password2" }
        };

        private readonly string tokenKey;
        private IConfiguration configuration { get; }
        public JWTAuthenticationManager(string tokenKey, IConfiguration _configuration)  
        {
            this.configuration = _configuration;
            this.tokenKey = tokenKey;
             
        }
       

        public dynamic Authenticate(string username, string password)
        {
            if (!users.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(configuration["Identity:Token_Expire_Minute"]) ),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            if (token == null) return null;
            return new {
                TokenType = "Bearer",
                Token = tokenHandler.WriteToken(token) ,
                Expires = Convert.ToDouble(configuration["Identity:Token_Expire_Minute"])
            };
        }
    }
}
