using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity.Entities;

namespace MyProject.DTO.DTOs.BasketDTOs
{
    public class AddBasketDto
    {
        public Guid Id { get; set; }
        public AppUser User { get; set; }
        public string AppUserId { get; set; }

        public bool Active { get; set; }

        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }

    }
}
