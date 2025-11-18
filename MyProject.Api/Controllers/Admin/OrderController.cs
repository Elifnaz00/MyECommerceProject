using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Admin.Order.Commands.Request;
using MyProject.DTO.DTOs.OrderDTOs;

namespace MyProject.Api.Controllers.Admin
{
    [Route("api/v1/admin/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("admin-get-orderlist")]
        public IActionResult GetOrderList()
        {
            return Ok("Admin Order Controller çalıştı");
        }
    

       [HttpPut("admin-update-ststus-order/{id}")]
        public async Task<IActionResult> UpdateOrderStatus([FromRoute] Guid id, [FromBody] UpdateOrderStatusDto updateOrderDto)
        {
            var response = await _mediator.Send(new UpdateOrderStatusCommandRequest() { OrderId = id, StatusId = updateOrderDto.Id });
            return Ok(response);


        }
    }
}