using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesLabA1.Validation
{
    public class CustomerValidation : ValidationAttribute
    {
        public CustomerValidation()
        {
            ErrorMessage = "The year of birth cannot be greater than the current year.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            if (!int.TryParse(value.ToString(), out int number))
                return false;

            return number < DateTime.Now.Year;
        }
    }
}