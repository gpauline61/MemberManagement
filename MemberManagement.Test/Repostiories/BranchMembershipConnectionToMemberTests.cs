using MemberManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement.Test.Repostiories
{
    public class MemberManagementContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Membership> Memberships { get; set; }

        public MemberManagementContext(DbContextOptions<MemberManagementContext> options) :base(options) { }
    }
    public class BranchMembershipConnectionToMemberTests
    {
        [Fact]
        public void CanIncludeBranches_WorksIfValid()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<MemberManagementContext>()
                .UseInMemoryDatabase(databaseName: "MMSDb")
                .Options;

            using (var context = new MemberManagementContext(options))
            {
                var branch = new Branch { BranchID = 1, BranchName = "Virac" };
                var member = new Member { MemberID = 1, LastName = "dela Cruz", FirstName = "Juan", Branch = branch };
                var member2 = new Member { MemberID = 2, LastName = "Sanchez", FirstName = "Pedro", Branch = branch };

                context.Members.Add(member);
                context.Branches.Add(branch);
                context.SaveChanges();
            }

            //Act
            using (var context = new MemberManagementContext(options))
            {
                var memberWithBranch = context.Members
                    .Include(m => m.Branch)
                    .OrderBy(b => b.Branch.BranchName)
                    .FirstOrDefault(m => m.MemberID == 1);

                //Assert
                Assert.NotNull(memberWithBranch);
                Assert.Equal("Virac", memberWithBranch.Branch.BranchName);
            }
        }
    }
}
