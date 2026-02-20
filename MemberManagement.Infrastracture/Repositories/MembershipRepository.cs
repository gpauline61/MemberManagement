using AutoMapper.Execution;
using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Interfaces;
using MemberManagement.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Infrastracture.Repositories
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly MemberManagementDbContext _context;
        public MembershipRepository(MemberManagementDbContext context)
        {
            _context = context;
        }
        public bool Add(Membership membership)
        {
            _context.Add(membership);

            return Save();
        }

        public bool checkMembership(Membership membership)
        {
            var checkmemship = _context.Memberships
                .Where(m => m.MembershipType == membership.MembershipType
                && m.MembershipDescription == membership.MembershipDescription)
                .FirstOrDefault();

            return checkmemship != null ? true : false;
        }

        public bool checkMembershipId(int id)
        {
            var membership = _context.Memberships
                .Where(m => m.MembershipID == id)
                .FirstOrDefault();

            return membership == null ? true : false;
        }

        public async Task DeleteConfirmed(int id)
        {
            var membership = await GetIdAsync(id);
            if (membership != null)
            {
                await MemberMembershipIDTONull(membership.MembershipID);
                Delete(membership);
            }
        }

        public async Task MemberMembershipIDTONull(int Membership)
        {
            var members = await _context.Members.Where(m => m.MembershipId == Membership).ToListAsync();
            foreach (var member in members)
            {
                member.MembershipId = null;
            }
            Save();
        }

        public async Task<Membership> DeleteMembership(int id)
        {
            return await GetIdAsync(id);
        }

        public async Task<Membership> DetailMembership(int id)
        {
            //First, get the member by means of its Id
            var membership = await GetIdAsync(id);

            //if found, return the details of the member
            return membership != null ? membership : null;
        }

        public async Task<Membership> EditMembership(int id)
        {
            var membership = await GetIdAsync(id);

            //If member is found, return the details of the member
            return membership != null ? membership : null;
        }

        public async Task<IEnumerable> GetAll()
        {
            return await _context.Memberships.ToListAsync();
        }

        public Task SaveEditMembership(int id, Membership membership)
        {
            throw new NotImplementedException();
        }

        public bool Update(Membership membership)
        {
            _context.Update(membership);
            return Save();
        }

        public async Task<Membership> GetIdAsync(int id)
        {
            var membership = await _context.Memberships.FirstAsync(m => m.MembershipID == id);
            return membership;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Delete(Membership membership)
        {
            _context.Remove(membership);
            return Save();
        }
    }
}
