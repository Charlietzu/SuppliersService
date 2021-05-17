using FluentValidation;
using SuppliersService.Business.Models.Validations.Documents;

namespace SuppliersService.Business.Models.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        public SupplierValidation()
        {
            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("The field {PropertyName} must be provided")
                .Length(2, 100)
                .WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} characters");

            When(f => f.SupplierType == SupplierType.NaturalPerson, () =>
            {
                RuleFor(f => f.Document.Length).Equal(CpfValidation.CpfLength)
                    .WithMessage("The Document field must be {ComparisonValue} characters and {PropertyValue} has been provided.");
                RuleFor(f => CpfValidation.Validate(f.Document)).Equal(true)
                    .WithMessage("The document provided is invalid.");
            });

            When(f => f.SupplierType == SupplierType.JuridicalPerson, () =>
            {
                RuleFor(f => f.Document.Length).Equal(CnpjValidation.CnpjLength)
                    .WithMessage("The Document field must be {ComparisonValue} characters and {PropertyValue} has been provided.");
                RuleFor(f => CnpjValidation.Validate(f.Document)).Equal(true)
                    .WithMessage("The document provided is invalid.");
            });
        }
    }
}