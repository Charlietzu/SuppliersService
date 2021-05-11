using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuppliersService.Api.ViewModels;
using SuppliersService.Business.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuppliersService.Api.Controllers
{
    [Route("api/[controller]")]
    public class SuppliersController : MainController
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SuppliersController(ISupplierRepository supplierRepository,
                                   IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<SupplierViewModel>>> GetAll()
        {
            IEnumerable<SupplierViewModel> suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(await _supplierRepository.GetAll());
            return Ok(suppliers);
        }
    }
}
