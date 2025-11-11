using AutoMapper;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MyProject.Bussines.CQRS.AppUsers.Commands.Response;
using MyProject.Bussines.TokenServices;
using MyProject.Bussines.CQRS.AppUsers.Commands.Request;
using MyProject.Entity.Entities;
using MyProject.TokenDTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.AppUsers.Handlers.CommandHandlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;



        public LoginUserCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITokenHandler tokenHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenHandler = tokenHandler;

        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user is null)
            {
                return new LoginUserCommandResponse
                {
                    Message = "Kullanıcı bulunamadı",
                    IsSuccess= false
                };
            }
            var result = await _userManager.CheckPasswordAsync(user, request.Password);

            if (result)
            {
                Token token = _tokenHandler.CreateAccesToken(60, user.UserName, user.Id);


                return new LoginUserCommandResponse
                {
                    Message = "Başarılı bir şekilde giriş yapıldı.",
                    Token = token,
                    IsSuccess = true,
                };
            }
            return new LoginUserCommandResponse
            {
                Message = "Kullanıcı adı veya şifre hatalı.",
                IsSuccess= false
            };

        }
    }
}
