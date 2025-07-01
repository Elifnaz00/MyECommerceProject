using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MyProject.Bussines.CQRS.AppUsers.Commands.Request;

namespace MyProject.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        


        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest createUserCommandRequest)
        {
           
                var response= await _mediator.Send(createUserCommandRequest);

                if(response.Succeeded== true)
                {
                   
                    return StatusCode(201, response.Message);
                }
                else
                return BadRequest(response.Message);
            
            
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommandRequest loginUserCommandRequest)
        {
            var response= await _mediator.Send(loginUserCommandRequest);
            if(!response.IsSuccess)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Token.AccessToken);
         }



        [HttpPost("Logout")]
        public async Task<IActionResult> LogoutUser()
        {
            await _mediator.Send(new LogoutUserCommandRequest());
            return Ok(new { Message = "Başarıyla Çıkış Yapıldı" });
            
        }



    }
}
