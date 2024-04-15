using Microsoft.AspNetCore.Mvc;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.BLL.DTO;
using Swashbuckle.AspNetCore.Annotations;

namespace OnlineStore.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [SwaggerOperation("Create a new product")]
        [ProducesResponseType(typeof(ProductDTO), 200)]
        public async Task<ActionResult<ProductDTO>> CreateProductAsync(ProductDTO newProduct, CancellationToken cancellationToken)
        {
            var createdProduct = await _productService.CreateProductAsync(newProduct, cancellationToken);

            return Ok(createdProduct);
        }

        [HttpGet]
        [SwaggerOperation("Get products")]
        [ProducesResponseType(typeof(IEnumerable<ProductDTO>), 200)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync([FromQuery] PaginationSettingsDTO paginationSettings, CancellationToken cancellationToken)
        {
            var products = await _productService.GetProductsAsync(paginationSettings, cancellationToken);

            return Ok(products);
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Get product by ID")]
        [ProducesResponseType(typeof(ProductDTO), 200)]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(id, cancellationToken);

            return Ok(product);
        }

        [HttpGet("category/{categoryName}")]
        [SwaggerOperation("Get product by category")]
        [ProducesResponseType(typeof(ProductDTO), 200)]
        public async Task<ActionResult<ProductDTO>> GetProductByCategoryAsync(string categoryName, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByCategoryAsync(categoryName, cancellationToken);

            return Ok(product);
        }

        [HttpPut("{id}")]
        [SwaggerOperation("Update a product")]
        [ProducesResponseType(typeof(ProductDTO), 200)]
        public async Task<ActionResult<ProductDTO>> UpdateProductAsync(int id, ProductDTO productDTO, CancellationToken cancellationToken)
        {
            var updatedProduct = await _productService.UpdateProductAsync(productDTO, id, cancellationToken);

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Delete a product")]
        [ProducesResponseType(typeof((bool, string)), 200)]
        public async Task<ActionResult<(bool, string)>> DeleteProductAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _productService.DeleteProductAsync(id, cancellationToken);

            return Ok(result);
        }
    }
}
