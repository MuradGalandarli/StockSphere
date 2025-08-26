using Microsoft.EntityFrameworkCore;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Application.Dtos;
using StockSphere.Application.Repositories;
using StockSphere.Domain.Entities;
using StockSphere.Persistence.Repositories;
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
        private readonly IUnitOfWork _unitOfWork;

        public WarehouseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddWarehouse(string name, string location)
        {
            bool status = await _unitOfWork.WarehouseWriteRepository.AddAsync(new() { Location = location, Name = name });
            await _unitOfWork.WarehouseWriteRepository.SaveAsync();
            return status;
        }

        public List<WarehouseDto> GetAllWarehouse(int page, int size)
        {
            var result = _unitOfWork.WarehouseReadRepository.GetAll().Skip((page - 1) * size).Take(size);
            return result.Select(w => new WarehouseDto()
            {
                Location = w.Location,
                Name = w.Name,
                Id = w.Id
            }).ToList();

        }

        public async Task<WarehouseDto> GetByIdWarehouse(int id)
        {
            Warehouse warehouse = await _unitOfWork.WarehouseReadRepository.GetByIdAsync(id);
            if (warehouse == null)
            {
                return new();
            }
            return new WarehouseDto() { Location = warehouse.Location, Name = warehouse.Name, Id = warehouse.Id };
        }

        public async Task<bool> RemoveWarehouse(int id)
        {
            Warehouse? warehouse = await _unitOfWork.WarehouseReadRepository.GetWhere(w => w.Id == id).Include(s => s.Stocks).
                ThenInclude(p => p.Product).ThenInclude(c => c.Category).FirstOrDefaultAsync();
            if (warehouse == null)
                return false;

            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                _unitOfWork.WarehouseWriteRepository.Delete(warehouse);

                if (warehouse.Stocks.Count > 0)
                {
                    foreach (Stock stock in warehouse.Stocks)
                    {
                        _unitOfWork.WarehouseWriteRepository.Delete(warehouse);
                        if (stock.Product != null)
                            _unitOfWork.ProductWriteRepository.Delete(stock.Product);
                        if (stock.Product.Category != null)
                            _unitOfWork.CategoryWriteRepository.Delete(stock.Product.Category);
                    }
                }

                await transaction.CommitAsync();
                await _unitOfWork.WarehouseWriteRepository.SaveAsync();
                return true;
            }
            catch
            {
                await _unitOfWork.RollbackAsync(transaction);
                return false;
            }

        }

        public async Task<bool> WarehouseUpdate(Warehouse warehouse)
        {
            var result = await _unitOfWork.WarehouseReadRepository.GetSingleAsync(x => x.Id == warehouse.Id);
            if (result != null)
            {
                result.Name = warehouse.Name;
                result.Location = warehouse.Location;
                await _unitOfWork.WarehouseWriteRepository.SaveAsync();
                return true;
            }
            return false;
        }
    }
}
