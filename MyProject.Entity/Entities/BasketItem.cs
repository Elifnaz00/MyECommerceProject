using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    public class BasketItem : BaseEntity
    {
        public Basket Basket { get; set; }
        public Guid BasketId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public Guid ProductId { get; set; }


        public BasketItem()
        {
            Quantity = 1; // Default quantity for a new basket item 
        }
    }
}

     
