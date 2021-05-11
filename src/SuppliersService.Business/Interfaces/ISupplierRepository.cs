using System;
using System.Threading.Tasks;
using SuppliersService.Business.Models;

namespace SuppliersService.Business.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> GetSupplierAddress(Guid id);
        Task<Supplier> GetSupplierProductsAddress(Guid id);
    }
}