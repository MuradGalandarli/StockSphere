using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Application.Excetions
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException() : base("Xeta alindi") { }

        public LoginFailedException(string message) : base(message) { }
        public LoginFailedException(string message,Exception exception):base(message,exception)
        {
            
        }

    }
}
