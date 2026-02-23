using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Application.Validators.MemberValidators
{
    public class MaxDateTodayAttribute : ValidationAttribute
    {
        public MaxDateTodayAttribute() 
        {
            ErrorMessage = "Birthdate cannot be in the future.";
        }
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateOnly date)
            {
                if (date > DateOnly.FromDateTime(DateTime.Today))
                    return new ValidationResult(ErrorMessage);

                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid date format");
            
        }
    }
}
