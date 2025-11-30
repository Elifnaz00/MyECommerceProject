using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DTO.DTOs.ProductDTOs;

namespace MyProject.DTO.DTOs.BasketItemDTOs
{
    public class OrderDetailBasketItemDto
    {

        public int Quantity { get; set; }
        public OrderDetailProductDto Product { get; set; }


    }
}
