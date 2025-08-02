using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Barcode { get; set; }
        public string? SKU { get; set; }
        public int? CategoryId { get; set; }
        public string? UnitOfMeasure { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Stock> Stocks { get; set; }
        public Category Category { get; set; }
    }
}
