using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Exceptions
{
    public class UserCreatedFailedException : Exception
    {
        
        public UserCreatedFailedException(string? message) : base(message)
        {
            
        }
    }
}
