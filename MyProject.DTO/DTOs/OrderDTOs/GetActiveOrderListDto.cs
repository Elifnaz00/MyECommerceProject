using MyProject.DTO.DTOs.OrderStatusDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.OrderDTOs
{
    public class GetActiveOrderListDto
    {
        public List<OrderListDto> Orders { get; set; }
        public List<OrderStatusDto> OrderStatuses { get; set; }
    }
}
