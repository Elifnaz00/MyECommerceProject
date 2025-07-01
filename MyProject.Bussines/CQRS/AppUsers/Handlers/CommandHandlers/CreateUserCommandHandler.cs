using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

using MyProject.Bussines.CQRS.AppUsers.Commands.Request;
using MyProject.Bussines.CQRS.AppUsers.Commands.Response;
using MyProject.DataAccess.Exceptions;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.AppUsers.Handlers.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper )
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var appUserValue= _mapper.Map<AppUser>(request);

            IdentityResult result= await _userManager.CreateAsync(appUserValue, request.Password);


                return result.Succeeded
           ? new CreateUserCommandResponse
           {
               Succeeded= true ,
               Message = "Kayıt işlemi başarılı"
           }

           : new CreateUserCommandResponse
           {
               Succeeded = false ,
               Message = string.Join(", ", result.Errors.Select(e => e.Description))
               
           };


        }
    }
}
