using MediatR;
using Microsoft.AspNetCore.Identity;
using MyProject.Bussines.CQRS.Admin.User.Commands.Request;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.User.Handlers
{
    public class LogoutAdminCommandHandler : IRequestHandler<LogoutAdminCommandRequest, Unit>
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogoutAdminCommandHandler(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Unit> Handle(LogoutAdminCommandRequest request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();
            return Unit.Value;  
        }
    }
}
