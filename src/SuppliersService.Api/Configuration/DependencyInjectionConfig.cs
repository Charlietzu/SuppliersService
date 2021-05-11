using Microsoft.Extensions.DependencyInjection;
using SuppliersService.Business.Interfaces;
using SuppliersService.Data.Context;
using SuppliersService.Data.Repository;

namespace SuppliersService.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            return services;
        }
    }
}
