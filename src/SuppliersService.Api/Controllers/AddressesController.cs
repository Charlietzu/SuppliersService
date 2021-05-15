using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuppliersService.Api.Extensions;
using SuppliersService.Api.ViewModels;
using SuppliersService.Business.Interfaces;
using SuppliersService.Business.Models;
using System;
using System.Threading.Tasks;

namespace SuppliersService.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressesController : MainController
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public AddressesController(IAddressRepository addressRepository,
                                   ISupplierService supplierService,
                                   IMapper mapper,
                                   INotificator notificator,
                                   IUser user) : base(notificator, user)
        {
            _addressRepository = addressRepository;
            _supplierService = supplierService;
            _mapper = mapper;
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AddressViewModel>> GetById(Guid id)
        {
            AddressViewModel addressViewModel = _mapper.Map<AddressViewModel>(await _addressRepository.GetById(id));

            if (addressViewModel == null) return NotFound();

            return Ok(addressViewModel);
        }

        [ClaimsAuthorize("Supplier", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AddressViewModel>> Update(Guid id, AddressViewModel addressViewModel)
        {
            if (id != addressViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);
             
            await _supplierService.UpdateAddress(_mapper.Map<Address>(addressViewModel));

            return CustomResponse(addressViewModel);
        }
    }
}
