using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Admin.Category.Queries.Request;
using MyProject.Bussines.CQRS.Admin.Dashboard.Queries.Request;

namespace MyProject.Api.Controllers.Admin
{
    [Route("api/v1/admin/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categorieslistsResponse = await _mediator.Send(new GetCategoriesQueryRequest());
            return Ok(categorieslistsResponse);

        }
    }
}
