using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.OrderDTOs
{
    public class CreatedOrderDto
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public Guid OrderStatusId { get; set; }
        public Guid PaymentStatusId { get; set; }
       
    }
}
