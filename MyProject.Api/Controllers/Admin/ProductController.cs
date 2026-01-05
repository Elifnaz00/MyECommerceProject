using Azure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Admin.Product.Command.Request;
using MyProject.Bussines.CQRS.Admin.Product.Queries.Request;
using MyProject.DTO.DTOs.AdminDTOs.ProductDto;
using MyProject.Entity.Entities;



namespace MyProject.Api.Controllers.Admin
{
    [Route("api/v1/admin/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-avaiable-product-list")]
        public async Task<IActionResult> GetAvailableProducts()
        {
            var availableProductsResponse = await _mediator.Send(new GetAvailableProductQueryRequest());
            return Ok(availableProductsResponse);
        }


        [HttpGet("get-finished-product-list")]
        public async Task<IActionResult> GetFinishedProducts()
        {
            var finishedProductsResponse = await _mediator.Send(new GetFinishedProductQueryRequest());
            return Ok(finishedProductsResponse);
        }


        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProductById([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteProductCommandRequest() { Id = id });
            return NoContent();

        }

        [HttpPut("update-product/{id}")]
        public async Task<IActionResult> UpdateProductById([FromRoute] Guid id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (id != updateProductDto.Id)
            {
                return BadRequest();
            }
            await _mediator.Send(new UpdateProductCommandRequest() { Id = id , UpdateProductDto= updateProductDto});
            return NoContent();

        }

        [HttpGet("get-by-id-product/{id}")]
        public async Task<IActionResult> GetByIdProduct([FromRoute] Guid id)
        {
            var productResponse = await _mediator.Send(new GetByIdProductQueryRequest() { Id = id });
            return Ok(productResponse);
        }


        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct([FromBody] AdminAddProductDto addProductDto)
        {
            await _mediator.Send(new AddProductCommandRequest{
                AdminAddProductDto = addProductDto
            });
            return Ok();
        }


        [HttpGet("detail-product/{id}")]
        public async Task<IActionResult> DetailProduct([FromRoute] Guid id)
        {
            var productResponse = await _mediator.Send(new GetDetailProductQueryRequest() { Id = id });
            return Ok(productResponse);
        }

    }
}
