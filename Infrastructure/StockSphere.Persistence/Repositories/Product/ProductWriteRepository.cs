using StockSphere.Application.Repositories;
using StockSphere.Persistence.Context;
using StockSphere.Domain.Entities;

namespace StockSphere.Persistence.Repositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
