using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DTO.DTOs.BaseDTO;
using MyProject.DTO.DTOs.OrderDTOs;


namespace MyProject.Bussines.CQRS.Orders.Commands.Response
{
    public class CreateOrderCommandResponse: BaseResponse
    {
        public CreatedOrderDto CreatedOrderDto { get; set; }
    }
}
