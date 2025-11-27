using MyProject.DTO.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.BasketItemDTOs
{
    public class BasketItemDetailDto
    {
        public int Quantity { get; set; }

        public OrderDetailProductDto OrderDetailProductDto { get; set; }
       

    }
}
