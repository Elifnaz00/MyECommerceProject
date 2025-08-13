using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.BasketItem.Commands;
using MyProject.Bussines.CQRS.BasketItem.Commands.Request;
using MyProject.Bussines.CQRS.Baskets.Queries.Request;
using MyProject.DTO.DTOs.BasketItemDTOs;
using MyProject.Entity.Entities;

namespace MyProject.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketItemController : Controller
    {
        readonly IMediator _mediator;
        

        public BasketItemController(IMediator mediator)
        {
            _mediator = mediator;
          
        }

        [HttpGet("GetBasketItems")]
        public async Task<IActionResult> GetBasketItems()
        {
            return Ok();
        }



        [HttpPost("AddToBasket")]
        public async Task<IActionResult> AddToBasket([FromBody] AddBasketItemDto addBasketItemDto)
        {
            
            var response= await _mediator.Send(new AddBasketItemCommandRequest
            {
                ProductId = addBasketItemDto.ProductId,

            });
            return response.IsSuccess
                ? Ok(response)
                : BadRequest(response);

        }

        [HttpDelete("DeleteBasketItems/{Id}")]
        public async Task<IActionResult> DeleteToBasket([FromRoute]Guid Id)
        {
            var response= await _mediator.Send(new DeleteBasketItemCommandRequest
            {
                Id = Id
            });

            return Ok(response);


        }
    }
}
