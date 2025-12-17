using MediatR;

using MyProject.DTO.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Order.Queries.Request
{
    public class GetActiveOrderQueryRequest : IRequest<GetActiveOrderListDto>
    {
    }
}
