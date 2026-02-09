using Microsoft.AspNetCore.Identity;
using MyProject.Entity.Entities;
using MyProject.TokenDTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.TokenServices
{
    public interface ITokenHandler
    {
        Task<Token> CreateAccessTokenAsync(AppUser user, UserManager<AppUser> userManager, int expireMinutes);
    }
}
