using Microsoft.EntityFrameworkCore;
using StockSphere.Application.Repositories;
using StockSphere.Domain.Entities;
using StockSphere.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Persistence.Repositories
{
    public class ReadPepository<T> : IReadRepository<T> where T : BaseEntity 
    {
        private readonly ApplicationDbContext _context;
        public ReadPepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll() => Table;
        

        public  async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetSingleAsync(System.Linq.Expressions.Expression<Func<T, bool>> method)
        {
         return await Table.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> method)
        {
           return Table.Where(method);
        }
    }
}
