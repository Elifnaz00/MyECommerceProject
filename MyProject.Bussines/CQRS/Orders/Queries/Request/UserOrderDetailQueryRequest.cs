using MediatR;
using MyProject.DTO.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Orders.Queries.Request
{
    public class UserOrderDetailQueryRequest: IRequest<List<OrderDetailDto>>
    {
        public Guid OrderId { get; set; }
   
    }
}
