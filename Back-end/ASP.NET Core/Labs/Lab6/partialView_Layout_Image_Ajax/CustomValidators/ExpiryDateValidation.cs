using System.ComponentModel.DataAnnotations;

namespace partialView_Layout_Image_Ajax.CustomValidators
{
    public class ExpiryDateValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("ExpiryDate required");

            if (value is not DateOnly date) return new ValidationResult("Expiry Date is invalid");

            if (date <= DateOnly.FromDateTime(DateTime.Today))
                return new ValidationResult("Expiry date must be in the future");

            return ValidationResult.Success;
        }
        //public void AddValidation(ClientModelValidationContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
