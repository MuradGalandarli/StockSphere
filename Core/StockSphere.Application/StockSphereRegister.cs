using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace StockSphere.Application
{
    public static class StockSphereRegister
    {
        public static void StockSphereRegisterAdd(this IServiceCollection services)
        {
            services.AddMediatR(typeof(StockSphereRegister));
           
        }
    }
}
