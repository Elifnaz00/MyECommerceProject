using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    public class Subscrabe: BaseEntity
    {
       
        public string? Mail { get; set; }
        public string? MailContent { get; set; }
    }
}
