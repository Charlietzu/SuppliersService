using System;
using System.Linq;
using System.Threading.Tasks;
using SuppliersService.Business.Interfaces;
using SuppliersService.Business.Models;
using SuppliersService.Business.Models.Validations;

namespace SuppliersService.Business.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IAddressRepository _addressRepository;

        public SupplierService(ISupplierRepository supplierRepository, 
                                 IAddressRepository addressRepository,
                                 INotificator notificator) : base(notificator)
        {
            _supplierRepository = supplierRepository;
            _addressRepository = addressRepository;
        }

        public async Task<bool> Create(Supplier supplier)
        {
            if (!ExecuteValidation(new SupplierValidation(), supplier) 
                || !ExecuteValidation(new AddressValidation(), supplier.Address)) return false;

            if (_supplierRepository.Get(f => f.Document == supplier.Document).Result.Any())
            {
                Notificate("There is already a supplier with this document informed.");
                return false;
            }

            await _supplierRepository.Create(supplier);
            return true;
        }

        public async Task<bool> Update(Supplier supplier)
        {
            if (!ExecuteValidation(new SupplierValidation(), supplier)) return false;

            if (_supplierRepository.Get(f => f.Document == supplier.Document && f.Id != supplier.Id).Result.Any())
            {
                Notificate("There is already a supplier with this document informed.");
                return false;
            }

            await _supplierRepository.Update(supplier);
            return true;
        }

        public async Task UpdateAddress(Address address)
        {
            if (!ExecuteValidation(new AddressValidation(), address)) return;

            await _addressRepository.Update(address);
        }

        public async Task<bool> Delete(Guid id)
        {
            if (_supplierRepository.GetSupplierProductsAddress(id).Result.Products.Any())
            {
                Notificate("The supplier has registered products!");
                return false;
            }

            var address = await _addressRepository.GetAddressBySupplier(id);

            if (address != null)
            {
                await _addressRepository.Delete(address.Id);
            }

            await _supplierRepository.Delete(id);
            return true;
        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
            _addressRepository?.Dispose();
        }
    }
}