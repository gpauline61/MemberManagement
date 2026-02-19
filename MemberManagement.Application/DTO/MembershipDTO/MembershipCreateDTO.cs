using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Application.DTO.MembershipDTO
{
    public class MembershipCreateDTO
    {
        public string MembershipType { get; set; }
        public string? MembershipDescription { get; set; }
    }
}
