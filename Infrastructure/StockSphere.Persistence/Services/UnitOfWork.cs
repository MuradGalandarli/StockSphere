using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Repositories;
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

        public UnitOfWork(ICategoryReadRepository categoryReadRepository, 
            ICategoryWriteRepository categoryWriteRepository,
            IWarehouseReadRepository warehouseReadRepository,
            IWarehouseWriteRepository warehouseWriteRepository,
            ApplicationDbContext applicationDbContext)
        {
            CategoryReadRepository = categoryReadRepository;
            CategoryWriteRepository = categoryWriteRepository;
            WarehouseReadRepository = warehouseReadRepository;
            WarehouseWriteRepository = warehouseWriteRepository;
            _context = applicationDbContext;
        }

        public async Task<int> CommitAsync()
        {
          return await _context.SaveChangesAsync();
        }
    }
}
