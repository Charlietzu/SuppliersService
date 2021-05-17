using SuppliersService.Business.Models;
using System;
using System.Threading.Tasks;

namespace SuppliersService.Business.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task Create(Product product);

        Task Update(Product product);

        Task Delete(Guid id);
    }
}