using Microsoft.EntityFrameworkCore;
using SuppliersService.Business.Interfaces;
using SuppliersService.Business.Models;
using SuppliersService.Data.Context;
using System;
using System.Threading.Tasks;

namespace SuppliersService.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<Address> GetAddressBySupplier(Guid supplierId)
        {
            return await Db.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(f => f.SupplierId == supplierId);
        }
    }
}