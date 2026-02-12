using MemberManagement.Domain.Entities;
using System;
using Xunit;
using Assert = Xunit.Assert;

namespace MemberManagement.Test.Domain.Entities
{
    public class MemberTests
    {
        [Fact]
        public void Initialize_SetDefaultValues()
        {
            var memberTest = new Member 
            { 
                FirstName = "Juan",
                LastName = "dela Cruz",
                IsActive = false,
                DateCreated = DateTime.MinValue
            };
            memberTest.Initialize();
            Assert.True(memberTest.IsActive, "Initialize should set IsActive to true.");

            var timeDifference = DateTime.UtcNow - memberTest.DateCreated;
            Assert.True(timeDifference.TotalSeconds < 2, "DateCreated should be set to the current UTC time.");
        }
    }
}
