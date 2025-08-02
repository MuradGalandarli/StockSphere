using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Domain.Entities
{
    public class Warehouse:BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Location { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Stock> Stocks { get; set; }
    }
}
