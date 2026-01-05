using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.AdminDTOs.ProductDto
{
    public class ProductDetailDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; }
        public string? Size { get; set; }

        public string? Color { get; set; }

        public DateTime CreateDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
