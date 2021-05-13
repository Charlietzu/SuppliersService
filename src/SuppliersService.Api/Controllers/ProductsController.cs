using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuppliersService.Api.ViewModels;
using SuppliersService.Business.Interfaces;
using SuppliersService.Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SuppliersService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : MainController
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository productRepository,
                                  IProductService productService,
                                  IMapper mapper,
                                  INotificator notificator) : base(notificator)
        {
            _productRepository = productRepository;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAll()
        {
            IEnumerable <ProductViewModel> products = _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductsSuppliers());
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
        {
            ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(await _productRepository.GetProductSupplier(id));

            if (productViewModel == null) return NotFound();

            return Ok(productViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProductViewModel>> Delete(Guid id)
        {
            ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(await _productRepository.GetProductSupplier(id));

            if (productViewModel == null) return NotFound();

            await _productService.Delete(id);

            return CustomResponse(productViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            string nameImg = Guid.NewGuid() + "_" + productViewModel.Image;

            if(!UploadFile(productViewModel.ImageUpload, nameImg))
            {
                return CustomResponse(productViewModel);
            }

            productViewModel.Image = nameImg;
            await _productService.Create(_mapper.Map<Product>(productViewModel));

            return CustomResponse(productViewModel);
        }

        private bool UploadFile(string file, string nameImg)
        {
            byte[] imageDataByteArray = Convert.FromBase64String(file);

            if(string.IsNullOrEmpty(file))
            {
                NotifyError("Please provide an image for this product");
                return false;
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", nameImg);

            if (System.IO.File.Exists(filePath))
            {
                NotifyError("A file with this name already exists");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
    }
}
