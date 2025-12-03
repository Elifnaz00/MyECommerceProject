using MediatR;
using MyProject.DTO.DTOs.OrderDTOs;

namespace MyProject.Api.Controllers.Admin
{
    internal class GetActiveOrderListCommandRequest : IRequest<IList<OrderListDto>>
    {
    }
}