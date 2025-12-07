using MyProject.DTO.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.BasketItemDTOs
{
    public class DenemeBasketItemDto
    {
        public Guid BasketId { get; set; }
        public int Quantity { get; set; }

        public OrderDetailProductDto Product { get; set; }


    }
}
