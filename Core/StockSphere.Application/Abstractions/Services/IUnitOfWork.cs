using Microsoft.EntityFrameworkCore.Storage;
using StockSphere.Application.Repositories;
using StockSphere.Application.Repositories.Stock;
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
        public IProductReadRepository ProductReadRepository { get; }    
        public IProductWriteRepository ProductWriteRepository { get; }
        public IStockWriteRepository StockWriteRepository { get; }
        public IStockReadRepository StockReadRepository { get; }
        Task<int> CommitAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task RollbackAsync(IDbContextTransaction transaction);

    }
}
