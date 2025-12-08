using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.Exceptions
{
    public class UnauthorizedException: Exception
    {

        public UnauthorizedException(): base("Kullanıcı bulunamadı")
        {}

        public UnauthorizedException(string message) : base(message)
        { }

    }
}
