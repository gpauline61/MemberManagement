using AutoMapper;
using MemberManagement.Application.DTO.MembershipDTO;
using MemberManagement.Application.Services;
using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Interfaces;
using Moq;

namespace MemberManagement.Test.Services
{
    public class MembershipServiceTests
    {
        private readonly Mock<IMembershipRepository> _membershipRepoMock;
        private readonly MembershipService _membershipService;

        public MembershipServiceTests()
        {
            var _mapperMock = new Mock<IMapper>();
            _membershipRepoMock = new Mock<IMembershipRepository>();
            _membershipService = new MembershipService(_membershipRepoMock.Object, _mapperMock.Object);
        }


        [Fact]
        public async Task AddMembership_ShouldReturnCreatedMembership()
        {
            //Arrange
            var membership = new Membership { MembershipID = 1, MembershipType = "Regular", MembershipDescription = "Main membership type." };

            _membershipRepoMock.Setup(b => b.Add(membership)).Returns(true);

            var result = _membershipService.AddMembership(membership);

            Assert.NotNull(result);
            Assert.Equal(true, result);
        }

        [Fact]
        public async Task DetailMembership_ShouldReturnMembership_WhenExists()
        {
            var mapperMock = new Mock<IMapper>();
            var membership = new Membership { MembershipID = 1, MembershipType = "Regular", MembershipDescription = "Main membership type." };
            var membershipDTO = new MembershipDetailDTO { MembershipID = 1, MembershipType = "Regular", MembershipDescription = "Main membership type." };

            _membershipRepoMock.Setup(b => b.DetailMembership(1)).ReturnsAsync(membership);
            mapperMock.Setup(m => m.Map<MembershipDetailDTO>(membership)).Returns(membershipDTO);

            var membershipservice = new MembershipService(_membershipRepoMock.Object, mapperMock.Object);
            var result = await membershipservice.DetailMembership(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.MembershipID);
        }

        [Fact]
        public async Task EditMembership_ShouldReturnNotNull_WhenMembershipExists()
        {
            var existingMembership = new Membership { MembershipID = 1, MembershipType = "Regular", MembershipDescription = "Main membership type." };
            var updatedMembership = new Membership { MembershipType = "Extension", MembershipDescription = "Under Regular." };

            _membershipRepoMock.Setup(b => b.SaveEditMembership(1, existingMembership));

            var result = _membershipService.SaveEditMembership(1, updatedMembership);

            Assert.NotNull(result);
            Assert.Equal("Regular", existingMembership.MembershipType);

        }

        [Fact]
        public async Task DeleteMembership_VerifyInteraction_WhenMembershipExists()
        {
            await _membershipService.DeleteConfirmed(1);

            _membershipRepoMock.Verify(b => b.DeleteConfirmed(1), Times.Once);
        }
    }
}
