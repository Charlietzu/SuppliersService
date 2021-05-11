using SuppliersService.Api.ViewModels.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace SuppliersService.Api.ViewModels
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(200, ErrorMessage = ErrorMessages.FieldMustBeBetween, MinimumLength = 2)]
        public string PublicArea { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(50, ErrorMessage = ErrorMessages.FieldMustBeBetween, MinimumLength = 1)]
        public string Number { get; set; }
        public string Complement { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(8, ErrorMessage = ErrorMessages.FieldMustBe, MinimumLength = 8)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(100, ErrorMessage = ErrorMessages.FieldMustBeBetween, MinimumLength = 2)]
        public string District { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(100, ErrorMessage = ErrorMessages.FieldMustBeBetween, MinimumLength = 2)]
        public string City { get; set; }

        [Required(ErrorMessage = ErrorMessages.RequiredField)]
        [StringLength(50, ErrorMessage = ErrorMessages.FieldMustBeBetween, MinimumLength = 2)]
        public string State { get; set; }
        public Guid SupplierId { get; set; }
    }
}
