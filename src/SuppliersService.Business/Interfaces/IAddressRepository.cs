using SuppliersService.Business.Models;
using System;
using System.Threading.Tasks;

namespace SuppliersService.Business.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetAddressBySupplier(Guid supplierId);
    }
}