using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyProject.Entity.Entities;
using MyProject.TokenDTOs.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace MyProject.Bussines.TokenServices
{
    public class TokenHandler : ITokenHandler
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Token> CreateAccessTokenAsync(AppUser user, UserManager<AppUser> userManager, int expireMinutes)
        {
            // 1️⃣ Rol bilgisi çek
            var roles = await userManager.GetRolesAsync(user);

            // 2️⃣ Claim listesi oluştur
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            // 3️⃣ Rol claim ekle
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
            
            // 4️⃣ SymmetricSecurityKey
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            // 5️⃣ Signing credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 6️⃣ Token üret
            var token = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: creds
            );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token
            {
                AccessToken = jwtToken,
                Expiration = token.ValidTo
            };
        }
    }
}
