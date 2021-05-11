using SuppliersService.Api.ViewModels.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace SuppliersService.Api.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public Guid SupplierId { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(200, ErrorMessage = ErrorMessages.FieldMustBeBetween, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(1000, ErrorMessage = ErrorMessages.FieldMustBeBetween, MinimumLength = 2)]
        public string Description { get; set; }
        public string Image { get; set; }
        public string ImageUpload { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        public decimal Value { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }

        [ScaffoldColumn(false)]
        public string SupplierName { get; set; }
    }
}
