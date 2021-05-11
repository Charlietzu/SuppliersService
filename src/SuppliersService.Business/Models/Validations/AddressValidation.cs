using FluentValidation;

namespace SuppliersService.Business.Models.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(c => c.PublicArea)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 200).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.District)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 100).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.PostalCode)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(8).WithMessage("The {PropertyName} field must be {MaxLength} characters");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 100).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 50).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(1, 50).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");
        }
    }
}