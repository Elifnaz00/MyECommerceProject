using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    public class Contact: BaseEntity
    {
       
        public string? ContentMessage{ get; set; }
        public string? SenderName { get; set; }

        
        public string? SenderMail { get; set; }

        
        public string? Subject { get; set; }
        
    }
}
