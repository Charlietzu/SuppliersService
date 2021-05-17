using SuppliersService.Business.Interfaces;
using SuppliersService.Business.Models;
using SuppliersService.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace SuppliersService.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository,
                              INotificator notificator) : base(notificator)
        {
            _productRepository = productRepository;
        }

        public async Task Create(Product product)
        {
            if (!ExecuteValidation(new ProductValidation(), product)) return;

            await _productRepository.Create(product);
        }

        public async Task Update(Product product)
        {
            if (!ExecuteValidation(new ProductValidation(), product)) return;

            await _productRepository.Update(product);
        }

        public async Task Delete(Guid id)
        {
            await _productRepository.Delete(id);
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}