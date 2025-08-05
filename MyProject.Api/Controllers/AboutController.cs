using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Abouts.Queries.Request;

namespace MyProject.Api.Controllers
{
    
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {

        private readonly IMediator _mediator;

        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }

      
        [HttpGet]
        public async Task<IActionResult> GetAbout()
        {
           
            var responseAbout= await _mediator.Send(new GetAboutQueryRequest());
            return Ok(responseAbout);
        }
    }
}
