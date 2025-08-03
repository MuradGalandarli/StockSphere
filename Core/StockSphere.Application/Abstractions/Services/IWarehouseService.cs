using StockSphere.Application.Dtos;
using StockSphere.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Abstractions.Services
{
    public interface IWarehouseService
    {
        public Task<bool> AddWarehouse(string name, string location);
        public List<WarehouseDto> GetAllWarehouse(int page,int size);
    }
}
