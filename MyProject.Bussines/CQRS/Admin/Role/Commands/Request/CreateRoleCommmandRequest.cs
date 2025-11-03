using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Response;

namespace MyProject.Bussines.CQRS.Admin.Role.Commands.Request
{
    public class CreateRoleCommmandRequest: IRequest<CreateRoleCommmandResponse>
    {
        public string Name { get; set; } 
        public string? Id { get; set; }
    }
}
