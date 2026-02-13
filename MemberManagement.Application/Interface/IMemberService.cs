using MemberManagement.Application.DTO.MemberDTO;
using MemberManagement.Domain.Entities;
using System.Collections;

namespace MemberManagement.Application.Interface
{
    public interface IMemberService
    {
        Task<IEnumerable> GetAll();
        Task<MemberDetailDTO> DetailMember(int id);
        bool AddMember(Member member);
        Task<MemberEditDTO> EditMember(int id);
        Task SaveEditMember(int id, Member member);
        Task<MemberDetailDTO> DeleteMember(int id);
        Task DeleteConfirmed(int id);
        Task<IEnumerable> GetAllActive();
        Task<IEnumerable> GetAllInactive();

    }
}
