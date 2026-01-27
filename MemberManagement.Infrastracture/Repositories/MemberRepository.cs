using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Interfaces;
using MemberManagement.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Infrastracture.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberManagementDbContext _context;
        public MemberRepository(MemberManagementDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Member>> GetAll()
        {
            return await _context.Members
                .ToListAsync();
        }
    }
}
