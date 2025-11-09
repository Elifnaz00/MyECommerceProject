using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity.Enums;

namespace MyProject.Bussines.CQRS.Admin.Role.Commands.Response
{
    public class DeleteRoleCommandResponse
    {
        public StatusCode StatusCode { get; set; } 
        public string Message { get; set; } 
    }
}
