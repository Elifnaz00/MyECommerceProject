using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DTO.DTOs.AdminDTOs.CategoryDto;

namespace MyProject.DTO.DTOs.AdminDTOs.ProductDto
{
    public class ProductEditDto
    {
        public Guid Id { get; set; }    
        public string? Title { get; set; }

        public int Stock { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public string? ImageUrl { get; set; }

        public string? Size { get; set; }

        public string? Color { get; set; }

        public Guid CategoryId { get; set; }
        public string? CategoryCategoryName { get; set; }

        public List<MyProject.DTO.DTOs.AdminDTOs.CategoryDto.CategoryDto> CategoryDtos { get; set; }
    }
}
