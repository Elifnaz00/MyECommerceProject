using MediatR;
using Microsoft.AspNetCore.Identity;
using MyProject.Bussines.CQRS.AppUsers.Commands.Request;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.CQRS.AppUsers.Handlers.CommandHandlers
{
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommandRequest>
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogoutUserCommandHandler(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Unit> Handle(LogoutUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return Unit.Value;
        }
    }
}
