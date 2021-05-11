using System;
using System.Threading.Tasks;
using SuppliersService.Business.Interfaces;
using SuppliersService.Business.Models;
using SuppliersService.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace SuppliersService.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(MyDbContext context) : base(context) { }

        public async Task<Address> GetAddressBySupplier(Guid supplierId)
        {
            return await Db.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(f => f.SupplierId == supplierId);
        }
    }
}