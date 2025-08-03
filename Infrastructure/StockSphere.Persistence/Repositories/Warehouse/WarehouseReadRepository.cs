using StockSphere.Application.Repositories;
using StockSphere.Domain.Entities;
using StockSphere.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Persistence.Repositories
{
    public class WarehouseReadRepository : ReadPepository<Warehouse>, IWarehouseReadRepository
    {
        public WarehouseReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
