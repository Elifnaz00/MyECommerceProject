using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.BasketItem.Commands;
using MyProject.Bussines.CQRS.BasketItem.Commands.Request;
using MyProject.Bussines.CQRS.BasketItem.Queries.Request;
using MyProject.DTO.DTOs.BasketItemDTOs;
using MyProject.Entity.Entities;
using System.Security.Claims;

namespace MyProject.Api.Controllers
{
    
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    public class BasketItemController : Controller
    {
        private readonly IMediator _mediator;

        public BasketItemController(IMediator mediator )
        {
            _mediator= mediator;
        }

        [HttpGet("GetBasketItems")]
        public async Task<IActionResult> GetBasketItems()
        {
            return Ok();
        }



        [HttpPost("AddToBasket")]
        public async Task<IActionResult> AddToBasket([FromBody] AddBasketItemDto addBasketItemDto)
        {

            var response = await _mediator.Send(new AddBasketItemCommandRequest
            {
                ProductId = addBasketItemDto.ProductId,

            });
            return response.IsSuccess
                ? Ok(response)
                : BadRequest(response);

        }

        [HttpDelete("DeleteBasketItems/{Id}")]
        public async Task<IActionResult> DeleteToBasket([FromRoute] Guid Id)
        {
            var response = await _mediator.Send(new DeleteBasketItemCommandRequest
            {
                Id = Id
            });

            return Ok(response);
        }


        [HttpPut("UpdateBasketItem/{Id}")]
        public async Task<IActionResult> UpdateBasketItem([FromBody] UpdateBasketItemDto updateBasketItemDto, [FromRoute] Guid Id)
        {
            var response = await _mediator.Send(new UpdateBasketItemCommandRequest
            {
                Id = Id,
                Quantity = updateBasketItemDto.Quantity

            });
         

            if(response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }



        [HttpGet("GetBasketTotal/{basketId}")]
        public async Task<IActionResult> GetBasketTotal([FromRoute] Guid basketId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            var response = await _mediator.Send(new GetBasketTotalQueryRequest
            {
                BasketId = basketId
            });

            if (!response.IsSuccess)
                return BadRequest(response);

            return Json(response);

        }

    }
}
