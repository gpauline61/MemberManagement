using AutoMapper;
using MemberManagement.Application.DTO.BranchDTO;
using MemberManagement.Application.Services;
using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Interfaces;
using Moq;

namespace MemberManagement.Test.Services
{
    public class BranchServiceTests
    {
        private readonly Mock<IBranchRepository> _branchRepoMock;
        private readonly BranchService _branchService;

        public BranchServiceTests()
        {
            var _mapperMock = new Mock<IMapper>();
            _branchRepoMock = new Mock<IBranchRepository>();
            _branchService = new BranchService(_branchRepoMock.Object, _mapperMock.Object);
        }


        //Test for Creating a new branch
        [Fact]
        public async Task AddBranch_ShouldReturnCreatedBranch()
        {
            //Arrange
            var branch = new Branch { BranchID = 1, BranchName = "Catanduanes", BranchAddress = "San Roque" };
            
            _branchRepoMock.Setup(b => b.Add(branch)).Returns(true);

            var result = _branchService.AddBranch(branch); 

            Assert.NotNull(result);
            Assert.Equal(true, result);
        }

        //Test for Reading a branch
        [Fact]
        public async Task DetailBranch_ShouldReturnBranch_WhenExists()
        {
            var mapperMock = new Mock<IMapper>();
            var branch = new Branch { BranchID = 1, BranchName = "Catanduanes", BranchAddress = "San Roque" };
            var branchDTO = new BranchDetailDTO { BranchID = 1, BranchName = "Catanduanes", BranchAddress = "San Roque" };

            _branchRepoMock.Setup(b => b.DetailBranch(1)).ReturnsAsync(branch);
            mapperMock.Setup(m => m.Map<BranchDetailDTO>(branch)).Returns(branchDTO);

            var branchservice = new BranchService(_branchRepoMock.Object, mapperMock.Object);
            var result = await branchservice.DetailBranch(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.BranchID);
        }

        [Fact]
        public async Task EditBranch_ShouldReturnNotNull_WhenBranchExists()
        {
            var existingBranch = new Branch { BranchID = 1, BranchName = "Catanduanes", BranchAddress = "San Roque" };
            var updatedBranch = new Branch { BranchName = "Virac", BranchAddress = "San Roque" };

            _branchRepoMock.Setup(b => b.SaveEditBranch(1, existingBranch));

            var result = _branchService.SaveEditBranch(1, updatedBranch);

            Assert.NotNull(result);
            Assert.Equal("Catanduanes", existingBranch.BranchName);

        }

        [Fact]
        public async Task DeleteBranch_VerifyInteraction_WhenBranchExists()
        {
            //var branch = new Branch { BranchID = 1, BranchName = "Catanduanes", BranchAddress = "San Roque" };
            //_branchRepoMock.Setup(b => b.DeleteConfirmed(1));

            await _branchService.DeleteConfirmed(1);

            _branchRepoMock.Verify(b => b.DeleteConfirmed(1), Times.Once);
        }
    }
}
