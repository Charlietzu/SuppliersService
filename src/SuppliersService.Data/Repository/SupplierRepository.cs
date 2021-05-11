using System;
using System.Threading.Tasks;
using SuppliersService.Business.Interfaces;
using SuppliersService.Business.Models;
using SuppliersService.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace SuppliersService.Data.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<Supplier> GetSupplierAddress(Guid id)
        {
            return await Db.Suppliers.AsNoTracking()
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Supplier> GetSupplierProductsAddress(Guid id)
        {
            return await Db.Suppliers.AsNoTracking()
                .Include(c => c.Products)
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}