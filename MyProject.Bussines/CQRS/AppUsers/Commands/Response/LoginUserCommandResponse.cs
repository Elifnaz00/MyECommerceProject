using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.TokenDTOs.Token;

namespace MyProject.Bussines.CQRS.AppUsers.Commands.Response
{
    public class LoginUserCommandResponse
    {
        public Token Token { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
