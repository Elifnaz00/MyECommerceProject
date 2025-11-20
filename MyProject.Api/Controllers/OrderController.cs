using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Admin.Order.Commands.Request;
using MyProject.Bussines.CQRS.Orders.Commands.Request;
using MyProject.Bussines.CQRS.Orders.Queries.Request;
using MyProject.DTO.DTOs.OrderDTOs;

namespace MyProject.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto crateOrderDto)
        {
            var response = await _mediator.Send(new CreateOrderCommandRequest() { CreateOrderDto = crateOrderDto });
            return CreatedAtAction(nameof(GetByIdOrder), new { id = response.CreatedOrderDto.Id }, response);

        }
        

        [HttpGet("order-details/{id}")]
        public async Task<IActionResult> GetByIdOrder([FromRoute] Guid id)
        {
            return Ok("merhaba");
        }



        [HttpGet("user-orders")]
        public async Task<IActionResult> GetUserOrder()
        {

            var response = await _mediator.Send(new GetUserOrderQueryRequest());
            return Ok(response);
        }



        [HttpDelete("cancel-order/{id}")]    
        public async Task<IActionResult> CancelOrder([FromRoute] Guid id)
        {
            await _mediator.Send(new CancelOrderCommandRequest() { OrderId = id });
            return NoContent();
        }


    }
        
}
