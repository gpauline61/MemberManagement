using MemberManagement.Application.DTO.MemberDTO;
using MemberManagement.Application.DTO.MembershipDTO;
using MemberManagement.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Application.Interface
{
    public interface IMembershipService
    {
        Task<IEnumerable> GetAll();
        Task<MembershipDetailDTO> DetailMembership(int id);
        bool AddMembership(Membership membership);
        Task<MembershipEditDTO> EditMembership(int id);
        Task SaveEditMembership(int id, Membership membership);
        Task<MembershipDetailDTO> DeleteMembership(int id);
        Task DeleteConfirmed(int id);
    }
}
