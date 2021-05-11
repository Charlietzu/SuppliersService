﻿using System;
using System.Threading.Tasks;
using SuppliersService.Business.Models;

namespace SuppliersService.Business.Interfaces
{
    public interface ISupplierService : IDisposable
    {
        Task<bool> Create(Supplier supplier);
        Task<bool> Update(Supplier supplier);
        Task<bool> Delete(Guid id);

        Task UpdateAddress(Address address);
    }
}