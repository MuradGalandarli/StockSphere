﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Dtos
{
    public class WarehouseDto
    {
        public string Name { get; set; } = null!;
        public string? Location { get; set; }
    }
}
