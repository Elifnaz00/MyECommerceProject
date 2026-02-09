
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MyProject.Bussines.CQRS.AppUsers.Commands.Request;
using MyProject.Bussines.CQRS.AppUsers.Commands.Response;

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

                if(response.IsSuccess== true)
                {
                   
                    return StatusCode(201, response.Message);
                }
                else
                return BadRequest(response.Message);
            
        }


        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommandRequest loginUserCommandRequest)
        {
            var response = await _mediator.Send(loginUserCommandRequest);

            var result = new LoginUserCommandResponse
            {
                IsSuccess = response.IsSuccess,
                Message = response.Message,
                Token = response.Token
            };

            if (!response.IsSuccess)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }



        [HttpPost("Logout")]
        public async Task<IActionResult> LogoutUser()
        {
            await _mediator.Send(new LogoutUserCommandRequest());
            return Ok(new { Message = "Başarıyla Çıkış Yapıldı" });
            
        }

    }
}
