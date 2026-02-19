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

            if (dateOfBirth <= minimumBirthDate &&
                dateOfBirth >= maximumBirthDate)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(
                $"Age must be between {minAgeInYears} years and {maxAgeInYears} years {maxMonths} months {maxDays} day.");
        }
    }
}
