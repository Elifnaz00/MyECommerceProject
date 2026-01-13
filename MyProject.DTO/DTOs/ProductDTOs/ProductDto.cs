using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.ProductDTOs
{
    public class ProductDto
    {
        public Guid Id { get; init; }
        public string? Title { get; set; }

        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public string? Size { get; set; }

        public string? Color { get; set; }
        public Guid CategoryId { get; set; }
        

    }
}
