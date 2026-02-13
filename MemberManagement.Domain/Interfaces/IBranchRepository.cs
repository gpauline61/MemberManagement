using MemberManagement.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Domain.Interfaces
{
    public interface IBranchRepository
    {
        Task<IEnumerable> GetAll();
        bool Add(Branch branch);
        bool checkBranch(Branch branch);
        Task<Branch> DetailBranch(int id);
        bool checkBranchId(int id);
        Task<Branch> EditBranch(int id);
        Task SaveEditBranch(int id, Branch branch);
        bool Update(Branch branch);
        Task<Branch> DeleteBranch(int id);
        Task DeleteConfirmed(int id);
    }
}
