using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.BasketItemDTOs
{
    public class UpdateBasketItemDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
       
    }
}
