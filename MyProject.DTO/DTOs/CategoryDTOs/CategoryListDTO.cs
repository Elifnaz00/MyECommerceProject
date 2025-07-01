using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.TokenDTOs.DTOs.CategoryDTOs
{
    public class CategoryListDTO
    {
        public Guid Id { get; set; }
        public string? CategoryName { get; set; }
        public string? ImageCategory { get; set; }
    }
}
