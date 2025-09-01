using MercadoLibre.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoLibre.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(string id);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
        Task<bool> ExistsAsync(string id);
    }
}