using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuppliersService.Api.ViewModels.DataAnnotations
{
    public static class ErrorMessages
    {
        public const string RequiredField = "The field {0} is required";
        public const string FieldMustBeBetween = "The field {0} must be between {2} and {1} characters";
        public const string FieldMustBe = "The field must be {1} characters";
    }
}
