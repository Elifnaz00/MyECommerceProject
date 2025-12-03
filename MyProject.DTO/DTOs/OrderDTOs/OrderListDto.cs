using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.OrderDTOs
{
    public class OrderListDto
    {
        public Guid Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public string StatusName { get; set; }
        public string UserName { get; set; }


      
    }
}
