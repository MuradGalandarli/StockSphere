using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StockSphere.Application.Repositories;
using StockSphere.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public WriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T t)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(t);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRange(List<T> t)
        {
             await Table.AddRangeAsync(t);
            return true;
        }

        public bool Delete(T t)
        {
           EntityEntry<T> entityEntry = Table.Remove(t);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<int> SaveAsync()
        {
          return await _context.SaveChangesAsync();
        }

        public bool Update(T t)
        {
           EntityEntry<T> entity = Table.Update(t);
           return entity.State == EntityState.Modified;
        }
    }
}
