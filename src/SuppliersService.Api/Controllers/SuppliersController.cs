using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuppliersService.Api.ViewModels;
using SuppliersService.Business.Interfaces;
using SuppliersService.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuppliersService.Api.Controllers
{
    [Route("api/[controller]")]
    public class SuppliersController : MainController
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierRepository supplierRepository,
                                   ISupplierService supplierService,
                                   IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _supplierService = supplierService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierViewModel>>> GetAll()
        {
            IEnumerable<SupplierViewModel> suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());
            return Ok(suppliers);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> GetById(Guid id)
        {
            SupplierViewModel supplier = _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierProductsAddress(id));

            if (supplier == null) return NotFound();

            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierViewModel>> Create(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            Supplier supplier = _mapper.Map<Supplier>(supplierViewModel);

            bool result = await _supplierService.Create(supplier);

            if (!result) return BadRequest();

            return Ok(supplier);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> Update(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id || !ModelState.IsValid) return BadRequest();

            Supplier supplier = _mapper.Map<Supplier>(supplierViewModel);

            bool result = await _supplierService.Update(supplier);

            if (!result) return BadRequest();

            return Ok(supplier);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> Delete(Guid id)
        {
            SupplierViewModel supplier = _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierAddress(id));

            if (supplier == null) return NotFound();

            bool result = await _supplierService.Delete(id);

            if (!result) return BadRequest();

            return Ok(supplier);
        }

    }
}
