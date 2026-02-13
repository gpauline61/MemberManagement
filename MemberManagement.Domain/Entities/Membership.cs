using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Domain.Entities
{
    public class Membership
    {
        public int MembershipID { get; set; }
        public string MembershipType { get; set; }
        public string? MembershipDescription { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
