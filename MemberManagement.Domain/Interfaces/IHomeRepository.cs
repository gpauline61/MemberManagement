using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Domain.Interfaces
{
    public interface IHomeRepository
    {
        List<int> GetMemberCount();
      
    }
}
