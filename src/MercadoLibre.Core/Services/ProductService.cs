using MercadoLibre.Core.Entities;
using MercadoLibre.Core.Interfaces;
using MercadoLibre.Core.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace MercadoLibre.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Product ID cannot be null or empty", nameof(id));
            }

            var product = await _productRepository.GetProductByIdAsync(id);
            
            if (product == null)
            {
                _logger.LogWarning("Product not found with ID: {Id}", id);
                throw new ProductNotFoundException(id);
            }

            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                throw new ArgumentException("Category cannot be null or empty", nameof(category));
            }

            var products = await _productRepository.GetProductsByCategoryAsync(category);
            
            if (!products.Any())
            {
                _logger.LogWarning("No products found in category: {Category}", category);
                throw new ProductNotFoundException($"No products found in category: {category}");
            }

            return products;
        }
    }
}