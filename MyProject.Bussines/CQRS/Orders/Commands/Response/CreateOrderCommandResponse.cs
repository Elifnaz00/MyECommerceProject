using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DTO.DTOs.OrderDTOs;


namespace MyProject.Bussines.CQRS.Orders.Commands.Response
{
    public class CreateOrderCommandResponse
    {
        public OrderDto OrderDto { get; set; }
        public string Message { get; set; }

    }
}
