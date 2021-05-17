using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuppliersService.Api.Extensions;
using SuppliersService.Api.ViewModels;
using SuppliersService.Business.Interfaces;
using SuppliersService.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuppliersService.Api.Controllers
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SuppliersController : MainController
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierRepository supplierRepository,
                                   ISupplierService supplierService,
                                   IMapper mapper,
                                   INotificator notificator,
                                   IUser user) : base(notificator, user)
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
            SupplierViewModel supplierViewModel = _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierProductsAddress(id));

            if (supplierViewModel == null) return NotFound();

            return Ok(supplierViewModel);
        }

        [ClaimsAuthorize("Supplier", "Add")]
        [HttpPost]
        public async Task<ActionResult<SupplierViewModel>> Add(SupplierViewModel supplierViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _supplierService.Create(_mapper.Map<Supplier>(supplierViewModel));

            //Here i am not passing our <Supplier> supplier object to prevent our Business layer exposion
            return CustomResponse(supplierViewModel);
        }

        [ClaimsAuthorize("Supplier", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> Update(Guid id, SupplierViewModel supplierViewModel)
        {
            if (id != supplierViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _supplierService.Update(_mapper.Map<Supplier>(supplierViewModel));

            return CustomResponse(ModelState);
        }

        [ClaimsAuthorize("Supplier", "Delete")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SupplierViewModel>> Delete(Guid id)
        {
            SupplierViewModel supplierViewModel = _mapper.Map<SupplierViewModel>(await _supplierRepository.GetSupplierAddress(id));

            if (supplierViewModel == null) return NotFound();

            await _supplierService.Delete(id);

            return CustomResponse();
        }
    }
}