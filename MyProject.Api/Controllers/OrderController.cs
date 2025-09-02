using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Orders.Commands.Request;
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

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto crateOrderDto)
        {
            var response= await _mediator.Send(new CreateOrderCommandRequest() { CreateOrderDto = crateOrderDto});
            return Ok(response);
        }
    }
}
