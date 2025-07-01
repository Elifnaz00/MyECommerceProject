using MediatR;
using MyProject.Bussines.CQRS.AppUsers.Commands.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.AppUsers.Commands.Request
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool RememberMe  { get; set; }
    }
}
