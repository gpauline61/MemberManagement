using MemberManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Domain.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAll();
    }
}
