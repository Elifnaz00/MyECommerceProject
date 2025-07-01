using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity.Entities;

namespace MyProject.DTO.Models.BasketViewModel
{
    public class GetBasketViewModel
    {
        public Guid BasketId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
