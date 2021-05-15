using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SuppliersService.Api.Extensions;
using SuppliersService.Business.Interfaces;
using SuppliersService.Business.Notifications;
using SuppliersService.Business.Services;
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
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<INotificator, Notificator>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            return services;
        }
    }
}
