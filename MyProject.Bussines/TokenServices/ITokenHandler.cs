using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity.Entities;
using MyProject.TokenDTOs.Token;

namespace MyProject.Bussines.TokenServices
{
    public interface ITokenHandler
    {
          Token CreateAccesToken(int minute, string username, string appUserId);
    }
}
