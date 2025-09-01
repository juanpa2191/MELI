using MercadoLibre.Core.Entities;
using MercadoLibre.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLibre.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found");
            }

            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(category);
            
            if (!products.Any())
            {
                throw new KeyNotFoundException($"No products found in category {category}");
            }

            return products;
        }
    }
}