using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Role.Commands.Response
{
    public class UpdateRoleCommandResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
