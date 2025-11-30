using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.Exceptions
{
    public class UnauthorizedAccessException: Exception
    {

        public UnauthorizedAccessException(): base("Kullanıcı bulunamadı")
        {}

        public UnauthorizedAccessException(string message) : base(message)
        { }

    }
}
