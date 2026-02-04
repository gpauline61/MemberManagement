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

        //Compute total count for All, Active, and Inactive Members separately
        public List<int> GetMemberCount()
        {
            List<int> counters = new List<int>();
            //All Members
            counters.Add(_context.Members.Count());

            //Active Members
            counters.Add(_context.Members
                .Where(m => m.IsActive)
                .Count());

            //Inactive Members
            counters.Add(_context.Members
                .Where(m => m.IsActive == false)
                .Count());
            return counters;
        }

        
    }
}
