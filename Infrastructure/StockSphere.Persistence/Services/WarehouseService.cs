using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using StockSphere.Application.Repositories;
using StockSphere.Domain.Entities;
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
        private readonly IWarehouseReadRepository _warehouseReadRepository;

        public WarehouseService(IWarehouseWriteRepository warehouseWriteRepository, IWarehouseReadRepository warehouseReadRepository)
        {
            _warehouseWriteRepository = warehouseWriteRepository;
            _warehouseReadRepository = warehouseReadRepository;
        }

        public async Task<bool> AddWarehouse(string name, string location)
        {
           bool status = await _warehouseWriteRepository.AddAsync(new() { Location = location, Name = name });
           await _warehouseWriteRepository.SaveAsync();
           return status;
        }

        public List<WarehouseDto> GetAllWarehouse(int page, int size)
        {
            var result = _warehouseReadRepository.GetAll().Skip((page-1)*size).Take(size);
           return result.Select(w => new WarehouseDto()
            {
                Location = w.Location,
                Name = w.Name,
            }).ToList();

        }

        public async Task<bool> WarehouseUpdate(Warehouse warehouse)
        {
           var result = await _warehouseReadRepository.GetSingleAsync(x => x.Id == warehouse.Id);
            if (result != null)
            {
                result.Name = warehouse.Name;
                result.Location = warehouse.Location;
                await _warehouseWriteRepository.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
