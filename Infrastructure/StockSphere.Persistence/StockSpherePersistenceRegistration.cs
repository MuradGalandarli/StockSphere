using Microsoft.Extensions.DependencyInjection;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Repositories;
using StockSphere.Application.Repositories.Stock;
using StockSphere.Persistence.Context;
using StockSphere.Persistence.Repositories;
using StockSphere.Persistence.Repositories.Stock;
using StockSphere.Persistence.Services;

namespace StockSphere.Persistence
{
    public static class StockSpherePersistenceRegistration
    {
        public static void StockSpherePersistenceRegistrationAdd(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IWarehouseWriteRepository, WarehouseWriteRepository>();
            services.AddScoped<IWarehouseReadRepository, WarehouseReadRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStockWriteRepository, StockWriteRepository>();
            services.AddScoped<IStockReadRepository, StockReadRepository>();
          
        }
    }
}
