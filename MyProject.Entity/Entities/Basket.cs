using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    
    public class Basket: BaseEntity
    {
        public AppUser User { get; set; }
        public string AppUserId { get; set; }

        public bool Active { get; set; }

        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; } 
      


    }
}
