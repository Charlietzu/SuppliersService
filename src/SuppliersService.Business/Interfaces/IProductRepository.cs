using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuppliersService.Business.Models;

namespace SuppliersService.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId);
        Task<IEnumerable<Product>> GetProductsSuppliers();
        Task<Product> GetProductSupplier(Guid id);
    }
}