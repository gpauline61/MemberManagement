using System;
using System.Collections.Generic;
using System.Text;
using MemberManagement.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace MemberManagement.Test.Entities
{
    public class MemberTests
    {
        [Fact]
        public void CreateMember_WithValidData()
        {
            var lastname = "dela Cruz";
            var firstname = "Juan";

            var member = new Member(firstname, lastname);

            member.LastName.Should().Be(lastname);
            member.FirstName.Should().Be(firstname);
        }

    }

}
