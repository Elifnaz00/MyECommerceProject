using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Admin.Dashboard.Queries.Request;

namespace MyProject.Api.Controllers.Admin
{
    [Route("api/v1/admin/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator ;
        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-dashboard-data")]
        public async Task<IActionResult> GetDashboardData()
        {
            var dashboardResponse= await _mediator.Send(new GetDashboardDataQueryRequest());
            return Ok(dashboardResponse);

        }
    }
}
