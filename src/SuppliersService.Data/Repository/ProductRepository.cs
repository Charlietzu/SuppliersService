using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuppliersService.Business.Interfaces;
using SuppliersService.Business.Models;
using SuppliersService.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace SuppliersService.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext context) : base(context) { }

        public async Task<Product> GetProductSupplier(Guid id)
        {
            return await Db.Products.AsNoTracking().Include(f => f.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsSuppliers()
        {
            return await Db.Products.AsNoTracking().Include(f => f.Supplier)
                .OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId)
        {
            return await Get(p => p.SupplierId == supplierId);
        }
    }
}