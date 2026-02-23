using MemberManagement.Application.Validators.MemberValidators;
using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Test.Validators
{
    public class MaxDateTodayAttributeTests
    {
        [Theory]
        [InlineData(0, true)] //today
        [InlineData(-1, true)] //yesterday
        [InlineData(1, false)] //tomorrow
        [InlineData(30, false)] //future dates
        public void MaxDateTodayAttribute_WorksIfTodayAndPastDates(int daysOffset, bool expectedIsValid)
        {
            //Arrange
            var date = DateOnly.FromDateTime(DateTime.Today).AddDays(daysOffset);
            var dateAttribute = new MaxDateTodayAttribute();
            var context = new ValidationContext(new { BirthDate = date });

            //Act
            var result = dateAttribute.GetValidationResult(date, context);

            //Assert
            if (expectedIsValid)
                Assert.Equal(ValidationResult.Success, result);
            else
                Assert.NotEqual(ValidationResult.Success, result);
        }
    }
}
