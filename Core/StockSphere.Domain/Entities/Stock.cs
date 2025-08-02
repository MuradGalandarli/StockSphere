using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Domain.Entities
{
    public class Stock:BaseEntity
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public decimal Quantity { get; set; }
        public Product? Product { get; set; }    
        public Warehouse? Warehouse { get; set; }    
    }
}
