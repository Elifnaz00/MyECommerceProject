using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Admin.Order.Commands.Request;
using MyProject.Bussines.CQRS.Admin.Order.Queries.Request;
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
         

        [HttpGet("admin-get-active-orderlist")]
        public async Task<IActionResult> GetActiveOrderList()
        {
            var activeOrderList= await _mediator.Send(new GetActiveOrderQueryRequest()); 
            return Ok(activeOrderList);
        }


        [HttpGet("admin-get-active-orderlist/{id}")]
        public IActionResult GetActiveOrderList([FromRoute] Guid id)
        {
            return Ok();
        }


        [HttpGet("admin-get-cancelled-orderlist")]
        public async Task<IActionResult> GetCancelledOrderList()
        {
            var cancelledOrderList = await _mediator.Send(new GetCancelledOrderQueryRequest());
            return Ok(cancelledOrderList);
        }


        [HttpDelete("admin-cancel-order/{id}")]
        public async Task<IActionResult> CancelOrder([FromRoute] Guid id)
        {
            return Ok();
        }


        [HttpPut("admin-update-ststus-order/{id}")]
        public async Task<IActionResult> UpdateOrderStatus([FromRoute] Guid id, [FromBody] UpdateOrderStatusDto updateOrderDto)
        {
            var response = await _mediator.Send(new UpdateOrderStatusCommandRequest() { OrderId = id, StatusId = updateOrderDto.Id });
            return Ok(response);

        }




    }
}