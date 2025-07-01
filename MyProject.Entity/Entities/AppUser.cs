using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    public class AppUser: IdentityUser
    {
        public string? NameSurname { get; set; }
        public ICollection<Basket> Baskets { get; set; } 

    }
}
