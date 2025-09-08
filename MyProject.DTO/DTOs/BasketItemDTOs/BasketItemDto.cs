using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.Entity.Entities;

namespace MyProject.DTO.DTOs.BasketItemDTOs
{
    public class BasketItemDto
    {
        public Guid Id { get; set; }  
        public int Quantity { get; set; }
        public Guid BasketId { get; set; }
        public ProductDto Product { get; set; }
    }
}
