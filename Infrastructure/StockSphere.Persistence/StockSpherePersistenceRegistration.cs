using Microsoft.Extensions.DependencyInjection;
using StockSphere.Application.Abstractions.Services;
using StockSphere.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSphere.Persistence
{
    public static class StockSpherePersistenceRegistration
    {
        public static void StockSpherePersistenceRegistrationAdd(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
