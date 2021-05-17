using SuppliersService.Business.Models;
using System;
using System.Threading.Tasks;

namespace SuppliersService.Business.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<Supplier> GetSupplierAddress(Guid id);

        Task<Supplier> GetSupplierProductsAddress(Guid id);
    }
}