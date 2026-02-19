using AutoMapper.Execution;
using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Interfaces;
using MemberManagement.Infrastracture.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace MemberManagement.Infrastracture.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly MemberManagementDbContext _context;
        public BranchRepository(MemberManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable> GetAll()
        {
            return await _context.Branches
                .OrderBy(m => m.BranchName)
                .ToListAsync();
        }

        public bool Add(Branch branch)
        {
            _context.Add(branch);

            return Save();
        }

        public async Task<Branch> DetailBranch(int id)
        {
            var member = await GetIdAsync(id);

            return member != null ? member : null;
        }

        public async Task<Branch> EditBranch(int id)
        {
            var branch = await GetIdAsync(id);

            return branch != null ? branch : null;
        }

        public async Task SaveEditBranch(int id, Branch branch)
        {
            Update(branch);
        }

        public async Task<Branch> DeleteBranch(int id)
        {
            return await GetIdAsync(id);
        }

        //process to set IsActive flag to false (soft delete)
        public async Task DeleteConfirmed(int id)
        {
            var branch = await GetIdAsync(id);
            if (branch != null)
            {
                Delete(branch);
            }
        }
        public async Task<Branch> GetIdAsync(int id)
        {
            var branch = await _context.Branches.FirstAsync(b => b.BranchID == id);
            return branch;
        }
        public bool checkBranch(Branch branch)
        {
            var checkb = _context.Branches
                .Where(b => b.BranchName == branch.BranchName
                && b.BranchAddress == branch.BranchAddress)
                .FirstOrDefault();

            return checkb != null ? true : false;
        }

        public bool checkBranchId(int id)
        {
            var branch = _context.Branches
                .Where(b => b.BranchID == id)
                .FirstOrDefault();

            return branch == null ? true : false;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public bool Update(Branch branch)
        {
            _context.Update(branch);
            return Save();
        }

        public bool Delete(Branch branch)
        {
            _context.Remove(branch);
            return Save();
        }
    }
}
