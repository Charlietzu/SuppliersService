﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuppliersService.Api.ViewModels;
using SuppliersService.Business.Interfaces;
using SuppliersService.Business.Models;
using System;
using System.Threading.Tasks;

namespace SuppliersService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : MainController
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public AddressesController(IAddressRepository addressRepository,
                                   ISupplierService supplierService,
                                   IMapper mapper,
                                   INotificator notificator) : base(notificator)
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