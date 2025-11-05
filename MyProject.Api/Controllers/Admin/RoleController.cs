using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Request;
using MyProject.Bussines.CQRS.Admin.Role.Queries.Request;
using MyProject.DTO.DTOs.AdminDTOs.RoleDto;


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
        [HttpGet("GetRole")]
        public async Task<IActionResult> GetRole()
        {
            var getRoleresponse= await _mediator.Send(new GetRoleQueryRequest()); 
            return getRoleresponse.StatusCode == 200 ? Ok(getRoleresponse.RoleList) : StatusCode(500);
        }



        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateAppRoleDto createAppRoleDto)
        {
            
            var response= await _mediator.Send(new CreateRoleCommmandRequest
                {
                    Name = createAppRoleDto.Name,
                   
            });
            return Ok(response);


        }

        [HttpPut("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto updateAppRoleDto, [FromRoute] string id)
        {
         
            var response = await _mediator.Send(new UpdateRoleCommandRequest
            {
                Id = id,
                Name = updateAppRoleDto.Name

            });
            return Ok();
        }


        [HttpDelete("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            return Ok("Delete Role Çalıştı");
        }
    }
}
