using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Admin.User.Queries.Request;

namespace MyProject.Api.Controllers.Admin
{
    [Route("api/v1/admin/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("admin-get-userlist")]
        public async Task<IActionResult> GetUserList()
        {
            var responseCustomer= await _mediator.Send(new GetCustomerRequest());
            return Ok(responseCustomer);
        }



        [HttpGet("admin-get-users-with-roles")]
        public async Task<IActionResult> GetUsersWithRoles()
        {
            var response = await _mediator.Send(new GetUsersWithRolesQueryRequest());
            return Ok(response);
        }

    }
}
