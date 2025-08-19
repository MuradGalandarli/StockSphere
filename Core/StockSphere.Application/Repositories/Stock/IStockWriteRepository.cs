using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StockSphere.Application.Repositories
{
    public interface IStockWriteRepository:IWriteRepository<Domain.Entities.Stock>
    {
    }
}
