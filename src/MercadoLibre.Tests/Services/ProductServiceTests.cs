using MercadoLibre.Core.Entities;
using MercadoLibre.Core.Interfaces;
using MercadoLibre.Core.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MercadoLibre.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepository;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetProductByIdAsync_WithValidId_ReturnsProduct()
        {
            // Arrange
            var expectedProduct = new Product
            {
                Id = "MLB1234567",
                Title = "Test Product"
            };

            _mockRepository.Setup(repo =>
                repo.GetProductByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedProduct);

            // Act
            var result = await _productService.GetProductByIdAsync("MLB1234567");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedProduct.Id, result.Id);
            Assert.Equal(expectedProduct.Title, result.Title);
        }

        [Fact]
        public async Task GetProductByIdAsync_WithInvalidId_ThrowsKeyNotFoundException()
        {
            // Arrange
            _mockRepository.Setup(repo =>
                repo.GetProductByIdAsync(It.IsAny<string>()))
                .ReturnsAsync((Product)null);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                _productService.GetProductByIdAsync("invalid_id"));
        }

        [Fact]
        public async Task GetProductsByCategoryAsync_WithValidCategory_ReturnsProducts()
        {
            // Arrange
            var expectedProducts = new List<Product>
            {
                new Product { Id = "1", Category = "Electronics" },
                new Product { Id = "2", Category = "Electronics" }
            };

            _mockRepository.Setup(repo =>
                repo.GetProductsByCategoryAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedProducts);

            // Act
            var result = await _productService.GetProductsByCategoryAsync("Electronics");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetProductsByCategoryAsync_WithInvalidCategory_ThrowsKeyNotFoundException()
        {
            // Arrange
            _mockRepository.Setup(repo =>
                repo.GetProductsByCategoryAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<Product>());

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                _productService.GetProductsByCategoryAsync("invalid_category"));
        }
    }
}