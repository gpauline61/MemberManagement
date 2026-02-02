using MemberManagement.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.Application.DTO
{
    public class MemberActiveInactiveDTO
    {
        public int MemberID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateOnly Birthdate { get; set; }
        public string Address { get; set; }
        public BranchCategory Branch { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
    }
}
