using MemberManagement.Application.DTO.BranchDTO;
using MemberManagement.Application.DTO.MemberDTO;
using MemberManagement.Domain.Entities;
using System.Collections;

namespace MemberManagement.Application.Interface
{
    public interface IBranchService
    {
        Task<IEnumerable> GetAll();
        bool AddBranch(Branch branch);
        Task<BranchDetailDTO> DetailBranch(int id);
        Task<BranchEditDTO> EditBranch(int id);
        Task SaveEditBranch(int id, Branch branch);
        Task<BranchDeleteDTO> DeleteBranch(int id);
        Task DeleteConfirmed(int id);
    }
}