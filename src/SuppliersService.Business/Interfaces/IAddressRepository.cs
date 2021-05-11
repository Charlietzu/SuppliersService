using System;
using System.Threading.Tasks;
using SuppliersService.Business.Models;

namespace SuppliersService.Business.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetAddressBySupplier(Guid supplierId);
    }
}