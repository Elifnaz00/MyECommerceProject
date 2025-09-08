using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity.Entities;

namespace MyProject.DTO.DTOs.OrderDTOs
{
    public class CreateOrderDto
    {
        public string? ShippingCountry { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingPostalCode { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public decimal TotalAmount { get; set; } 
        public string? PaymentMethod { get; set; }
        public Guid BasketId { get; set; }
        public Guid OrderStatusId { get; set; }
        public Guid PaymentStatusId { get; set; }
       

    }
}
