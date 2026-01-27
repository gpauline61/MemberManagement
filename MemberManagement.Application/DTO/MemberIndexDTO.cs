using MemberManagement.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MemberManagement.Application.DTO
{
    public class MemberIndexDTO
    {
        public int MemberID { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateOnly Birthdate { get; set; }
        public string Address { get; set; }
        public BranchCategory Branch { get; set; }
        [Display(Name = "Contact No.")]
        public string ContactNo { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        public string IsActive { get; set; }
    }
}
