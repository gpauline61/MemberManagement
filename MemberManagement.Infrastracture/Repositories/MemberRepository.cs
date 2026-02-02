using MemberManagement.Application.DTO;
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
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberManagementDbContext _context;
        public MemberRepository(MemberManagementDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable> GetAll()
        {
            return await _context.Members.ToListAsync();
        }

        public bool Add(Member member)
        {

            member.IsActive = true;
            member.DateCreated = DateTime.Now;
            _context.Add(member);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<Member> GetIdAsync(int id)
        {
            var member = await _context.Members.FirstAsync(m => m.MemberID == id);

            return member;
        }

        public async Task<Member> DetailMember(int id)
        {
            var member = await GetIdAsync(id);

            if (member != null)
            {

                return member;
            }
            else
            {
                return null;
            }

        }
        public async Task<Member> EditMember(int id)
        {
            var member = await GetIdAsync(id);

            if (member != null)
            {
                return member;
            }
            else
            {
                return null;
            }
        }
        public async Task SaveEditMember(int id, Member member)
        {
            var mem = await GetIdAsync(id);


            if (mem != null)
            {
                mem.LastName = member.LastName;
                mem.FirstName = member.FirstName;
                mem.Birthdate = member.Birthdate;
                mem.Address = member.Address;
                mem.Branch = member.Branch;
                mem.ContactNo = member.ContactNo;
                mem.Email = member.Email;
                mem.IsActive = member.IsActive;
                Update(mem);
            }
        }

        public bool Update(Member member)
        {
            _context.Update(member);
            return Save();
        }

        public async Task<Member> DeleteMember(int id)
        {
            return await GetIdAsync(id);
        }
        public async Task DeleteConfirmed(int id)
        {
            var member = await GetIdAsync(id);
            if (member != null)
            {
                Delete(member);
            }

        }

        public bool Delete(Member member)
        {

            member.IsActive = false;
            Update(member);
            return Save();
        }
        public async Task<IEnumerable> GetAllActive()
        {

            var members = await _context.Members
                .Where(m => m.IsActive)
                .OrderBy(m => m.LastName)
                .ToListAsync();
            return members;
        }

        public async Task<IEnumerable> GetAllInactive()
        {
            var members = await _context.Members
                .Where(m => m.IsActive == false)
                .OrderBy(m => m.LastName)
                .ToListAsync();
            return members;
        }


    }
}
