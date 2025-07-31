using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Dtos
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
