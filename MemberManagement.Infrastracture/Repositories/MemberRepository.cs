using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Interfaces;
using MemberManagement.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace MemberManagement.Infrastracture.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberManagementDbContext _context;
        public MemberRepository(MemberManagementDbContext context)
        {
            _context = context;
        }

        //Get all members
        public async Task<IEnumerable> GetAll()
        {
            //Retrieve all Members in Db order by its Branch
            return await _context.Members
                .OrderBy(m => m.Branch)
                .ToListAsync();
        }

        //Add member
        public bool Add(Member member)
        {
            //Set all new members IsActive flag to true
            member.IsActive = true;

            //Set DateCreated to the current time as the member added
            member.DateCreated = DateTime.Now;
            _context.Add(member);

            //Call a local method Save to save changes to the database
            return Save();
        }

        //Get the member's detail
        public async Task<Member> DetailMember(int id)
        {
            //First, get the member by means of its Id
            var member = await GetIdAsync(id);

            //if found, return the details of the member
            return member != null ? member : null;
        }

        //Get the details of the member to be edited
        public async Task<Member> EditMember(int id)
        {
            var member = await GetIdAsync(id);

            //If member is found, return the details of the member
            return member != null ? member : null;
        }

        //Save the details of the member that was edited
        public async Task SaveEditMember(int id, Member member)
        {
           Update(member);
        }

        //get the member's details to be deleted
        public async Task<Member> DeleteMember(int id)
        {
            return await GetIdAsync(id);
        }

        //process to set IsActive flag to false (soft delete)
        public async Task DeleteConfirmed(int id)
        {
            var member = await GetIdAsync(id);
            if (member != null)
            {
                Delete(member);
            }
        }
        
        //Get all Active members (IsActive == true)
        public async Task<IEnumerable> GetAllActive()
        {
            var members = await _context.Members
                .Where(m => m.IsActive)
                .OrderBy(m => m.Branch)
                .ToListAsync();
            return members;
        }

        //Get all Active members (IsActive == false)
        public async Task<IEnumerable> GetAllInactive()
        {
            var members = await _context.Members
                .Where(m => m.IsActive == false)
                .OrderBy(m => m.Branch)
                .ToListAsync();
            return members;
        }

        //Check if Last name, first name, and birthdate is already in the list
        //If all three exists, adding the new member will not proceed
        public bool checkMember(Member member) 
        {
            var checkmem = _context.Members
                .Where(m => m.LastName == member.LastName
                && m.FirstName == member.FirstName
                && m.Birthdate == member.Birthdate)
                .FirstOrDefault();

            return checkmem != null ? true : false;
        }
        
        //Check for the Member if in the list
        public bool checkMemberId(int id) 
        {
            var member = _context.Members
                .Where(m => m.MemberID == id)
                .FirstOrDefault();

            return member == null ? true : false;
        }

        //Method to invoke changes to DbContext and Db
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        //Get the member given by its Id
        public async Task<Member> GetIdAsync(int id)
        {
            var member = await _context.Members.FirstAsync(m => m.MemberID == id);
            return member;
        }

        //Method to update any changes to the Db
        public bool Update(Member member)
        {
            _context.Update(member);
            return Save();
        }

        //Method to perform soft delete to a member
        public bool Delete(Member member)
        {
            member.IsActive = false;
            Update(member);
            return Save();
        }
    }
}