using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity.Entities;

namespace MyProject.DTO.DTOs.OrderDTOs
{
    public class UserOrderDto
    {
        public string? ShippingAddress { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }

       
    }
}
