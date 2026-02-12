using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Domain.Entities
{
    public class MembershipType
    {
        public int MembershipTypeID { get; set; }
        public string MembershipName { get; set; }
        public string MembershipDescription { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
