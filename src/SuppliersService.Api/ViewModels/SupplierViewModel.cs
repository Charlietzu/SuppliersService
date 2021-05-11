using SuppliersService.Api.ViewModels.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuppliersService.Api.ViewModels
{
    public class SupplierViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(100, ErrorMessage = ErrorMessages.FieldMustBeBetween, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(14, ErrorMessage = ErrorMessages.FieldMustBeBetween, MinimumLength = 11)]
        public string Document { get; set; }
        public int SupplierType { get; set; }
        public AddressViewModel Address { get; set; }
        public bool Active { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
