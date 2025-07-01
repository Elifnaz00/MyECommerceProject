using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Baskets.Queries.Request;

using MyProject.DTO.DTOs.BasketDTOs;
using MyProject.DTO.Models.BasketViewModel;
using MyProject.Entity.Entities;

namespace MyProject.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {

        readonly IMediator _mediator;
        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }


        

        [HttpGet("GetBasket")]
        public async Task<IActionResult> GetBasket()
        {
            // JWT claim olarak eklediğim userId verisini çektim  
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            try
            {
                var response = await _mediator.Send(new GetBasketQueryRequest { UserId = userId });
                if (response.IsSuccess.Equals(false))
                {
                    return BadRequest(response);
                }

                return Ok(response); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("AddBasket")]
        public async Task<IActionResult> AddToBasket()
        {
            //JWT claim olarak eklediğim userId verisini çektim
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            var response = await _mediator.Send(new AddBasketQueryRequest
            {
                AppUserId= userId,
                Active = true,
               
            });

            //return Ok(response.Basket);
            return CreatedAtAction("GetBasket", new { id = userId}, response);
        }



    }
}
