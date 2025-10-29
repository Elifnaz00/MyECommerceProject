using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.DTO.Models.AdminRoleViewModel;

namespace MyProject.Api.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IMediator _mediator;
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet()]
        public async Task<IActionResult> GetRole()
        {
            return Ok("Role Controller Çalıştı");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(AdminCreateRoleViewModel adminCreateRoleViewModel)
        {
            
            return Ok("Create Role Çalıştı");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] string roleName)
        {
            return Ok("Update Role Çalıştı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            return Ok("Delete Role Çalıştı");
        }
    }
}
