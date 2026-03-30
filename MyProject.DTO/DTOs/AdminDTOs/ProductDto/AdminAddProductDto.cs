using MyProject.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.AdminDTOs.ProductDto
{
    public class AdminAddProductDto
    {
        public string? Title { get; set; }

        public int Stock { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public string? ImageUrl { get; set; }

        public Renkler Renkler { get; set; }
        public Bedenler Bedenler { get; set; }

        public Guid CategoryId { get; set; }
    }
}
