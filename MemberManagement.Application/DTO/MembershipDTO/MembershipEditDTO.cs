using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Application.DTO.MembershipDTO
{
    public class MembershipEditDTO
    {
        public int MembershipID { get; set; }
        public string MembershipType { get; set; }
        public string? MembershipDescription { get; set; }
    }
}
