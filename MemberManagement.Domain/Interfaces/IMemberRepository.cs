using MemberManagement.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Domain.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable> GetAll();
        bool Add(Member member);
        Task<Member> DetailMember(int id);
        Task<Member> EditMember(int id);
        Task SaveEditMember(int id, Member member);
        Task<Member> DeleteMember(int id);
        Task DeleteConfirmed(int id);
        Task<IEnumerable> GetAllActive();
        Task<IEnumerable> GetAllInactive();
    }


}
