using MercadoLibre.Api.Controllers;
using MercadoLibre.Core.Entities;
using MercadoLibre.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MercadoLibre.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _mockService;
        private readonly Mock<ILogger<ProductController>> _mockLogger;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockService = new Mock<IProductService>();
            _mockLogger = new Mock<ILogger<ProductController>>();
            _controller = new ProductController(_mockService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetProduct_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var expectedProduct = new Product 
            { 
                Id = "MLB1234567", 
                Title = "Test Product" 
            };
            
            _mockService.Setup(service => 
                service.GetProductByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedProduct);

            // Act
            var result = await _controller.GetProduct("MLB1234567");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedProduct = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(expectedProduct.Id, returnedProduct.Id);
        }

        [Fact]
        public async Task GetProduct_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            _mockService.Setup(service => 
                service.GetProductByIdAsync(It.IsAny<string>()))
                .ThrowsAsync(new KeyNotFoundException());

            // Act
            var result = await _controller.GetProduct("invalid_id");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetProductsByCategory_WithValidCategory_ReturnsOkResult()
        {
            // Arrange
            var expectedProducts = new List<Product>
            {
                new Product { Id = "1", Category = "Electronics" },
                new Product { Id = "2", Category = "Electronics" }
            };

            _mockService.Setup(service => 
                service.GetProductsByCategoryAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedProducts);

            // Act
            var result = await _controller.GetProductsByCategory("Electronics");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedProducts = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Equal(2, returnedProducts.Count());
        }

        [Fact]
        public async Task GetProductsByCategory_WithInvalidCategory_ReturnsNotFound()
        {
            // Arrange
            _mockService.Setup(service => 
                service.GetProductsByCategoryAsync(It.IsAny<string>()))
                .ThrowsAsync(new KeyNotFoundException());

            // Act
            var result = await _controller.GetProductsByCategory("invalid_category");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}
