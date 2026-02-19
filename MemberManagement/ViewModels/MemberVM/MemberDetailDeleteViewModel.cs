using MemberManagement.Domain.Entities;
using MemberManagement.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace MemberManagement.Web.ViewModels.MemberVM
{
    public class MemberDetailDeleteViewModel
    {
        public int MemberID { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateOnly Birthdate { get; set; }
        public string? Address { get; set; }
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }
        [Display(Name = "Contact No.")]
        public string? ContactNo { get; set; }
        [Display(Name = "Email Address")]
        public string? Email { get; set; }
        [Display(Name = "Active Status")]
        public string IsActive { get; set; }
    }
}
