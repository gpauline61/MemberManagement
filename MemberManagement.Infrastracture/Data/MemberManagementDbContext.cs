using MemberManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Infrastracture.Data
{
    public class MemberManagementDbContext(DbContextOptions<MemberManagementDbContext> options) :DbContext(options)
    {
        public DbSet<Member> Members { get; set; }
    }
}
