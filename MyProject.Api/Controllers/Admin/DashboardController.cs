using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Admin.Dashboard.Queries.Request;

namespace MyProject.Api.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator ;
        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetDashboardData")]
        public async Task<IActionResult> GetDashboardData()
        {
            var dashboardResponse= await _mediator.Send(new GetDashboardDataQueryRequest());
            return dashboardResponse.IsSuccess ? Ok(dashboardResponse) : StatusCode(500, dashboardResponse); ;

        }
    }
}
