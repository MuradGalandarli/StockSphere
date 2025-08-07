using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Repositories
{
    public interface IWriteRepository<T> :IRepository<T> where T :class
    {
        public Task<bool> AddAsync(T t);
        public bool UpdateAsync(T t);
        public bool Delete(T t);
        public Task<bool> AddRange(List<T> t);
        public Task<int> SaveAsync();
    }
}
