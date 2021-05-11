using System;
using System.Threading.Tasks;
using SuppliersService.Business.Models;

namespace SuppliersService.Business.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(Guid id);
    }
}