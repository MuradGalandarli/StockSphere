using StockSphere.Application.Repositories;
using StockSphere.Application.Repositories.Stock;
using StockSphere.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Persistence.Repositories.Stock
{
    public class StockWriteRepository : WriteRepository<Domain.Entities.Stock>, IStockWriteRepository
    {
        public StockWriteRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext) { }
    }
}
