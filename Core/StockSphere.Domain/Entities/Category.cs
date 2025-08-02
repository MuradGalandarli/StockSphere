﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; } = null!;   
        public string? Description { get; set; }
        public ICollection<Product> Products { get; set; }  
    }
}
