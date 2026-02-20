using AutoMapper;
using MemberManagement.Application.DTO.MemberDTO;
using MemberManagement.Application.Services;
using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Interfaces;
using MemberManagement.Web.ViewModels.MemberVM;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Test.Services
{
    public class MemberServiceTests
    {
        private readonly Mock<IMemberRepository> _memberRepoMock;
        private readonly MemberService _memberService;

        public MemberServiceTests()
        {
            var _mapperMock = new Mock<IMapper>();
            _memberRepoMock = new Mock<IMemberRepository>();
            _memberService = new MemberService(_memberRepoMock.Object, _mapperMock.Object);
        }


        [Fact]
        public async Task AddMember_ShouldReturnCreatedMember()
        {
            //Arrange
            var member = new Member 
            { 
                MemberID = 1, 
                LastName = "dela Cruz", 
                FirstName = "Juan", 
                IsActive = true, 
                DateCreated = DateTime.UtcNow 
            }; 

            _memberRepoMock.Setup(b => b.Add(member)).Returns(true);

            var result = _memberService.AddMember(member);

            Assert.NotNull(result);
            Assert.Equal(true, result);
        }

        [Fact]
        public async Task DetailMember_ShouldReturnMember_WhenExists()
        {
            var mapperMock = new Mock<IMapper>();
            var member = new Member
            {
                MemberID = 1,
                LastName = "dela Cruz",
                FirstName = "Juan"
            };
            var memberDTO = new MemberDetailDTO {
                MemberID = 1,
                LastName = "dela Cruz",
                FirstName = "Juan"
            };

            _memberRepoMock.Setup(b => b.DetailMember(1)).ReturnsAsync(member);
            mapperMock.Setup(m => m.Map<MemberDetailDTO>(member)).Returns(memberDTO);

            var memberservice = new MemberService(_memberRepoMock.Object, mapperMock.Object);
            var result = await memberservice.DetailMember(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.MemberID);
        }

        [Fact]
        public async Task EditMember_ShouldReturnNotNull_WhenMemberExists()
        {
            var existingMember = new Member 
            { 
                MemberID = 1, 
                LastName = "dela Cruz", 
                FirstName = "Juan",
                IsActive = true
            };
            var updatedMember = new Member
            {
                MemberID = 1,
                LastName = "dela Cruz",
                FirstName = "Juan",
                IsActive = false
            };

            _memberRepoMock.Setup(b => b.SaveEditMember(1, existingMember));

            var result = _memberService.SaveEditMember(1, updatedMember);

            Assert.NotNull(result);
            Assert.Equal("dela Cruz", existingMember.LastName);

        }

        [Fact]
        public async Task DeleteMember_VerifyInteraction_WhenMemberExists()
        {
            await _memberService.DeleteConfirmed(1);

            _memberRepoMock.Verify(b => b.DeleteConfirmed(1), Times.Once);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();

            Validator.TryValidateObject(model, context, results, true);
            return results;
        }

        [Fact]
        public async Task Pass_When_Age_Within_Range()
        {
            var memberVM = new MemberCreateViewModel
            {
                LastName = "dela Cruz",
                FirstName = "Juan",
                Birthdate = DateOnly.FromDateTime(DateTime.Today).AddYears(-30)
            };

            var result = ValidateModel(memberVM);

            Assert.Empty(result);
        }

        [Fact]
        public void Fail_When_Age_Less_Than_18()
        {
            var memberVM = new MemberCreateViewModel
            {
                LastName = "dela Cruz",
                FirstName = "Juan",
                Birthdate = DateOnly.FromDateTime(DateTime.Today).AddYears(-17)
            };

            var result = ValidateModel(memberVM);

            Assert.NotEmpty(result);
        }

        [Fact]
        public void Fail_When_Age_Greater_Than_65_Years_6_Months_1_Day()
        {
            var memberVM = new MemberCreateViewModel
            {
                LastName = "dela Cruz",
                FirstName = "Juan",
                Birthdate = DateOnly.FromDateTime(DateTime.Today).AddYears(-66)
            };

            var result = ValidateModel(memberVM);

            Assert.NotEmpty(result);
        }

    }
}
