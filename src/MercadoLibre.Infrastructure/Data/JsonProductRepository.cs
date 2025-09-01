using MercadoLibre.Core.Entities;
using MercadoLibre.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MercadoLibre.Infrastructure.Data
{
    public class JsonProductRepository : IProductRepository
    {
        private readonly string _jsonFilePath;
        private List<Product> _products;

        public JsonProductRepository()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var infrastructureDirectory = Path.GetFullPath(Path.Combine(currentDirectory, "..", "MercadoLibre.Infrastructure"));
            _jsonFilePath = Path.Combine(infrastructureDirectory, "Data", "products.json");
            LoadProducts();
        }

        private void LoadProducts()
        {
            if (!File.Exists(_jsonFilePath))
            {
                throw new FileNotFoundException($"Products data file not found at {_jsonFilePath}");
            }

            var jsonString = File.ReadAllText(_jsonFilePath);
            var options = new JsonSerializerOptions 
            { 
                PropertyNameCaseInsensitive = true
            };
            
            var productsRoot = JsonSerializer.Deserialize<ProductsRoot>(jsonString, options);
            _products = productsRoot?.Products ?? new List<Product>();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(product);
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            var products = _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            return await Task.FromResult(products);
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await Task.FromResult(_products.Any(p => p.Id == id));
        }
    }
}