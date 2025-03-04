using DemoCRUD.Application.ProductDTOs;
using DemoCRUD.Application.UseCaseInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCRUD.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await productService.GetProductByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
        {
            await productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { id = productDto.Name }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }
            await productService.UpdateProductAsync(productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
