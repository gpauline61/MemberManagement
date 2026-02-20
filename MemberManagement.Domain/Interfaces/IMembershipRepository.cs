<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Text;
=======
﻿using MemberManagement.Domain.Entities;
using System.Collections;
>>>>>>> feature/updateMember

namespace MemberManagement.Domain.Interfaces
{
    public interface IMembershipRepository
    {
<<<<<<< HEAD
=======
        Task<IEnumerable> GetAll();
        bool Add(Membership membership);
        Task<Membership> DetailMembership(int id);
        Task<Membership> EditMembership(int id);
        Task SaveEditMembership(int id, Membership membership);
        Task<Membership> DeleteMembership(int id);
        Task DeleteConfirmed(int id);
        bool checkMembership(Membership membership);
        bool checkMembershipId(int id);
        bool Update(Membership membership);
>>>>>>> feature/updateMember
    }
}
