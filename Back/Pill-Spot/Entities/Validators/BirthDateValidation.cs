using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validators
{
    public class BirthDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not DateTime birthDate)
                return new ValidationResult("Invalid date format.");

            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateTime.Today.AddYears(-age)) age--;

            return (age >= 0 && age <= 120)
                ? ValidationResult.Success
                : new ValidationResult("You must be between 0 and 120 years old.");
        }
    }
}
