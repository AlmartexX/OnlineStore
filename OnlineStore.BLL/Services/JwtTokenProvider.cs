using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using OnlineStore.BLL.JwtInfrastructure.Models;
using OnlineStore.BLL.Services.Interfaces;

namespace OnlineStore.BLL.Services
{
    public class JwtTokenProvider : IJwtTokenProvider
    {
        private readonly TokenOptions _options;
        public JwtProvider(IOptions<TokenOptions> options)
        {
            _options = options.Value;
        }
        public string GenerateToken(User user)
        {
            Claim[] claims = [new("UserId", user.Id.ToString())];

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), SecurityAlgorithms.HmacSha256),
                expires: DateTime.UtcNow.AddHours(_options.ExpitesHours)
                );
            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
