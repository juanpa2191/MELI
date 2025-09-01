using Microsoft.AspNetCore.Mvc;
using MercadoLibre.Core.Interfaces;
using MercadoLibre.Core.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MercadoLibre.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Gets a product by its ID
        /// </summary>
        /// <param name="id">The unique identifier of the product</param>
        /// <returns>The product details</returns>
        /// <response code="200">Returns the product</response>
        /// <response code="404">If the product is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Product not found: {Id}", id);
                return NotFound(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Gets all products in a specific category
        /// </summary>
        /// <param name="category">The category name</param>
        /// <returns>A list of products in the category</returns>
        /// <response code="200">Returns the list of products</response>
        /// <response code="404">If no products are found in the category</response>
        [HttpGet("category/{category}")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(string category)
        {
            try
            {
                var products = await _productService.GetProductsByCategoryAsync(category);
                return Ok(products);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "No products found in category: {Category}", category);
                return NotFound(new { message = ex.Message });
            }
        }
    }
}