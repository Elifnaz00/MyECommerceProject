using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.User.Commands.Request
{
    public class LogoutAdminCommandRequest : IRequest<Unit>
    {
    }
}
