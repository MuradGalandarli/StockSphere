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
    public class WarehouseWriteRepository:WriteRepository<Warehouse>,IWarehouseWriteRepository
    {
        public WarehouseWriteRepository(ApplicationDbContext context):base(context) { }
       
    }
}
