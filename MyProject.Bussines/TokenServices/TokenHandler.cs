using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyProject.Entity.Entities;
using MyProject.TokenDTOs.Token;

namespace MyProject.Bussines.TokenServices
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configration;

        public TokenHandler(IConfiguration configration)
        {
            _configration = configration;
        }

        public Token CreateAccesToken(int minute, string username, string userId)
        {
            Token token = new();


            //SecurtiyKey in simetriğini alıyoruz
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
          {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),



        };


            //Oluşturulacak token ayarları
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken jwtSecurityToken = new(
                issuer: _configration["Token:Issuer"],
                audience: _configration["Token:Audience"],
                expires: token.Expiration,
                claims: claims, 
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
            );

            //Token oluştoluşturucu sınıfından bir örnek alalım
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurityToken);
            return token;

           
        }
    }
}
