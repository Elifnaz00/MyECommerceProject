using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.ProductDTOs
{
    public class FilteredProductDto
    {
        public string? Category { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public long? Price { get; set; }
    }
}
