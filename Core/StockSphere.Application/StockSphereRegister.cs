using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StockSphere.Application.Validators.Warehouse;


namespace StockSphere.Application
{
    public static class StockSphereRegister
    {
        public static void StockSphereRegisterAdd(this IServiceCollection services)
        {
            services.AddMediatR(typeof(StockSphereRegister));
            services.AddAutoMapper(typeof(StockSphereRegister));
            services.AddValidatorsFromAssemblyContaining<WarehouseAddCommandRequestValidator>();
            services.AddFluentValidationAutoValidation();
        }
    }
}
