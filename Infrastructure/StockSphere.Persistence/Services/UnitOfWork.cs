using Microsoft.EntityFrameworkCore.Storage;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Repositories;
using StockSphere.Application.Repositories.Stock;
using StockSphere.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Persistence.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoryReadRepository CategoryReadRepository { get; }

        public ICategoryWriteRepository CategoryWriteRepository { get; }

        public IWarehouseReadRepository WarehouseReadRepository { get; }
        public IWarehouseWriteRepository WarehouseWriteRepository {  get; }

        public IProductReadRepository ProductReadRepository { get; }

        public IProductWriteRepository ProductWriteRepository { get; }

        public IStockWriteRepository StockWriteRepository { get; }

        public IStockReadRepository StockReadRepository { get; }

        public UnitOfWork(ICategoryReadRepository categoryReadRepository, 
            ICategoryWriteRepository categoryWriteRepository,
            IWarehouseReadRepository warehouseReadRepository,
            IWarehouseWriteRepository warehouseWriteRepository,
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IStockReadRepository stockReadRepository,
            IStockWriteRepository stockWriteRepository,
            ApplicationDbContext applicationDbContext
            )
        {
            CategoryReadRepository = categoryReadRepository;
            CategoryWriteRepository = categoryWriteRepository;
            WarehouseReadRepository = warehouseReadRepository;
            WarehouseWriteRepository = warehouseWriteRepository;
            ProductWriteRepository = productWriteRepository;    
            ProductReadRepository = productReadRepository;
            StockReadRepository = stockReadRepository;
            StockWriteRepository = stockWriteRepository;
            _context = applicationDbContext;
        }

        public async Task<int> CommitAsync()
        {
          return await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
          return await _context.Database.BeginTransactionAsync();
        }

        public async Task RollbackAsync(IDbContextTransaction transaction)
        {
            await transaction.RollbackAsync();
        }
    }
}
