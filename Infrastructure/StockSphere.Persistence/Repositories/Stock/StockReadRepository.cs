using StockSphere.Application.Repositories.Stock;
using StockSphere.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Persistence.Repositories.Stock
{
    public class StockReadRepository : ReadRepository<Domain.Entities.Stock>, IStockReadRepository
    {

        public StockReadRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext) { }
      
    }
}
