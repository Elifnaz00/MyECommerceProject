using MyProject.DTO.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.Models.OrderStatusViewModel
{
    public class OrderStatusUpdateViewModel
    {
        public Guid Id { get; set; }
        public UpdateOrderStatusDto UpdateOrderStatusDto { get; set; }
    }
}
