using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DTO.DTOs.BaseDTO;
using MyProject.DTO.DTOs.BasketItemDTOs;
using MyProject.DTO.DTOs.OrderDTOs;

namespace MyProject.Bussines.CQRS.Orders.Queries.Response
{
    public class GetUserOrderQueryResponse: BaseResponse
    {
        public List<UserOrderDto> Orders { get; set; }

    }
}
