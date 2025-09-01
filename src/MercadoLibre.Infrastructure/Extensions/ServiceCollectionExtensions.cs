using MercadoLibre.Core.Interfaces;
using MercadoLibre.Core.Services;
using MercadoLibre.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace MercadoLibre.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, JsonProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}