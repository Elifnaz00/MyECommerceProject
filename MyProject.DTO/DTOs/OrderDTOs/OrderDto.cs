using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity.Entities;

namespace MyProject.DTO.DTOs.OrderDTOs
{
    public class OrderDto
    {
        public Guid Id { get; init; }
        public DateTime CreateDate { get; set; }

        public bool IsDeleted { get; set; } = false;
        public int Piece { get; set; }
        public string? Addres { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
