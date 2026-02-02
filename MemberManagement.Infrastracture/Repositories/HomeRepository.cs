using MemberManagement.Domain.Interfaces;
using MemberManagement.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Infrastracture.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly MemberManagementDbContext _context;
        public HomeRepository(MemberManagementDbContext context)
        {
            _context = context;
        }
        public List<int> GetMemberCount()
        {
            List<int> counters = new List<int>();
            counters.Add(_context.Members.Count());
            counters.Add(_context.Members
                .Where(m => m.IsActive)
                .Count());
            counters.Add(_context.Members
                .Where(m => m.IsActive == false)
                .Count());
            return counters;
        }

        
    }
}
