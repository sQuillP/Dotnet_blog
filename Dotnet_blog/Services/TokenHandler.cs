using Dotnet_blog.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dotnet_blog.Services
{
    public class TokenHandler
    {
        private readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<string> CreateTokenAsync(User user)
        {
            var claims = new List<Claim>();

            //Add credientials to place on jwt token
            claims.Add(new Claim(ClaimTypes.GivenName, user.FullName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            
            //Encrypt the key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            
            //create the credentials
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
                );
            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
