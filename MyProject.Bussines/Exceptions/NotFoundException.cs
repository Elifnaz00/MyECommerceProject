using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.Exceptions
{
    public class NotFoundException : Exception
    {

        private string id;
        public NotFoundException() : base()
        {

        }

        public NotFoundException(string message) : base(message)
        { }


        public NotFoundException(string message, string id) : base(message)
        {
           this.id = id;
         
           
        }

    }
    
}
