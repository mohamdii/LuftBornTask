using LuftBornTask.API.Contracts;
using LuftBornTask.Application.Commands;
using LuftBornTask.Application.DTOs;
using LuftBornTask.Application.Interfaces;
using LuftBornTask.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuftBornTask.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IProductService _productService;
        public ProductController(IProductService productService, ISender sender)
        {
            _productService = productService;
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductDto>>>> GetAll()
        {
            var products = await _sender.Send(new GetProductsQuery());
            return ApiResponse<IEnumerable<ProductDto>>.Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ProductDto>>> GetById(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var product = await _sender.Send(new AddProductCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<ProductDto>>> Update(int id, UpdateProductDto dto)
        {
            var product = await _sender.Send(new UpdateProductCommand(id, dto));
            if (product == null)
            {
                return ApiResponse<ProductDto>.NotFound("Product not found");
            }
            return ApiResponse<ProductDto>.Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<ProductDto>>> Delete(int id)
        {
            var product = await _sender.Send(new DeleteProductCommand(id));
            if (product == null)
            {
                return ApiResponse<ProductDto>.NotFound("Product not found");
            }
            return ApiResponse<ProductDto>.Ok(product);
        }

    }
}
