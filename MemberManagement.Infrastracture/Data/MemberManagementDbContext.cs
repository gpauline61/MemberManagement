using MemberManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MemberManagement.Infrastracture.Data
{
    //DbContext to be used
    public class MemberManagementDbContext : DbContext
    {
        public MemberManagementDbContext(DbContextOptions<MemberManagementDbContext> options) : base(options)
        {
            
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Branch> Branches { get; set; }
    }
    
}
