using MemberManagement.Application.Validators.MemberValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Test.Validators
{
    public class AgeRangeAttributeTests
    {
        [Theory]
        [InlineData(-17, 0, 0, false)] //under 18 years old
        [InlineData(-18, 0, 0, true)] //18 years old
        [InlineData(-30, 0, 0, true)] //30 years old
        [InlineData(-65, 0, 0, true)] //65 years old
        [InlineData(-65, -6, -1, true)] //Exactly 65 years 6 months 1 day old
        [InlineData(-65, -6, -2, false)] // more than 65 years 6 months and 1 day old
        public void AgeRangeValidation_WorksIfAgeWithinRange(int yearsOffset, 
            int monthsOffset, int daysOffset, bool expectedIsValid)
        {
            //Arrange
            var birthDate = DateOnly.FromDateTime(DateTime.Today)
                .AddYears(yearsOffset).AddMonths(monthsOffset).AddDays(daysOffset);

            var ageAttribute = new AgeRangeAttribute();
            var context = new ValidationContext(new { BirthDate = birthDate });

            //Act
            var result = ageAttribute.GetValidationResult(birthDate, context);

            //Assert
            if (expectedIsValid)
                Assert.Equal(ValidationResult.Success, result);
            else
                Assert.NotEqual(ValidationResult.Success, result);
        }
    }
}
