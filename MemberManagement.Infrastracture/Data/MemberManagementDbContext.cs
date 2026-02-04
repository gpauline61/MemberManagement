using MemberManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Infrastracture.Data
{
    //DbContext to be used
    public class MemberManagementDbContext : DbContext
    {
        public MemberManagementDbContext(DbContextOptions<MemberManagementDbContext> options) : base(options)
        {
            
        }
        public DbSet<Member> Members { get; set; }
    }
    
}
