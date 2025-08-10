using StockSphere.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Abstractions.Services
{
    public interface IUnitOfWork
    {
        public ICategoryReadRepository CategoryReadRepository { get; }
        public ICategoryWriteRepository CategoryWriteRepository { get; }
        public IWarehouseReadRepository WarehouseReadRepository { get; }
        public IWarehouseWriteRepository WarehouseWriteRepository { get; }
        Task<int> CommitAsync();

    }
}
