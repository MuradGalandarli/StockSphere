using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Persistence.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseWriteRepository _warehouseWriteRepository;

        public WarehouseService(IWarehouseWriteRepository warehouseWriteRepository)
        {
            _warehouseWriteRepository = warehouseWriteRepository;
        }

        public async Task<bool> AddWarehouse(string name, string location)
        {
           bool status = await _warehouseWriteRepository.AddAsync(new() { Location = location, Name = name });
           await _warehouseWriteRepository.SaveAsync();
           return status;
        }
    }
}
