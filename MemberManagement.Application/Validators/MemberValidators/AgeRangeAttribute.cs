using System;
using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Application.Validators.MemberValidators
{
    public class AgeRangeAttribute : ValidationAttribute
    {
        private readonly int minAgeInYears = 18;
        private readonly int maxAgeInYears = 65;
        private readonly int maxMonths = 6;
        private readonly int maxDays = 1;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (!((DateOnly)value is DateOnly dateOfBirth))
                return new ValidationResult("Invalid date format.");

            var today = DateOnly.FromDateTime(DateTime.Today);

            var minimumBirthDate = today.AddYears(-minAgeInYears);
            var maximumBirthDate = today
                .AddYears(-maxAgeInYears)
                .AddMonths(-maxMonths)
                .AddDays(-maxDays);

            if (dateOfBirth > minimumBirthDate)
                return new ValidationResult($"Age must be at least {minAgeInYears}.");
            
            if(dateOfBirth < maximumBirthDate)
                return new ValidationResult($"Age must not exceed to {maxAgeInYears} years 6 months and 1 day.");

            return ValidationResult.Success;
        }
    }
}
