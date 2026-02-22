using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Request;
using MyProject.Bussines.CQRS.Admin.Role.Queries.Request;
using MyProject.DTO.DTOs.AdminDTOs.RoleDto;
using System.Web.Http.Results;


namespace MyProject.Api.Controllers.Admin
{
    [Route("api/v1/admin/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
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
            return Ok(getRoleresponse);
        }



        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateAppRoleDto createAppRoleDto)
        {
            
            var response= await _mediator.Send(new CreateRoleCommmandRequest
                {
                    Name = createAppRoleDto.Name,
                   
            });   
            return Created("", response.Message);
        }



        [HttpPut("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto updateAppRoleDto, [FromRoute] string id)
        {
             await _mediator.Send(new UpdateRoleCommandRequest
             {
                 Id = id,
                 Name = updateAppRoleDto.Name

             });
             return NoContent();
        }


        [HttpDelete("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            await _mediator.Send(new DeleteRoleCommandRequest
            {
                Id = id
            });
            return NoContent();
        }


        [HttpPost("RoleAssign")]
        public async Task<IActionResult> RoleAssign([FromBody] RoleAssignDto roleAssignDto)
        {
            await _mediator.Send(new RoleAssignCommandRequest
            {
               adminRoleAssignViewModels= roleAssignDto.adminRoleAssignViewModels,
               UserId= roleAssignDto.UserId
            });
            return Ok();
        }
    }
}
